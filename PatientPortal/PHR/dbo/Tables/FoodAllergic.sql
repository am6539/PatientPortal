CREATE TABLE [dbo].[FoodAllergic]
(
	[Id] TINYINT NOT NULL , 
    [PatientId] VARCHAR(20) NOT NULL, 
    [Name] NVARCHAR(150) NOT NULL, 
    [Status] NVARCHAR(50) NOT NULL, 
    [Note] NVARCHAR(300) NULL, 
    PRIMARY KEY ([Id], [PatientId])
)
