CREATE PROCEDURE [dbo].[usp_Module_CheckIsUsed]
	@Id TINYINT
AS
BEGIN
	DECLARE @return BIT = 0
	IF(EXISTS(SELECT TOP 1 1 FROM [dbo].[Module] WHERE [ParentId] = @Id) )
		SET @return = 1
	
	SELECT @return
END
