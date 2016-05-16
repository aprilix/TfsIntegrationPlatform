USE [Tfs_IntegrationPlatform]


GO
PRINT N'Dropping [FriendlyName]...';



EXECUTE sp_dropextendedproperty @name = N'FriendlyName';



PRINT N'Dropping [ReferenceName]...';



EXECUTE sp_dropextendedproperty @name = N'ReferenceName';



PRINT N'Altering [dbo].[SYNC_POINT]...';



ALTER TABLE [dbo].[SYNC_POINT]
	ADD [LastChangeGroupId] BIGINT NULL;



PRINT N'Creating [dbo].[NonTransactionDeleteSessionComputedButNotMigratedData]...';


GO
CREATE PROCEDURE [dbo].[NonTransactionDeleteSessionComputedButNotMigratedData]
	@SessionUniqueId UNIQUEIDENTIFIER
AS	
	-- SEE: ReleaseCode\Core\Toolkit\ChangeGroup.cs
	--// these values are persisted in SQL so do not change them between releases
	--/// <summary>
	--/// Change Group Status
	--/// </summary>
	--public enum ChangeStatus
	--{
		--Unintialized = -1,                  // 
		--Delta = 0,                          // Initial state of delta table entry
		--DeltaPending = 1,                   // Group contains delta table entry: NextDeltaTable works on this status
		--DeltaComplete = 2,                  // Group, as delta table entry, is "complete", i.e the entry is no longer needed
		--DeltaSynced = 8,                    // up, as delta table entry, has been "synced" to the other side. i.e. the entry is no longer needed for content conflict detection.
		--AnalysisMigrationInstruction = 3,   // The initial status of the migration instruction table entry
		--Pending    = 4,                     // Start processing migration instruction: NextMigrationInstruction works on this status
		--InProgress = 5,                     // 
		--Complete   = 6,                     //
		--Skipped    = 7,                     //
		--ChangeCreationInProgress = 20,      // change group creation is in progress during paged change actions insertion 
		--PendingConflictDetection    = 9,    //
		--Obsolete = 10                       // 
	--}
	
	-- 1. find the "cached" change groups and actions of the sessions
	-- 1.1 delete all "cached" and non-conflicted change actions and groups of the sessions
	-- 1.1.1 find the non-conflicted change group ids for deletion
	DECLARE @ChangeGroupIdsToDelete TABLE(ChangeGroupId BIGINT)
	INSERT INTO @ChangeGroupIdsToDelete
		SELECT G.Id
		FROM [dbo].[RUNTIME_CHANGE_GROUPS] AS G WITH(NOLOCK) 
		WHERE (G.Status = -1 OR G.Status = 0 OR G.Status = 1 OR G.Status = 3 OR G.Status = 4 
			  OR G.Status = 5 OR G.Status = 20 OR G.Status = 9)
		AND G.SessionUniqueId = @SessionUniqueId
		AND G.ContainsBackloggedAction = 0
		
	-- 1.1.2 delete the change actions
	--------DELETE FROM [dbo].[RUNTIME_CHANGE_ACTION]
	--------WHERE [ChangeGroupId] IN (SELECT ChangeGroupId FROM @ChangeGroupIdsToDelete)
	
	-- 1.1.3 delete the groups and clear the temp table
	--------DELETE FROM [dbo].[RUNTIME_CHANGE_GROUPS]
	--------WHERE Id IN (SELECT ChangeGroupId FROM @ChangeGroupIdsToDelete)
	UPDATE [dbo].[RUNTIME_CHANGE_GROUPS]
	SET Status = 10 -- Obsolete
	WHERE Id IN (SELECT ChangeGroupId FROM @ChangeGroupIdsToDelete)
	
	DELETE FROM @ChangeGroupIdsToDelete
	
	-- 1.2 find the second to the last sync point
	-- NOTE: the last sync point contains the HWM that is updated after last Delta computation
	--       the last change group id in the same sync point also points to the last change group after
	--       the last session trip
	-- WE WANT TO FIND OUT THE SECOND-TO-THE-LAST HWM AND 'LAST CHANGE GROUP ID' to define the scope for deletion
	
	-- find migration source ids for the session
	DECLARE @MigrationSourceIds TABLE(MigrationSourceId UNIQUEIDENTIFIER)
	INSERT INTO @MigrationSourceIds
	SELECT M.UniqueId
	FROM [dbo].[MIGRATION_SOURCES] M WITH(NOLOCK)
	WHERE EXISTS (SELECT * FROM [dbo].[RUNTIME_SESSIONS] S WITH(NOLOCK)
				  WHERE (M.Id = S.LeftSourceId OR M.Id = S.RightSourceId)
				  AND S.SessionUniqueId = @SessionUniqueId)
	
	DECLARE @PerSourceSecondToLastSyncPoint TABLE(SourceUniqueId UNIQUEIDENTIFIER, SyncPointId BIGINT)
	INSERT INTO @PerSourceSecondToLastSyncPoint
	SELECT S1.[SourceUniqueId], MIN(S1.Id)
	FROM (SELECT TOP(2) S.[SourceUniqueId], S.Id
		  FROM [dbo].[SYNC_POINT] S WITH(NOLOCK)
		  WHERE S.[SessionUniqueId] = @SessionUniqueId
		  AND S.[SourceUniqueId] IN (SELECT MigrationSourceId FROM @MigrationSourceIds)
		  ORDER BY S.Id DESC) AS S1
	GROUP BY S1.[SourceUniqueId]
	HAVING COUNT(S1.Id) > 1 -- a migration source may have only one SyncPoint written
			
	DECLARE @LastChangeGroupIdInPrevSync BIGINT
	DECLARE @CountPerSourceSecondToLastSyncPoint INT
	
	SELECT @CountPerSourceSecondToLastSyncPoint = COUNT(*) 
	FROM @PerSourceSecondToLastSyncPoint
	
	IF @CountPerSourceSecondToLastSyncPoint > 1
	BEGIN
		SELECT @LastChangeGroupIdInPrevSync = MIN(S.LastChangeGroupId)
		FROM [dbo].[SYNC_POINT] S WITH(NOLOCK)
		INNER JOIN @PerSourceSecondToLastSyncPoint AS P
		ON P.SyncPointId = S.Id
	END
	ELSE BEGIN
		SET @LastChangeGroupIdInPrevSync = 0
	END
	
	-- 1.3 delete all "cached" and conflicted change actions and groups (after the last sync-ed group)
	-- 1.3.1 find conflicted groups *after* known last migrated change group
	INSERT INTO @ChangeGroupIdsToDelete
		SELECT G.Id
		FROM [dbo].[RUNTIME_CHANGE_GROUPS] AS G WITH(NOLOCK) 
		WHERE G.SessionUniqueId = @SessionUniqueId
		AND G.Id > @LastChangeGroupIdInPrevSync
		AND (G.Status = -1 OR G.Status = 0 OR G.Status = 1 OR G.Status = 3 OR G.Status = 4 
			 OR G.Status = 5 OR G.Status = 20 OR G.Status = 9)			  
		AND G.ContainsBackloggedAction = 1

	-- 1.3.2 find all change actions to delete
	DECLARE @ChangeActionsIdsToDelete TABLE(ChangeActionId BIGINT)
	INSERT INTO @ChangeActionsIdsToDelete
	SELECT [ChangeActionId] 
	FROM [dbo].[RUNTIME_CHANGE_ACTION] WITH(NOLOCK)
	WHERE [ChangeGroupId] IN (SELECT * FROM @ChangeGroupIdsToDelete)
				
	-- 1.3.3 delete all active conflicts
	--------DELETE FROM [dbo].[CONFLICT_CONFLICTS]
	--------WHERE [ConflictedChangeActionId] IN (SELECT ChangeActionId FROM @ChangeActionsIdsToDelete)
	UPDATE [dbo].[CONFLICT_CONFLICTS]
	SET Status = 1
	WHERE [ConflictedChangeActionId] IN (SELECT ChangeActionId FROM @ChangeActionsIdsToDelete)
	
	-- 1.3.4 delete all conflicted change actions
	--------DELETE FROM [dbo].[RUNTIME_CHANGE_ACTION]
	--------WHERE [ChangeActionId] IN (SELECT ChangeActionId FROM @ChangeActionsIdsToDelete)
	
	-- 1.3.5 delete all conflicted change groups
	--------DELETE FROM [dbo].[RUNTIME_CHANGE_GROUPS]
	--------WHERE Id IN (SELECT ChangeGroupId FROM @ChangeGroupIdsToDelete)
	UPDATE [dbo].[RUNTIME_CHANGE_GROUPS]
	SET Status = 10 -- Obsolete
	WHERE Id IN (SELECT ChangeGroupId FROM @ChangeGroupIdsToDelete)

	-- (skipped) find the "cached" link change groups
	-- NOTE: this step is not needed 
	-- deleting "scoped-out" link is not needed as the link engine will "skip" untranslatable links
	
	-- 2. find the sync point and update hwm for each session
	-- 2.1 if sync point is available, use it
	UPDATE H
	SET [Value] = S.[SourceHighWaterMarkValue]
	FROM [dbo].[HIGH_WATER_MARK] H
	INNER JOIN [dbo].[SYNC_POINT] S
		ON H.[SessionUniqueId] = S.[SessionUniqueId]
		AND H.[SourceUniqueId] = S.[SourceUniqueId]
		AND H.[Name] = S.[SourceHighWaterMarkName]
	INNER JOIN @PerSourceSecondToLastSyncPoint AS P
		ON (P.SourceUniqueId = S.[SourceUniqueId] AND P.SyncPointId = S.Id)
	
	-- 2.2 sources may not have sync point written yet, set their high watermark to NULL
	-- 2.2.1 find all hwm related to the session BUT not having a sync point
	DECLARE @HWMs TABLE(SessionUniqueId UNIQUEIDENTIFIER, SourceUniqueId UNIQUEIDENTIFIER, HWMName NVARCHAR(50))
	INSERT INTO @HWMs 
	SELECT SessionUniqueId, SourceUniqueId, [Name]
	FROM [dbo].[HIGH_WATER_MARK]
	WHERE SessionUniqueId = @SessionUniqueId
	AND NOT EXISTS (SELECT * 
					FROM [dbo].[HIGH_WATER_MARK] H
					INNER JOIN @PerSourceSecondToLastSyncPoint AS P
					ON H.[SourceUniqueId] = P.SourceUniqueId)
	-- 2.2.2 update them with default value (NULL)
	update H
	SET [Value] = NULL
	FROM [dbo].[HIGH_WATER_MARK] H
	INNER JOIN @HWMs AS HS
		ON H.[SessionUniqueId] = HS.[SessionUniqueId]
		AND H.[SourceUniqueId] = HS.[SourceUniqueId]
		AND H.[Name] = HS.[HWMName]
	
	-- 3. delete the most recent sync pointS
	DECLARE @PerSourceSyncPointIdToDelete TABLE (Id BIGINT)
	INSERT INTO @PerSourceSyncPointIdToDelete
	SELECT DISTINCT S.Id
	FROM [dbo].[SYNC_POINT] S WITH(NOLOCK)
	INNER JOIN @PerSourceSecondToLastSyncPoint AS P
		ON (P.SourceUniqueId = S.[SourceUniqueId] AND P.SyncPointId < S.Id)

	 -- a migration source may have only one SyncPoint written, and it needs to be deleted
	DELETE FROM @PerSourceSecondToLastSyncPoint
	INSERT INTO @PerSourceSecondToLastSyncPoint
	SELECT S1.[SourceUniqueId], MIN(S1.Id)
	FROM (SELECT TOP(1) S.[SourceUniqueId], S.Id
		  FROM [dbo].[SYNC_POINT] S WITH(NOLOCK)
		  WHERE S.[SessionUniqueId] = @SessionUniqueId
		  AND S.[SourceUniqueId] IN (SELECT MigrationSourceId FROM @MigrationSourceIds)
		  ORDER BY S.Id DESC) AS S1
	GROUP BY S1.[SourceUniqueId]
	HAVING COUNT(S1.Id) = 1

	INSERT INTO @PerSourceSyncPointIdToDelete
	SELECT DISTINCT SyncPointId
	FROM @PerSourceSecondToLastSyncPoint

	DELETE FROM [dbo].[SYNC_POINT] 
	WHERE Id IN (SELECT * FROM @PerSourceSyncPointIdToDelete)
	
	-- 4. delete data in Last Processed Item Version so that delta can be re-generated
	DELETE FROM [dbo].[LAST_PROCESSED_ITEM_VERSIONS]
	WHERE MigrationSourceId IN (SELECT MigrationSourceId FROM @MigrationSourceIds)
RETURN 0

PRINT N'Creating [dbo].[TransactionalDeleteSessionComputedButNotMigratedData]...';


GO
CREATE PROCEDURE [dbo].[TransactionalDeleteSessionComputedButNotMigratedData]
	@SessionUniqueId UNIQUEIDENTIFIER
AS
	-- PROTECTION AGAINST RUNTIME/TIMEOUT ERROR
	SET XACT_ABORT ON 
	 
	BEGIN TRANSACTION DeleteComputedDataTransaction;	
	BEGIN TRY
	
		EXECUTE [dbo].[NonTransactionDeleteSessionComputedButNotMigratedData] @SessionUniqueId;
		
		PRINT N'Committing...';
		COMMIT TRANSACTION DeleteComputedDataTransaction;
		PRINT N'Committed...';
	
	END TRY	
	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(4000);
		DECLARE @ErrorSeverity INT;
		DECLARE @ErrorState INT;

		SELECT @ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE();

		IF @@TRANCOUNT > 0
			PRINT N'Starting Rollback...';
			ROLLBACK TRANSACTION DeleteComputedDataTransaction;
			RAISERROR (@ErrorMessage,@ErrorSeverity, @ErrorState)
	END CATCH;	
	
	SELECT TOP 1 * FROM [dbo].[RUNTIME_SESSIONS]
	WHERE SessionUniqueId = @SessionUniqueId
		
RETURN 0

PRINT N'Creating [dbo].[DeleteComputedButNotMigratedData]...';


GO
CREATE PROCEDURE [dbo].[DeleteComputedButNotMigratedData]
	@SessionGroupUniqueId UNIQUEIDENTIFIER
AS
	-- PROTECTION AGAINST RUNTIME/TIMEOUT ERROR
	SET XACT_ABORT ON 
	 
	BEGIN TRANSACTION DeleteComputedDataTransaction;	
	BEGIN TRY
	
		-- 1. find the sessions in the session group
		DECLARE @SessionIds TABLE(SessionUniqueId UNIQUEIDENTIFIER)
		INSERT INTO @SessionIds(SessionUniqueId)
			SELECT DISTINCT S.SessionUniqueId
			FROM [dbo].[RUNTIME_SESSIONS] AS S WITH(NOLOCK)
			INNER JOIN [dbo].[SESSION_GROUPS] AS G WITH(NOLOCK) ON S.SessionGroupId = G.Id
			WHERE G.GroupUniqueId = @SessionGroupUniqueId
		
		DECLARE @SessionUniqueId UNIQUEIDENTIFIER
		DECLARE session_cursor CURSOR FOR SELECT SessionUniqueId FROM @SessionIds
		OPEN session_cursor 
		FETCH NEXT FROM session_cursor INTO @SessionUniqueId

		WHILE @@FETCH_STATUS = 0   
		BEGIN   
			EXECUTE [dbo].[NonTransactionDeleteSessionComputedButNotMigratedData] @SessionUniqueId;
			FETCH NEXT FROM session_cursor INTO @SessionUniqueId
		END   
		
		PRINT N'Committing...';
		COMMIT TRANSACTION DeleteComputedDataTransaction;
		PRINT N'Committed...';
	
	END TRY	
	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(4000);
		DECLARE @ErrorSeverity INT;
		DECLARE @ErrorState INT;

		SELECT @ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE();

		IF @@TRANCOUNT > 0
			PRINT N'Starting Rollback...';
			ROLLBACK TRANSACTION DeleteComputedDataTransaction;
			RAISERROR (@ErrorMessage,@ErrorSeverity, @ErrorState)
	END CATCH;
	
	SELECT TOP 1 * FROM [dbo].[SESSION_GROUPS]
	WHERE GroupUniqueId = @SessionGroupUniqueId
	
RETURN 0
GO
PRINT N'Creating [FriendlyName]...';



EXECUTE sp_addextendedproperty @name = N'FriendlyName', @value = 'TFS Synchronization and Migration Database v2.1';



PRINT N'Creating [ReferenceName]...';



EXECUTE sp_addextendedproperty @name = N'ReferenceName', @value = 'E5D0A79E-1AB9-498F-8B76-D4B10D7674FF';


