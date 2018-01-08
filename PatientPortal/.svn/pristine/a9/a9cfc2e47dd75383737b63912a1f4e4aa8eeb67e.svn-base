CREATE PROCEDURE [dbo].[usp_UserNotification_Transaction]
	@Action CHAR(1) = 'I',
	@Id varchar(128),
	@Detail nvarchar(300),
	@Date varchar(10),
	@Time varchar(8),
	@UserId nvarchar(128),
	@IsRead bit
AS
BEGIN
DECLARE @return bit = 0
BEGIN TRY
	BEGIN TRAN;
	IF(@Action = 'I')
	BEGIN
		INSERT INTO [dbo].[UserNotification](Id, Detail, [Date],[Time], [UserId], [IsRead]) 
		VALUES(@Id, @Detail, @Date, @Time, @UserId, @IsRead)
		SET @return = 1
	END
	ELSE
	BEGIN
		UPDATE [dbo].[UserNotification]
		SET		Detail = @Detail, [Date] = @Date, [Time] = @Time, [UserId] = @UserId, [IsRead] = @IsRead
		WHERE Id = @Id
		SET @return = 1
	END
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
