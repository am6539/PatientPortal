CREATE TABLE [dbo].[Slider]
(
	[Id] SMALLINT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [Title] NVARCHAR(150) NOT NULL, 
    [Description] NVARCHAR(300) NOT NULL, 
    [Image] NVARCHAR(256) NOT NULL, 
    [ExpiredDate] DATE NOT NULL, 
    [IsUsed] BIT NOT NULL
)
