CREATE PROC [dbo].[usp_Internal_Dashboard]
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED

	BEGIN TRY
		SELECT COUNT([Id]) AS [Count] FROM [dbo].[Users] WHERE [Id] NOT IN (SELECT DISTINCT [UserId] FROM [dbo].[UserRole])-- Just Created & No Role
		UNION ALL
		SELECT COUNT([Id]) FROM [dbo].[Article] WHERE [Status] = 1 AND [Id] NOT IN (SELECT DISTINCT [ArticleId] FROM [dbo].[ArticleComment]) -- Just Created & No Comment
		UNION ALL
		SELECT COUNT([Id]) FROM [dbo].[OfferAdvise] WHERE [Status] = 1 -- Just Created
		UNION ALL
		SELECT COUNT([Id]) FROM [dbo].[AppointmentLog] WHERE [Status] = 1 -- Just Created
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT <> 0 
		BEGIN
			RETURN NULL
		END
	END CATCH
END