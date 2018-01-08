CREATE PROCEDURE [dbo].[usp_User_HasScheduleExamine]
	@Search nvarchar(250) = ''
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED

	BEGIN TRY
		SELECT DISTINCT 
				dbo.Users.*
		FROM    dbo.Schedule INNER JOIN
				dbo.Users ON dbo.Schedule.UserId = dbo.Users.Id
		WHERE   (dbo.Users.IsDoctor = 1)
				AND (Name like '%' + @Search + '%' OR @Search is null)
				OR (Tags like '%' + @Search + '%' OR @Search is null)
				AND IsExamine = 1
				AND DATEDIFF(DAY, GETDATE(), [start])>= 0
				AND DATEDIFF(DAY, [start], DATEADD(day,2,getdate()))>= 0

	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT <> 0 
		BEGIN
			RETURN NULL
		END
	END CATCH
END
GO


