CREATE TABLE [dbo].[Rows] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Column]    NVARCHAR (MAX) NULL,
    [Value]     INT            NOT NULL,
    [Matriz_Id] INT            NULL,
    [RowNumber] INT            DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_dbo.Rows] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Rows_dbo.Matrizs_Matriz_Id] FOREIGN KEY ([Matriz_Id]) REFERENCES [dbo].[Matrizs] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Matriz_Id]
    ON [dbo].[Rows]([Matriz_Id] ASC);

