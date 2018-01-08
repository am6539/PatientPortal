CREATE PROC [dbo].[usp_AppointmentLog_Search](
	@Status INT = 0,
	@FromDate DATE = '',
	@ToDate DATE = ''
)
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED
	BEGIN TRY
		SELECT * FROM [dbo].[AppointmentLog] l
		WHERE 
			(l.[Status] = @Status OR @Status IS NULL)
			AND
			(
				(l.[Date] BETWEEN @FromDate AND @ToDate)
				OR
				(@FromDate IS NULL AND @ToDate IS NULL)
				OR
				(@FromDate IS NULL AND l.[Date] <= @ToDate)
				OR
				(@ToDate IS NULL AND l.[Date] >= @FromDate)
			)
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT <> 0 
		BEGIN
			RETURN NULL
		END
	END CATCH
END