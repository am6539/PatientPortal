﻿CREATE PROCEDURE [dbo].[usp_User_ChangePassword]
	@Id INT,
	@Email NVARCHAR(256),
	@NewPassword VARCHAR(60)
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED
	DECLARE @return BIT = 1

	BEGIN TRY
		BEGIN TRAN
			IF EXISTS (SELECT TOP 1 1 FROM [dbo].[Users] WHERE [Email] = @Email)
				BEGIN
					UPDATE [dbo].[Users]
					SET [PasswordHash] = @NewPassword
					WHERE [Email] = @Email
				END
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