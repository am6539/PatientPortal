CREATE TABLE [dbo].[MessageRecipient] (
    [MessageId]  INT NOT NULL,
    [ReceiverId] NVARCHAR(128) NOT NULL,
    [IsUsed] BIT NOT NULL DEFAULT 1, 
    CONSTRAINT [PK_MessageRecipient] PRIMARY KEY CLUSTERED ([MessageId] ASC, [ReceiverId] ASC),
    CONSTRAINT [FK_MessageRecipient_Message] FOREIGN KEY ([MessageId]) REFERENCES [dbo].[Message] ([Id])
);

