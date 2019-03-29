﻿CREATE TABLE [dbo].[Tennats]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FullName] NVARCHAR(50) NOT NULL, 
    [HasKids] BIT NOT NULL DEFAULT 0, 
    [HasPets] BIT NOT NULL DEFAULT 0, 
    [Payment] FLOAT NOT NULL
)
