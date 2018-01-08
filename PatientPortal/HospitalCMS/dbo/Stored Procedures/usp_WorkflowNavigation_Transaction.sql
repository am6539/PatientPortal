CREATE PROCEDURE [dbo].[usp_WorkflowNavigation_Transaction]
	@Action VARCHAR(1) = 'I',
	@WorkflowStateId SMALLINT,
	@NextWorkflowStateId SMALLINT
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED

	DECLARE @return BIT = 1
	BEGIN TRY
		BEGIN TRAN
			IF @Action = 'I' -- INSERT
			BEGIN
				IF NOT EXISTS( SELECT TOP 1 1 FROM [dbo].[Post] WHERE [WorkflowStateId] = @WorkflowStateId)
				BEGIN
					DELETE FROM [dbo].[WorkflowNavigation] WHERE [WorkflowStateId] = @WorkflowStateId

					INSERT INTO [dbo].[WorkflowNavigation]
					VALUES(@WorkflowStateId, @NextWorkflowStateId)
				END
				ELSE
					SET @return = 0
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
