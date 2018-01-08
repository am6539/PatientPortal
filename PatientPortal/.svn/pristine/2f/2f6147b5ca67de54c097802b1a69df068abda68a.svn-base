CREATE PROC [dbo].[usp_Message]
(
	@FolderId TINYINT = 1,
	@UserId NVARCHAR(128) = '',
	@PageIndex INT,
	@NumberInPage INT,
	@TotalItem INT OUT
)
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED

	BEGIN TRY
		-- Folder: Inbox, Sent, Draff, Trash
		SELECT *, ROW_NUMBER() OVER (ORDER BY [Date],[Id] DESC) AS RowNumb 
		INTO #DataTMP
		FROM (SELECT * FROM [dbo].[Message]
		WHERE [FolderId] = @FolderId AND ([SenderId] = @UserId OR [ReceiverId] = @UserId)) AS Tmp

		SELECT @TotalItem = COUNT([Id]) FROM #DataTMP

		-- Paging
		SELECT * FROM #DataTMP
		WHERE RowNum BETWEEN (@PageIndex - 1) * @NumberInPage + 1
				AND @PageIndex * @NumberInPage ;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT <> 0 
		BEGIN
			RETURN NULL
		END
	END CATCH
END