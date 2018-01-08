CREATE PROCEDURE [dbo].[usp_Workflow_Transaction]
	@Action VARCHAR(1) = 'I',
	@Id TINYINT,
	@Name NVARCHAR(50)
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED

	DECLARE @return BIT = 1
	BEGIN TRY
		BEGIN TRAN
			IF @Action = 'I' -- INSERT
			BEGIN
				INSERT INTO [dbo].[Workflow]
				VALUES(@Name)
			END

			IF @Action = 'U' -- UPDATE
			BEGIN
				UPDATE [dbo].[Workflow]
				SET [Name] = @Name
				WHERE [Id] = @Id
			END

			IF @Action = 'D' -- DELETE
			BEGIN
				IF NOT EXISTS( SELECT TOP 1 1 FROM [dbo].[WorkflowState] WITH(INDEX(idxWorkflowStateWorkflow)) WHERE [WorkflowId] = @Id)
				BEGIN
					DELETE FROM [dbo].[Workflow]
					WHERE [Id] = @Id
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
