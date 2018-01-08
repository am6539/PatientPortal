CREATE PROCEDURE [dbo].[usp_UserNotification]
	@Id VARCHAR(128) = '',
	@UserId NVARCHAR(128) = '',
	@NumTop TINYINT = 0,
	@PageIndex TINYINT = 1, 
	@NumberInPage TINYINT = 10,
	@TotalItem int out
AS
BEGIN
	IF(@Id <> '')
	BEGIN
		SELECT * FROM [dbo].[UserNotification] WHERE Id = @Id
	END
	ELSE
	BEGIN
		IF(@NumTop <> 0)--SELECT TOP
		BEGIN
			SELECT TOP (@NumTop) *
			FROM [dbo].[UserNotification] WHERE [UserId] = @UserId
			ORDER BY [Date]
		END
		ELSE
		BEGIN--PAGING
			SELECT  *, ROW_NUMBER() OVER (ORDER BY [Date]) AS RowNum INTO #tmpNotify FROM (
				SELECT * FROM [dbo].[UserNotification] 
				WHERE [UserId] = @UserId
			)AS #tmp

			set @totalItem = (SELECT COUNT(Id) FROM #tmpNotify)
			SELECT  *
			FROM	#tmpNotify
			WHERE   RowNum BETWEEN (@PageIndex - 1) * @NumberInPage + 1
					AND @PageIndex * @NumberInPage ;
		END
	END
END
GO


