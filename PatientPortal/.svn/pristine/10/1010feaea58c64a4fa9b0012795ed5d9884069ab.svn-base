CREATE PROCEDURE [dbo].[usp_Feature_CheckExistTitle]
	@Title  NVARCHAR(50),
	@Id TINYINT
AS
BEGIN
	DECLARE @return BIT = 0

	print @Id
	IF(@Id = 0)
		IF(EXISTS(SELECT TOP 1 1 FROM [dbo].[Feature] WHERE [Title] = @Title))
			SET @return = 1
	ELSE
		IF(EXISTS(SELECT TOP 1 1 FROM [dbo].[Feature] WHERE [Title] = @Title and Id <> @Id))
			SET @return = 1
	SELECT @return
END
GO