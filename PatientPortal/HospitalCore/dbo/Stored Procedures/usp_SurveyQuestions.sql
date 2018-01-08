CREATE PROCEDURE [dbo].[usp_SurveyQuestions]
	@SurveyId VARCHAR(128)
AS
	IF(@SurveyId <> '')
	BEGIN
		SELECT * FROM [dbo].[SurveyQuestions]
		WHERE [SurveyId] = @SurveyId
	END
RETURN 0