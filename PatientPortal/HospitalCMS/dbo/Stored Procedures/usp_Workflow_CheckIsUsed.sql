CREATE PROCEDURE [dbo].[usp_Workflow_CheckIsUsed]
	@Id TINYINT
AS
BEGIN
	DECLARE @return BIT = 0;
	IF(EXISTS(SELECT TOP 1 1 FROM [dbo].[WorkflowState] WHERE WorkflowId = @Id))
		SET @return = 1

	SELECT @return
END
