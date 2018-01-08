CREATE TABLE [dbo].[PostSEO] (
    [PostId]            INT            NOT NULL,
    [Title]             NVARCHAR (71)  NOT NULL,
    [Description]       NVARCHAR (160) NOT NULL,
    [Canonical]         VARCHAR (256)  NOT NULL,
    [BreadcrumbsTitle]  NVARCHAR (71)  NOT NULL,
    [MetaRobotIndex]    TINYINT        NOT NULL,
    [MetaRobotFollow]   TINYINT        NOT NULL,
    [MetaRobotAdvanced] TINYINT        NOT NULL,
    CONSTRAINT [PK_PostSEO] PRIMARY KEY CLUSTERED ([PostId] ASC),
    CONSTRAINT [FK_PostSEO_Post] FOREIGN KEY ([PostId]) REFERENCES [dbo].[Post] ([Id])
);

