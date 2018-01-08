CREATE TABLE [dbo].[DoctorProfile]
(
	[UserId] NVARCHAR(128) NOT NULL , 
	[Speciality] NVARCHAR(MAX) NOT NULL, 
	[Degrees] NVARCHAR(MAX) NOT NULL, 
	[Training] NVARCHAR(MAX) NOT NULL, 
	[Office] NVARCHAR(200) NOT NULL, 
	[Workdays] NVARCHAR(MAX) NOT NULL, 
	[DepartmentId] SMALLINT NOT NULL, 
    PRIMARY KEY ([UserId])
)
