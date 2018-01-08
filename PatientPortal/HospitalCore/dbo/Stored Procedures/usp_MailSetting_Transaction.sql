CREATE PROC [dbo].[usp_MailSetting_Transaction]
(
	@Action CHAR(1) = 'I',
	@Id TINYINT = 1,
	@Name NVARCHAR(256) = '',
	@Email VARCHAR(256) = '',
	@Pwd VARCHAR(60) = '',
	@Host VARCHAR(150) = '',
	@Port NUMERIC(3,0) = '',
	@IsSSL BIT = 1
)
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED
	DECLARE @return INT = 0

	BEGIN TRY
		BEGIN TRAN;
		
			IF @Action = 'I' --INSERT
			BEGIN
				INSERT [dbo].[MailSetting] VALUES(@Name, @Email, @Pwd, @Host, @Port, @IsSSL)

				SET @return = SCOPE_IDENTITY()
			END

			IF @Action = 'U' --UPDATE
			BEGIN
				UPDATE [dbo].[MailSetting]
				SET [Name] = @Name, [Email] = @Email, [Pwd] = @Pwd, [Host] = @Host, [Port] = @Port, [IsSSL] = @IsSSL
				WHERE [Id] = @Id  

				SET @return = @Id
			END

			IF @Action = 'D' --DELETE
			BEGIN
				
				DELETE FROM [dbo].[MailSetting]
				WHERE [Id] = @Id

				SET @return = @Id
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