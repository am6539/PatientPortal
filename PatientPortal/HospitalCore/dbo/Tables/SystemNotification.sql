CREATE TABLE [dbo].[SystemNotification]
([Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY
	, 
    [Detail] NVARCHAR(300) NOT NULL, 
    [Date] VARCHAR(10) NOT NULL, 
    [Time] VARCHAR(8) NOT NULL, 
    [SendFrom] NVARCHAR(128) NOT NULL, 
    [Link] NVARCHAR(256) NOT NULL 
)
