﻿ALTER TABLE [dbo].[RUNTIME_MIGRATION_RESULTS]
	ADD CONSTRAINT [FK_MigrationResults_to_SessionRuns] 
	FOREIGN KEY (SessionRunId)
	REFERENCES RUNTIME_SESSION_RUNS (Id)	

