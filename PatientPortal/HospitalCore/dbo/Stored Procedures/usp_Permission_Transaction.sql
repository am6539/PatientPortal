CREATE PROCEDURE [dbo].[usp_Permission_Transaction]
	@Action CHAR(1) = 'I',
	@RoleId SMALLINT,
	@ModuleId SMALLINT,
	@IsRead BIT,
	@IsWrite BIT,
	@IsCreate BIT,
	@IsModify BIT,
	@IsDestroy BIT,
	@IsPrint BIT
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED
	DECLARE @return BIT = 1

	BEGIN TRY
		BEGIN TRAN
			IF @Action = 'I'
				IF NOT EXISTS (SELECT TOP 1 * FROM [dbo].Permission WHERE RoleId = @RoleId AND ModuleId = @ModuleId)
					INSERT INTO [dbo].Permission
					VALUES(@RoleId, @ModuleId, @IsRead, @IsWrite, @IsCreate, @IsModify, @IsDestroy, @IsPrint)
				ELSE
					SET @return = 0
			IF @Action = 'U'
				IF NOT EXISTS (SELECT TOP 1 * FROM [dbo].Permission WHERE RoleId = @RoleId AND ModuleId = @ModuleId)
					UPDATE [dbo].Permission
					SET IsRead = @IsRead,
					IsWrite = @IsWrite,
					IsCreate = @IsCreate,
					IsModify = @IsModify,
					IsDestroy = @IsDestroy,
					IsPrint = @IsPrint
					WHERE RoleId = @RoleId
					AND ModuleId = @ModuleId
				ELSE
					SET @return = 0
			IF @Action = 'D'
				IF NOT EXISTS (SELECT TOP 1 * FROM [dbo].Permission WHERE RoleId = @RoleId AND ModuleId = @ModuleId)
					DELETE FROM [dbo].Permission
					WHERE RoleId = @RoleId
					AND ModuleId = @ModuleId
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
