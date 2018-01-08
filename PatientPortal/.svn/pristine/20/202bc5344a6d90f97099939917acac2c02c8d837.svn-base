CREATE TABLE [dbo].[PostStateHistory] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [PostId]          INT            NOT NULL,
    [WorkflowStateId] TINYINT        NOT NULL,
    [UserId]          NVARCHAR(128)            NOT NULL,
    [Note]            NVARCHAR (500) NOT NULL,
    [CreatedDate]     VARCHAR (20)   NOT NULL,
    CONSTRAINT [PK_PostStateHistory] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PostStateHistory_Post] FOREIGN KEY ([PostId]) REFERENCES [dbo].[Post] ([Id])
);

GO
CREATE NONCLUSTERED INDEX [idxPostStateHistoryPost]
    ON [dbo].[PostStateHistory]([PostId] ASC);

