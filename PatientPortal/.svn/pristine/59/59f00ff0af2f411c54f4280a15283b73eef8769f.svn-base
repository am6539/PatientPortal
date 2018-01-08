CREATE PROCEDURE [dbo].[usp_ApprovePost_Transaction](
	@Action CHAR = 'U',
	@Id INT = 0,
	@PostId INT,
	@WorkflowStateId TINYINT,
	@UserId NVARCHAR(128),
	@Note NVARCHAR(500)
	)
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED

	DECLARE @return bit = 1
	DECLARE @CreateDate VARCHAR(20) = [dbo].[ufnGetDate]()
	BEGIN TRY
		BEGIN TRAN
			IF @PostId > 0 AND @Action = 'U'
				BEGIN
					UPDATE [dbo].Post
					SET WorkflowStateId = @WorkflowStateId
					WHERE Id = @PostId

					INSERT INTO [dbo].PostStateHistory
					VALUES(@PostId, @WorkflowStateId, @UserId, @Note, @CreateDate)
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
