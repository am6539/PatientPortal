CREATE PROCEDURE [dbo].[usp_WorkflowState_CheckIsUsed]
	@Id SMALLINT
AS
BEGIN
	DECLARE @return BIT = 0;
	IF(EXISTS(SELECT TOP 1 1 FROM [dbo].[WorkflowNavigation] WHERE [WorkflowStateId] = @Id or [NextWorkflowStateId] = @Id))
		SET @return = 1

	SELECT @return
END
