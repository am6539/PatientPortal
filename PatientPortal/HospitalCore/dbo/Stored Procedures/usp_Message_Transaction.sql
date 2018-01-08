CREATE PROC [dbo].[usp_Message_Transaction]
(
	@Action CHAR(1) = 'I',
	--Message
	@Id INT,
	@FolderId TINYINT = 1,
	@Subject NVARCHAR(250) = '',
	@Date SMALLDATETIME,
	@SenderId NVARCHAR(128) = '',
	@ReceiverId NVARCHAR(128) = '',
	@IsRead BIT = 0,
	@IsSend BIT = 0,
	@IsPrioriry BIT = 0,
	--MessageContent
	@Detail NVARCHAR(MAX) = '',
	--MessageRecipient
	@ListReceiverId INTLIST READONLY
)
AS BEGIN


	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED
	DECLARE @return INT = 0

	BEGIN TRY
		BEGIN TRAN;
		
			-- Local Variable
			DECLARE @item INT

			IF @Action = 'I' --INSERT
			BEGIN
				SET @Date = GETDATE()

				-- Message Table
				INSERT [dbo].[Message] VALUES(@FolderId, @Subject, @Date, @SenderId, @ReceiverId, @IsRead, @IsSend, @IsPrioriry)
				SET @Id = SCOPE_IDENTITY()

				-- Message Content Table
				INSERT [dbo].[MessageContent] VALUES(@Id, @Detail)

				-- Message Recipient Table
				DECLARE cursorListReceiver CURSOR READ_ONLY FOR SELECT [Item] FROM @ListReceiverId WHERE [Item] > 0
				
				OPEN cursorListReceiver
				FETCH NEXT FROM cursorListReceiver INTO @Item
				
				WHILE @@FETCH_STATUS = 0
				BEGIN
					INSERT INTO [dbo].[MessageRecipient] VALUES(@Id, @item, 1) --Default IsUsed = True
					FETCH NEXT FROM cursorListReceiver INTO @Item
				END
				
				CLOSE cursorListReceiver
				DEALLOCATE cursorListReceiver

				SET @return = @Id
			END

			IF @Action = 'U' --UPDATE
			BEGIN
				IF @IsSend = 0 -- AVAILABLE UPDATE WHEN EMAIL IS NOT SENT
				BEGIN
					-- Message Table
					UPDATE [dbo].[Message]
					SET [FolderId] = @FolderId, [Subject] = @Subject, [ReceiverId] = @ReceiverId, [IsPriority]  = @IsPrioriry
					WHERE [Id] = @Id  

					-- Message Content Table
					UPDATE [dbo].[MessageContent] SET [Detail] = @Detail WHERE [MessageId] = @Id

					-- Message Recipient Table
					DELETE FROM [dbo].[MessageRecipient] WHERE [MessageId] = @Id
				
					DECLARE cursorListReceiver CURSOR READ_ONLY FOR SELECT [Item] FROM @ListReceiverId WHERE [Item] > 0
				
					OPEN cursorListReceiver
					FETCH NEXT FROM cursorListReceiver INTO @Item
				
					WHILE @@FETCH_STATUS = 0
					BEGIN
						INSERT INTO [dbo].[MessageRecipient] VALUES(@Id, @item, 1) --Default IsUsed = True
						FETCH NEXT FROM cursorListReceiver INTO @Item
					END
				
					CLOSE cursorListReceiver
					DEALLOCATE cursorListReceiver

					SET @return = @Id
				END
			END

			IF @Action = 'D' --DELETE
			BEGIN
				-- Message Content Table
				DELETE FROM [dbo].[MessageContent] WHERE  [MessageId] = @Id

				-- Message Recipient Table
				DELETE FROM [dbo].[MessageRecipient] WHERE [MessageId] = @Id

				-- Message Table
				DELETE FROM [dbo].[Message] WHERE [Id] = @Id

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