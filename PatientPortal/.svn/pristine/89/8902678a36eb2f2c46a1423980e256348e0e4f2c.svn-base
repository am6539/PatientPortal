CREATE PROCEDURE [dbo].[usp_spa_Schedule]
	@Id INT = 0,
	@UserId NVARCHAR(128) = '',
	@Start DATETIME,
	@End DATETIME
AS
BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED

	BEGIN TRY
		IF(@Id > 0)
			SELECT *
			FROM [dbo].Schedule
			WHERE Id = @Id
			AND UserId = @UserId
		ELSE
			SELECT *
			FROM [dbo].Schedule
			WHERE UserId = @UserId
			AND DATEDIFF(DAY,@Start , [start])>= 0
			AND DATEDIFF(DAY, [End], @End)>= 0
			AND IsExamine = 1
	END TRY

	BEGIN CATCH
		IF @@TRANCOUNT <> 0
			RETURN NULL
	END CATCH
END
GO

