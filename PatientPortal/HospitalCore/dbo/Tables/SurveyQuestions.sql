CREATE TABLE [dbo].[SurveyQuestions]
(
	[Id] VARCHAR(128) NOT NULL , 
	[SurveyId] VARCHAR(128) NOT NULL, 
	[Question] NVARCHAR(300) NOT NULL, 
	--Type is 1: Long text, 2:Short text, 3: Radion buttons, 4: Checkboxs, 5: NPS(Net Promoter Score) = Low score +  Hight Score
	[Type] TINYINT NOT NULL,
	[IsRequireds] BIT NOT NULL, 
    [IsRandomize] BIT NOT NULL, 
    
	CONSTRAINT [PK_SurveyQuestions] PRIMARY KEY ([Id]), 
	CONSTRAINT [FK_SurveyQuestions_Survey] FOREIGN KEY ([SurveyId]) REFERENCES [Survey]([Id]) 
)
