CREATE TABLE [dbo].[CustomExceptions] (
    [Id]           INT                IDENTITY (1, 1) NOT NULL,
    [CreationDate] DATETIMEOFFSET (7) NOT NULL,
    [Description]  NVARCHAR (MAX)     NULL,
    CONSTRAINT [PK_dbo.CustomExceptions] PRIMARY KEY CLUSTERED ([Id] ASC)
);

