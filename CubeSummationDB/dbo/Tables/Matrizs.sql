CREATE TABLE [dbo].[Matrizs] (
    [Id]          INT IDENTITY (1, 1) NOT NULL,
    [Operations]  INT NOT NULL,
    [Executed]    INT NOT NULL,
    [TestCase_Id] INT NULL,
    CONSTRAINT [PK_dbo.Matrizs] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Matrizs_dbo.TestCases_TestCase_Id] FOREIGN KEY ([TestCase_Id]) REFERENCES [dbo].[TestCases] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_TestCase_Id]
    ON [dbo].[Matrizs]([TestCase_Id] ASC);

