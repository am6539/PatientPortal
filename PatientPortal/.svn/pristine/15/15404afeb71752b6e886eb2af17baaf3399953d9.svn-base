CREATE TABLE [dbo].[Message] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [FolderId]   TINYINT        NOT NULL,
    [Subject]    NVARCHAR (250) NOT NULL,
    [Date]       SMALLDATETIME  NOT NULL,
    [SenderId]   NVARCHAR(128)            NOT NULL,
    [ReceiverId] NVARCHAR(128)            NOT NULL,
    [IsRead]     BIT            NOT NULL,
    [IsSend]     BIT            NOT NULL,
    [IsPriority] BIT            NOT NULL,
    CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Message_MessageFolder] FOREIGN KEY ([FolderId]) REFERENCES [dbo].[MessageFolder] ([Id]),
);

GO
CREATE NONCLUSTERED INDEX [idxMessageFolder]
    ON [dbo].[Message]([FolderId] ASC);
GO
CREATE NONCLUSTERED INDEX [idxMessageSender]
    ON [dbo].[Message]([SenderId] ASC);
GO
CREATE NONCLUSTERED INDEX [idxMessageReceiver]
    ON [dbo].[Message]([ReceiverId] ASC);
