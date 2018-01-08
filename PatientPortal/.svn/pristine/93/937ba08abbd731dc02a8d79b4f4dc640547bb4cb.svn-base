CREATE PROCEDURE [dbo].[usp_DepartmentServices_CheckExistName]
	@Name  NVARCHAR(50),
	@Id SMALLINT, @DepartmentId SMALLINT
AS
BEGIN
	DECLARE @return BIT = 0

	print @Id
	IF(@Id = 0)
		IF(EXISTS(SELECT TOP 1 1 FROM [dbo].[DepartmentServices] WHERE [DepartmentId] = @DepartmentId AND [Name] = @Name))
			SET @return = 1
	ELSE
		IF(EXISTS(SELECT TOP 1 1 FROM [dbo].[DepartmentServices] WHERE [DepartmentId] = @DepartmentId AND [Name] = @Name and Id <> @Id))
			SET @return = 1
	SELECT @return
END
GO