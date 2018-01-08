CREATE PROCEDURE [dbo].[usp_PostStateHistory_Transaction]
	@Action CHAR(1) = 'I',
	@PostId INT,
	@WorkflowStateId TINYINT,
	@UserId INT,
	@Note NVARCHAR(500)
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED

	DECLARE @return bit = 1
	BEGIN TRY
		BEGIN TRAN

			IF @Action = 'I' -- INSERT
			BEGIN
				INSERT INTO [dbo].[PostStateHistory]
				VALUES(@PostId, @WorkflowStateId, @UserId, @Note, [dbo].[ufnGetDate]())
			END				
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT <> 0
			BEGIN
				ROLLBACK TRAN
				SET @return = 0
			END
	END CATCH
	SELECT @return
END
