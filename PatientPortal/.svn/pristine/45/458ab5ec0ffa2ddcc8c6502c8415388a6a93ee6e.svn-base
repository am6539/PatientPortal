CREATE PROCEDURE [dbo].[usp_SurveyAnswers]
	@QuestionId VARCHAR(128)
AS
	IF(@QuestionId <> '')
	BEGIN
		SELECT * FROM [dbo].[SurveyAnswers]
		WHERE [QuestionId] = @QuestionId
	END
RETURN 0