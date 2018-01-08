CREATE PROCEDURE [dbo].[usp_spa_User]
	@Id NVARCHAR(128) = '',
	@Type tinyint = 0,
	@pageIndex TINYINT = 1, 
	@numberInPage TINYINT = 10, 
	@Search nvarchar(250) = '',
	@totalItem int out
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED

	BEGIN TRY
	IF(@Id <> '')
		SELECT * FROM [dbo].[Users]
		WHERE Id = @Id
	ELSE
	BEGIN
		IF(@Type = 1)
			SELECT * FROM [dbo].[Users]
			WHERE IsAdmin = 1 AND (Name like '%' + @Search + '%' OR @Search is null OR @Search = N'''')
		IF(@Type = 2)
			SELECT *, ROW_NUMBER() OVER (ORDER BY UserName) AS RowNum INTO #tmpPost FROM (
				SELECT 
					up.* , u.Name, u.[Image], u.UserName 
				FROM 
					[dbo].[UserProfile] up
					INNER JOIN [dbo].[Users] u ON up.UserId = u.Id 
				WHERE 
					IsDoctor = 1 
					AND (u.Name like '%' + @Search + '%' OR @Search is null OR @Search = N'''')
					AND (u.Tags like '%' + @Search + '%' OR @Search is null OR @Search = N'''')
			) AS tmp

			SET @totalItem = (SELECT count(*) FROM #tmpPost)
				SELECT  *
				FROM	#tmpPost
				WHERE   RowNum BETWEEN (@PageIndex - 1) * @numberInPage + 1
						AND @PageIndex * @numberInPage ;
	END
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT <> 0 
		BEGIN
			RETURN NULL
		END
	END CATCH
END
