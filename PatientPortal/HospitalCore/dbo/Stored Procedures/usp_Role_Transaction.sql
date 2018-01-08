CREATE PROCEDURE [dbo].[usp_Role_Transaction]
	@Action CHAR(1) = 'I',
	@Id NVARCHAR(128),
	@Name NVARCHAR(128)
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED
	DECLARE @return BIT = 1

	BEGIN TRY
		BEGIN TRAN
			IF @Action = 'I'
				SET @Id = CAST(NEWID() as NVARCHAR(128));
				IF NOT EXISTS (SELECT TOP 1 * FROM [dbo].[Role] WHERE Name = @Name)
					INSERT INTO [dbo].[Role]
					VALUES(@Id, @Name)
				ELSE
					SET @return = 0
			IF @Action = 'U'
				IF EXISTS (SELECT TOP 1 * FROM [dbo].[Role] WHERE Id = @Id)
					UPDATE [dbo].[Role]
					SET Name = @Name
					WHERE Id = @Id
				ELSE
					SET @return = 0
			IF @Action = 'D'
				IF EXISTS (SELECT TOP 1 * FROM [dbo].[Role] WHERE Id = @Id)
					DELETE FROM [dbo].[Role]
					WHERE Id = @Id
				ELSE
					SET @return = 0
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT <> 0
			BEGIN
				ROLLBACK TRAN
				SET @return = 0
			END
	END CATCH
	SELECT @return
END
