CREATE PROCEDURE [dbo].[usp_WorkflowState]
	@Id SMALLINT,
	@WorkflowId TINYINT
AS BEGIN
	BEGIN TRY
		IF(@Id > 0) ---get 'WorkflowState' by Id
		BEGIN
			SELECT	wfs.*, wf.Name as WorkflowName
			FROM	[dbo].[WorkflowState] wfs
					INNER JOIN [dbo].[Workflow] wf on wf.Id = wfs.WorkflowId
			WHERE	wfs.Id = @Id
		END
		BEGIN       ---get 'WorkflowState' by workflowId
			IF(@WorkflowId > 0)
			BEGIN
				SELECT	wfs.*, wf.Name as WorkflowName
				FROM	[dbo].[WorkflowState] wfs
						INNER JOIN [dbo].[Workflow] wf on wf.Id = wfs.WorkflowId
				WHERE   wfs.WorkflowId = @WorkflowId
			END
			ELSE
			BEGIN
				SELECT	wfs.*, wf.Name as WorkflowName
				FROM	[dbo].[WorkflowState] wfs
						INNER JOIN [dbo].[Workflow] wf on wf.Id = wfs.WorkflowId
			END
		END

	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT <> 0
			BEGIN
				RETURN NULL
			END
	END CATCH
END
