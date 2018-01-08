﻿CREATE TABLE [dbo].[QA]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
	[Date] SMALLDATETIME NOT NULL,
	[Title] NVARCHAR(150) NOT NULL, 
	[Question] NVARCHAR(1000) NOT NULL, 
	[Name] NVARCHAR(32) NOT NULL, 
	[Email] VARCHAR(256) NULL, 
	[Phone] VARCHAR(20) NULL, 
	[DoctorId] NVARCHAR(128) NOT NULL, 
	[Answer] NVARCHAR(MAX) NOT NULL, 
	[Department] NVARCHAR(100) NULL
)