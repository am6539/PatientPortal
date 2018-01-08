CREATE TABLE [dbo].[DepartmentServices]
(
	[Id] SMALLINT NOT NULL , 
	[DepartmentId] SMALLINT NOT NULL, 
	[Name] NVARCHAR(80) NOT NULL, 
	[Price] NUMERIC(13, 3) NOT NULL, 
	[Category] TINYINT NOT NULL, --1: Investigations, 2: Treatments
	CONSTRAINT [PK_DepartmentServices] PRIMARY KEY ([Id], [DepartmentId])
)
