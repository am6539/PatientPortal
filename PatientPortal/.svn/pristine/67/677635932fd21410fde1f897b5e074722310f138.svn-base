CREATE PROC [dbo].[usp_OfferAdvise_Transaction]
(
	@Action CHAR(1) = 'I',
	@Date SMALLDATETIME,
	@Id INT = 1,
	@Detail NVARCHAR(MAX) = '',
	@PatientId NVARCHAR(128),
	@Tag NVARCHAR(150),
	@Status TINYINT = 0,
	@Message NVARCHAR(MAX) = '',
	@IdNotificate NVARCHAR(128)
)
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED
	DECLARE @return INT = 0

	BEGIN TRY
		BEGIN TRAN;
			--DECLARE @Date SMALLDATETIME

			IF @Action = 'I' --INSERT
			BEGIN
				SET @Date = GETDATE()

				INSERT [dbo].[OfferAdvise] ([Date], Detail, PatientId, Tag,[Status], [Message])
				VALUES(@Date, @Detail, @PatientId, @Tag, @Status, @Message)

				SET @return = SCOPE_IDENTITY()
			END

			IF @Action = 'U' --UPDATE
			BEGIN
				UPDATE [dbo].[OfferAdvise]
				SET [Detail] = @Detail, Tag = @Tag,
				[Status] = @Status,
				[Message] = @Message
				WHERE [Id] = @Id  

				SET @return = @Id

				---insert Notification if OfferAdvise is not approved
				IF(@Status = 3)
				BEGIN
					INSERT [dbo].[UserNotification](Id, Detail, [Date],[Time], [UserId], [IsRead])
					VALUES(@IdNotificate, @Message, CONVERT(VARCHAR(10), GETDATE(), 103), convert(VARCHAR(8), GETDATE(), 108), @PatientId, 0)
				END
			END

			IF @Action = 'D' --DELETE
			BEGIN
				BEGIN
					DELETE FROM [dbo].[OfferAdvise]
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