CREATE PROCEDURE [dbo].[usp_Schedule_Transaction]
	@Action CHAR(1) = 'I',
	@Id INT,
	@Title NVARCHAR(50),
	@Priority TINYINT,
	@Detail NVARCHAR(300),
	@IsAlarm BIT,
	@Start DATETIME,
	@End DATETIME,
	@Color VARCHAR(6),
	@IsExamine BIT,
	@UserId NVARCHAR(128) = ''
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED

	DECLARE @return INT = 0

	BEGIN TRY
		BEGIN TRAN
			IF @Action = 'I'
			BEGIN
				INSERT INTO [dbo].Schedule
				VALUES(@Title, @Priority, @Detail, @IsAlarm, @Start, @End, @Color, @IsExamine, @UserId)
				SET @return = SCOPE_IDENTITY()
				END
			IF @Action = 'U'
			BEGIN
				UPDATE [dbo].Schedule
				SET Title = @Title,
				[Priority] = @Priority,
				Detail = @Detail,
				IsAlarm = @IsAlarm,
				[Start] = @Start,
				[End] = @End,
				Color = @Color,
				IsExamine = @IsExamine,
				UserId = @UserId
				WHERE Id = @Id

				SET @return = @Id
				END
			IF @Action = 'D'
				BEGIN
					IF EXISTS (SELECT TOP 1 1 FROM [dbo].Schedule WHERE Id = @Id)
						BEGIN
							DELETE FROM [dbo].Schedule
							WHERE Id = @Id

							SET @return = @Id
						END
					ELSE
						SET @return = 0
					END
		COMMIT TRAN
	END TRY

	BEGIN CATCH
		IF @@TRANCOUNT <> 0
			BEGIN
				ROLLBACK TRAN
				SET @return = 0
			END
	END CATCH
	SELECT @return;
END