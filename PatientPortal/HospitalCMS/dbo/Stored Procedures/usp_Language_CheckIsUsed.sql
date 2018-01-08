CREATE PROCEDURE [dbo].[usp_Language_CheckIsUsed]
	@Id TINYINT
AS
BEGIN
	DECLARE @return BIT = 0;
	IF(EXISTS(SELECT TOP 1 1 FROM [dbo].[PostTrans] WHERE [LanguageId] = @Id))
		SET @return = 1

	SELECT @return
END
