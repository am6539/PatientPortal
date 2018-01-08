CREATE PROC [dbo].[usp_Article_Transaction]
(
	@Action CHAR(1) = 'I',
	@Id INT = 1,
	@Date datetime,
	@Title NVARCHAR(150) = '',
	@Detail NVARCHAR(1000) = '',
	@PatientId NVARCHAR(128) = 0,
	@Status TINYINT = 1,
	@IsClosed BIT
)
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED
	DECLARE @return INT = 0
	DECLARE @CurrentDate SMALLDATETIME

	BEGIN TRY
		BEGIN TRAN;
			SET @CurrentDate = GETDATE()

			IF @Action = 'I' --INSERT
			BEGIN
				INSERT [dbo].[Article]
				VALUES(@CurrentDate, @Title, @Detail, @PatientId, @Status, @IsClosed)

				SET @return = SCOPE_IDENTITY()
			END

			IF @Action = 'U' --UPDATE
			BEGIN
				IF NOT EXISTS(SELECT TOP 1 1 FROM [dbo].[ArticleComment] WHERE [ArticleId] = @Id)
				BEGIN
					UPDATE [dbo].[Article]
					SET [Title] = @Title, [Detail] = @Detail, [Status] = @Status, [IsClosed] = @IsClosed
					WHERE [Id] = @Id  

					SET @return = @Id
				END
				ELSE
					SET @return = 0
			END

			IF @Action = 'D' --DELETE
			BEGIN
				IF NOT EXISTS(SELECT TOP 1 1 FROM [dbo].[ArticleComment] WHERE [ArticleId] = @Id)
				BEGIN	
					-- Article Comment Table
					DELETE FROM [dbo].[ArticleComment] WHERE [ArticleId] = @Id

					-- Article Table
					DELETE FROM [dbo].[Article] WHERE [Id] = @Id

					SET @return = @Id
				END
				ELSE
					SET @return = 0
			END

			COMMIT TRAN;
	END TRY
	BEGIN CATCH
		DECLARE @ErrorSeverity INT,
				@ErrorNumber   INT,
				@ErrorMessage nvarchar(4000),
				@ErrorState INT,
				@ErrorLine  INT,
				@ErrorProc nvarchar(200)
		-- Grab error information from SQL functions
		SET @ErrorSeverity = ERROR_SEVERITY()
		SET @ErrorNumber   = ERROR_NUMBER()
		SET @ErrorMessage  = ERROR_MESSAGE()
		SET @ErrorState    = ERROR_STATE()
		SET @ErrorLine     = ERROR_LINE()
		SET @ErrorProc     = ERROR_PROCEDURE()
		SET @ErrorMessage  = 'Problem updating''s information.' + CHAR(13) + 'SQL Server Error Message is: ' + CAST(@ErrorNumber AS VARCHAR(10)) + ' in procedure: ' + @ErrorProc + ' Line: ' + CAST(@ErrorLine AS VARCHAR(10)) + ' Error text: ' + @ErrorMessage
		-- Not all errors generate an error state, to set to 1 if it's zero
		IF @ErrorState  = 0
		SET @ErrorState = 1
		-- If the error renders the transaction as uncommittable or we have open transactions, we may want to rollback
		IF @@TRANCOUNT > 0
		BEGIN
				-- Print 'Rollback transaction'
				ROLLBACK TRANSACTION
		END
		RAISERROR (@ErrorMessage , @ErrorSeverity, @ErrorState, @ErrorNumber)
		SET  @return = 0
	END CATCH
	SELECT @return;
END