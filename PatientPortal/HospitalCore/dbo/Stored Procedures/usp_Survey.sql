CREATE PROCEDURE [dbo].[usp_Survey]
	@Id VARCHAR(128)
AS
	IF(@Id <> '')
	BEGIN
		SELECT * FROM [dbo].[Survey]
		WHERE [Id] = @Id
	END
	ELSE
	BEGIN
		SELECT * FROM [dbo].[Survey]
	END
RETURN 0