﻿ALTER TABLE [dbo].[RUNTIME_MIGRATION_ARTIFACT_LINK_JUNC]
	ADD CONSTRAINT [FK_RT_MigArtifactLinkJunc1] 
	FOREIGN KEY (LinkMigrationResultId)
	REFERENCES RUNTIME_LINKING_MIGRATION_RESULTS (Id)	

