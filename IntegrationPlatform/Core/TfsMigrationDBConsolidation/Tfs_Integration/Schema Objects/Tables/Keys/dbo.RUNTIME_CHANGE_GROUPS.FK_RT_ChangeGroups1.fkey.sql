﻿ALTER TABLE [dbo].[RUNTIME_CHANGE_GROUPS]
	ADD CONSTRAINT [FK_RT_ChangeGroups1] 
	FOREIGN KEY (SourceMigrationSourceId)
	REFERENCES MIGRATION_SOURCES (Id)	

