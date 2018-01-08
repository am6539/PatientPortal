CREATE PROCEDURE [dbo].[usp_Workflow_CheckExistName]
	@Name  NVARCHAR(50),
	@Id TINYINT
AS
BEGIN
	DECLARE @return BIT = 0;

	IF(@Id = 0)
	BEGIN
		IF(EXISTS(SELECT TOP 1 1 FROM [dbo].[Workflow] WHERE [Name] = @Name))
		BEGIN
			SET @return= 1
		END
	END
	ELSE
	BEGIN
		IF(EXISTS(SELECT TOP 1 1 FROM [dbo].[Workflow] WHERE [Name] = @Name and Id <> @Id))
		BEGIN
			SET @return= 1
		END
	END

	SELECT @return
END
GO