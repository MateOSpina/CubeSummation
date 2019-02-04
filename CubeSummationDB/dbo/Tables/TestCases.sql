CREATE TABLE [dbo].[TestCases] (
    [Id]       INT IDENTITY (1, 1) NOT NULL,
    [Cases]    INT NOT NULL,
    [Executed] INT NOT NULL,
    CONSTRAINT [PK_dbo.TestCases] PRIMARY KEY CLUSTERED ([Id] ASC)
);

