CREATE TABLE [dbo].[PostTrans] (
    [PostId]      INT             NOT NULL,
    [LanguageId]  TINYINT         NOT NULL,
    [Title]       NVARCHAR (256)  NOT NULL,
    [Description] NVARCHAR (1000) NOT NULL,
    [Detail]      NVARCHAR (MAX)  NOT NULL,
    [Tag]         NVARCHAR (60)   NOT NULL,
    CONSTRAINT [PK_Post_Trans] PRIMARY KEY CLUSTERED ([PostId] ASC, [LanguageId] ASC),
    CONSTRAINT [FK_PostTrans_Language] FOREIGN KEY ([LanguageId]) REFERENCES [dbo].[Language] ([Id]),
    CONSTRAINT [FK_PostTrans_Post] FOREIGN KEY ([PostId]) REFERENCES [dbo].[Post] ([Id])
);

