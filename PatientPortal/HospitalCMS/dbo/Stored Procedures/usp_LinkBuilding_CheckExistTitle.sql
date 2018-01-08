CREATE PROCEDURE [dbo].[usp_LinkBuilding_CheckExistTitle]
	@Title  NVARCHAR(150),
	@Id SMALLINT
AS
BEGIN
	DECLARE @return BIT = 0;
	IF(@Id = 0)
	BEGIN
		IF(EXISTS(SELECT	TOP 1 1
					  FROM		[dbo].[LinkBuilding]
					  WHERE		[Title] = @Title))
			SET @return =1
	END
	IF(EXISTS(SELECT	TOP 1 1
					  FROM		[dbo].[LinkBuilding]
					  WHERE		[Title] = @Title and Id != @Id))
			SET @return =1
SELECT @return
END