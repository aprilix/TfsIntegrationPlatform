﻿ALTER TABLE [dbo].[SESSION_CONFIGURATIONS]
	ADD CONSTRAINT [FK_SessionConfigurations2] 
	FOREIGN KEY (LeftSourceConfigId)
	REFERENCES MIGRATION_SOURCE_CONFIGS(Id)	

