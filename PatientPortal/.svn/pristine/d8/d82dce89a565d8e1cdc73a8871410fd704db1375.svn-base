CREATE PROCEDURE [dbo].[usp_Category_CheckIsUsed]
	@Id TINYINT
AS
BEGIN
	DECLARE @return BIT = 0
	IF(EXISTS(SELECT TOP 1 1 FROM [dbo].[Category] WHERE [ParentId] = @Id) OR EXISTS(SELECT TOP 1 1 FROM [dbo].[Post] WHERE [CategoryId] = @Id))
		SET @return = 1
	
	SELECT @return
END
