CREATE PROCEDURE [dbo].[usp_Module_CheckExistTitle]
	@Title  NVARCHAR(128),
	@Id SMALLINT
AS
BEGIN
	DECLARE @return BIT = 0

	print @Id
	IF(@Id = 0)
		IF(EXISTS(SELECT TOP 1 1 FROM [dbo].[Module] WHERE [Title] = @Title))
			SET @return = 1
	ELSE
		IF(EXISTS(SELECT TOP 1 1 FROM [dbo].[Module] WHERE [Title] = @Title and Id <> @Id))
			SET @return = 1
	SELECT @return
END
GO