CREATE TABLE [dbo].[MessageContent] (
    [MessageId] INT            NOT NULL,
    [Detail]    NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_MessageContent] PRIMARY KEY CLUSTERED ([MessageId] ASC),
    CONSTRAINT [FK_MessageContent_Message] FOREIGN KEY ([MessageId]) REFERENCES [dbo].[Message] ([Id])
);

