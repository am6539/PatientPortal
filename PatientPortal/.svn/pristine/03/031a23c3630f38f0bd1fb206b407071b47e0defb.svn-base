CREATE PROC [dbo].[usp_SurveyQuestions_Transaction]
(
	@Action CHAR(1) = 'I',
	@Id VARCHAR(128) = '',
	@SurveyId VARCHAR(128) = '',
	@Question NVARCHAR(300) = '',
	@Type TINYINT,
	@IsRequireds BIT = 0,
	@IsRandomize BIT = 0
)
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED
	DECLARE @return INT = 0

	BEGIN TRY
		BEGIN TRAN;
			IF @Action = 'I' --INSERT
			BEGIN
				INSERT [dbo].[SurveyQuestions] VALUES(@Id, @SurveyId, @Question, @Type, @IsRequireds, @IsRandomize)

				SET @return = 1
			END

			IF @Action = 'U' --UPDATE
			BEGIN
				UPDATE [dbo].[SurveyQuestions]
				SET [SurveyId] = @SurveyId, [Question] = @Question, [Type] = @Type, [IsRequireds] = @IsRequireds, [IsRandomize] = @IsRandomize
				WHERE [Id] = @Id  

				SET @return = 1
			END

			IF @Action = 'D' --DELETE
			BEGIN
				BEGIN
					DELETE FROM [dbo].[SurveyQuestions]
					WHERE [Id] = @Id

					SET @return = 1
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