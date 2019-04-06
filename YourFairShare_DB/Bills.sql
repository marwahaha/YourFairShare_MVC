CREATE TABLE [dbo].[Bills] (
    [Id]      INT           IDENTITY (1, 1) NOT NULL,
    [Name]    NVARCHAR (50) NOT NULL,
    [Amount]  DECIMAL (18)  NOT NULL,
    [DueDate] DATE          NOT NULL,
    PRIMARY KEY CLUSTERED ([Name])
);

