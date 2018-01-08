CREATE PROC [dbo].[usp_Article]
	@Id int,
	@patientId NVARCHAR(128) = ''
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED

	BEGIN TRY
		IF @Id = 0 
			SELECT	a.*, u.Name as AuthorName, u.[Image] as ImageProfile,  (SELECT COUNT(b.Id) from ArticleComment b where ArticleId = a.Id) as CountComments
			FROM	[dbo].[Article] a inner join
					[dbo].[Users] u on a.PatientId = u.Id
			WHERE	a.PatientId = @patientId OR @patientId is NULL OR @patientId = ''
			
		ELSE
			SELECT  a.*, u.Name as AuthorName, u.[Image] as ImageProfile , (SELECT COUNT(b.Id) from ArticleComment b where ArticleId = a.Id) as CountComments
			FROM	[dbo].[Article] a inner join
					[dbo].[Users] u on a.PatientId = u.Id
			WHERE	a.Id = @Id
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT <> 0 
		BEGIN
			RETURN NULL
		END
	END CATCH
END