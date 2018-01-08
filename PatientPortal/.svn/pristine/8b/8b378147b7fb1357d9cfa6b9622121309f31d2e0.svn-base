CREATE PROCEDURE [dbo].[usp_WorkflowState_CheckExistName]
	@Id SMALLINT,
	@Name NVARCHAR(50) = '',
	@WorkflowId TINYINT
AS
BEGIN
	DECLARE @return BIT = 0;

	IF(@Id = 0)
		IF(EXISTS(SELECT TOP 1 1 FROM [dbo].[WorkflowState] WHERE [Name] = @Name and [WorkflowId] = @WorkflowId))
			BEGIN
				SET @return = 1;
			END
	IF(EXISTS(SELECT TOP 1 1 FROM [dbo].[WorkflowState] WHERE [Name] = @Name and [WorkflowId] = @WorkflowId and Id != @Id))
			BEGIN
				SET @return = 1;
			END
		
	SELECT @return
END
GO