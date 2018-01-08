CREATE PROCEDURE [dbo].[usp_PostStateHistory]
(
	@PostId INT	
)
AS BEGIN
	BEGIN TRY
		SELECT * FROM [dbo].[PostStateHistory] WHERE [PostId] = @PostId
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT <> 0
			BEGIN
				RETURN NULL
			END
	END CATCH
END
