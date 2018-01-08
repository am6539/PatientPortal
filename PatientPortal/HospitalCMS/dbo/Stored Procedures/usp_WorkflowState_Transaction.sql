CREATE PROCEDURE [dbo].[usp_WorkflowState_Transaction]
	@Action VARCHAR(1) = 'I',
	@Id SMALLINT,
	@Name NVARCHAR(50) = '',
	@WorkflowId TINYINT = 0,
	@IsActive BIT = 1,
	@IsFirst BIT = 0
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED

	DECLARE @return BIT = 1
	BEGIN TRY
		BEGIN TRAN
			IF @Action = 'I' -- INSERT
			BEGIN
				INSERT INTO [dbo].[WorkflowState]
				VALUES(@Name, @WorkflowId, @IsActive, @IsFirst)
				DECLARE @newId SMALLINT = SCOPE_IDENTITY()
				IF(@IsFirst = 1)
					UPDATE	[dbo].[WorkflowState]
					SET		[IsFirst] = 0
					WHERE	[Id] <> @newId and [WorkflowId] = @WorkflowId
			END

			IF @Action = 'U' -- UPDATE
			BEGIN
				IF NOT EXISTS( SELECT TOP 1 1 FROM [dbo].[WorkflowNavigation] WHERE [WorkflowStateId] = @Id)  AND NOT EXISTS( SELECT TOP 1 1 FROM [dbo].[Post] WHERE [WorkflowStateId] = @Id)
				BEGIN
					UPDATE [dbo].[WorkflowState]
					SET [Name] = @Name, [WorkflowId] = @WorkflowId, [IsActive] = @IsActive, [IsFirst] = @IsFirst
					WHERE [Id] = @Id

					IF(@IsFirst = 1)
						UPDATE	[dbo].[WorkflowState]
						SET		[IsFirst] = 0
						WHERE	[Id] <> @Id and [WorkflowId] = @WorkflowId
				END
				ELSE
					SET @return = 0
			END

			IF @Action = 'D' -- DELETE
			BEGIN
				IF NOT EXISTS( SELECT TOP 1 1 FROM [dbo].[Post] WHERE [WorkflowStateId] = @Id)
				BEGIN
					DECLARE @wfId TINYINT = 0 
					---get workflowId by StateId
					SET @WorkflowId = (SELECT TOP 1 WorkflowId FROM [dbo].[WorkflowState] WHERE [Id] = @Id)
					---delete state
					DELETE FROM [dbo].[WorkflowState]
					WHERE [Id] = @Id

					---get all state by workflow Id
					IF(@wfId != 0)
					BEGIN
						IF NOT EXISTS( SELECT TOP 1 1 FROM [dbo].[WorkflowState] WHERE [WorkflowId] = @wfId AND [IsFirst] = 1)
						BEGIN
							DECLARE @stateId SMALLINT = (SELECT TOP 1 Id FROM [dbo].[WorkflowState] WHERE [WorkflowId] = @wfId)
							
							---update First state that have WorkflowId
							UPDATE	[dbo].[WorkflowState]
							SET		[IsFirst] = 0
							WHERE	[Id] = @stateId
						END
					END

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
