CREATE TABLE [dbo].[SystemNotificationUsers]
(
	[Id] INT NOT NULL , 
    [UserId] NVARCHAR(128) NOT NULL, 
    [IsRead] BIT NOT NULL, 
    CONSTRAINT [PK_SystemNotificationUsers] PRIMARY KEY ([Id], [UserId])
)
