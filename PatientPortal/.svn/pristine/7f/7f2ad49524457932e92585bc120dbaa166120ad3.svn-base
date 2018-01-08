CREATE PROC [dbo].[usp_EmailMarketing_Transaction]
(
	@Action CHAR(1) = 'I',
	@Id INT = 1,
	@Name NVARCHAR(128) = '',
	@Detail NVARCHAR(MAX) = '',
	@IsUsed BIT = 0,
	@CreatedUser NVARCHAR(128),
	@CreatedDate VARCHAR(20),
	@ModifiedUser NVARCHAR(128),
	@ModifiedDate VARCHAR(20)
)
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED
	DECLARE @return INT = 0

	BEGIN TRY
		BEGIN TRAN;
			IF @Action = 'I' --INSERT
			BEGIN
				INSERT [dbo].[EmailMarketing] VALUES(@Name, @Detail, @IsUsed, @CreatedUser, @CreatedDate, @ModifiedUser, @ModifiedDate)

				SET @return = SCOPE_IDENTITY()
			END

			IF @Action = 'U' --UPDATE
			BEGIN
				UPDATE [dbo].[EmailMarketing]
				SET [Name] = @Name, [Detail] = @Detail, [IsUsed] = @IsUsed, [CreatedUser] = @CreatedUser, [CreatedDate] = @CreatedDate
				WHERE [Id] = @Id  

				SET @return = @Id
			END

			IF @Action = 'D' --DELETE
			BEGIN
				BEGIN
					DELETE FROM [dbo].[EmailMarketing]
					WHERE [Id] = @Id

					SET @return = @Id
				END
			END

			COMMIT TRAN;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT <> 0 
		BEGIN
			ROLLBACK TRAN;
			SET  @return = 0
		END
	END CATCH
	SELECT @return;
END