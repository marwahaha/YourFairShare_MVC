﻿CREATE TABLE [dbo].[Bills]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Amount] DECIMAL NOT NULL, 
    [DueDate] DATE NOT NULL
)
