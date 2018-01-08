CREATE PROC [dbo].[usp_ArticleComment] (
	@TypeGet tinyint = 0, -- 0: get all comment by ArticleId ; 1: Get comment by Id
	@Id INT = 0,
	@ArticleId INT = 0
)
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED

	BEGIN TRY
		IF @TypeGet = 0
			SELECT	a.*, u.Name AS Author, u.[Image] as ImageProfile 
			FROM	[dbo].[ArticleComment] a INNER JOIN
					[dbo].[Users] u ON a.CreatedUser = u.Id
			WHERE [ArticleId] = @ArticleId
		ELSE If @TypeGet = 1
			SELECT	a.*, u.Name AS Author, u.[Image] as ImageProfile 
			FROM	[dbo].[ArticleComment] a INNER JOIN
					[dbo].[Users] u ON a.CreatedUser = u.Id
			WHERE	a.[Id] = @Id AND [ArticleId] = @ArticleId

	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT <> 0 
		BEGIN
			RETURN NULL
		END
	END CATCH
END