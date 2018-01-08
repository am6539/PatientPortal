CREATE PROCEDURE [dbo].[usp_WorkflowNavigation]
	@WorkflowId smallint = 0
AS BEGIN
	BEGIN TRY
	IF(@WorkflowId > 0)
	BEGIN
		SELECT DISTINCT wfs.*
		FROM dbo.WorkflowState wf
		INNER JOIN dbo.WorkflowNavigation wfs ON wf.WorkflowId = @WorkflowId
	END
	ELSE
	BEGIN
		SELECT * FROM [dbo].[WorkflowNavigation]
	END
		
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT <> 0 
			BEGIN
				RETURN NULL
			END
	END CATCH
END
