CREATE TABLE [dbo].[ArticleComment] (
    [Id]          SMALLINT        NOT NULL,
    [ArticleId]   INT             NOT NULL,
    [Date]        SMALLDATETIME   NOT NULL,
    [Detail]      NVARCHAR (1000) NOT NULL,
    [CreatedUser] NVARCHAR(128)             NOT NULL,
    [Status]      TINYINT         NOT NULL,
    CONSTRAINT [PK_ArticleComment] PRIMARY KEY CLUSTERED ([Id] ASC, [ArticleId] ASC),
    CONSTRAINT [FK_ArticleComment_Article] FOREIGN KEY ([ArticleId]) REFERENCES [dbo].[Article] ([Id])
);

