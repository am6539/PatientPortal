CREATE PROCEDURE [dbo].[usp_spa_QA]
	@pageIndex TINYINT = 1, 
	@numberInPage TINYINT = 10, 
	@Search nvarchar(250) = '',
	@totalItem int out
AS BEGIN
	BEGIN TRY
	SET NOCOUNT ON
		SET TRANSACTION ISOLATION LEVEL READ COMMITTED

		BEGIN
				SELECT  *, ROW_NUMBER() OVER (ORDER BY [Date]) AS RowNum INTO #tmpPost FROM (
					
				SELECT 
					q.*,
					u.[Name] AS DoctorName
				FROM 
					[dbo].QA q, 
					[dbo].Users u
				WHERE 
					q.DoctorId = u.Id
					AND ((q.Title like '%' + @Search + '%' OR  @Search is null OR @Search = '')
					OR (q.Question like N'%' + @Search +'%' OR  @Search is null OR @Search = ''))

				) AS tmp
				

				set @totalItem = (SELECT count(*) FROM #tmpPost)
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

GO
