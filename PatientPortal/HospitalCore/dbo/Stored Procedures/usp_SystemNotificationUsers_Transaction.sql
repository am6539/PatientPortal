CREATE PROCEDURE [dbo].[usp_SystemNotificationUsers_Transaction]
	@Action CHAR(1) = 'I',
	@Id INT,
	@UserId NVARCHAR(128),
	@IsRead BIT = 0
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED

	DECLARE @return bit = 1
	BEGIN TRY
		BEGIN TRAN;
		
		IF @Action = 'I' --INSERT
		BEGIN
			INSERT [dbo].[SystemNotificationUsers](Id, UserId, IsRead)
			VALUES(@Id, @UserId, @IsRead)
		END

		IF @Action = 'U' --UPDATE
		BEGIN
			UPDATE [dbo].[SystemNotificationUsers]
			SET IsRead = @IsRead
			WHERE [Id] = @Id  AND [UserId] = @UserId
		END

		IF @Action = 'D' --DELETE
		BEGIN
			DELETE FROM [dbo].[SystemNotificationUsers] WHERE [Id] = @Id  AND [UserId] = @UserId
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
	SELECT @return
	
END