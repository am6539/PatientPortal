CREATE TABLE [dbo].[Allergies]
(
	[Id] INT NOT NULL , 
    [PatientId] VARCHAR(20) NOT NULL, 
    [Date] SMALLDATETIME NOT NULL, 
    [Name] NVARCHAR(150) NOT NULL, 
    [MolarMass] NVARCHAR(150) NOT NULL, 
    [TradeName] NVARCHAR(150) NOT NULL, 
    [Unit] NVARCHAR(10) NOT NULL, 
    [FullName] NVARCHAR(300) NOT NULL, 
    [Status] NVARCHAR(50) NOT NULL, 
    [Note] NVARCHAR(300) NULL, 
    PRIMARY KEY ([Id], [PatientId])
)
