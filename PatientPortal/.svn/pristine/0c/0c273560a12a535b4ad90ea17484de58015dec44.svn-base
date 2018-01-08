CREATE PROCEDURE [dbo].[usp_EmailMarketing]
	@Id INT
AS
	IF(@Id > 0)
	BEGIN
		SELECT * FROM [dbo].[EmailMarketing]
		WHERE [Id] = @Id
	END
	ELSE
	BEGIN
		SELECT * FROM [dbo].[EmailMarketing]
	END
RETURN 0