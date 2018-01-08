CREATE PROC [dbo].[usp_DepartmentServices]
	@Id SMALLINT = 1, @DepartmentId SMALLINT = 1
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED

	BEGIN TRY
		IF @Id > 0
			SELECT * FROM [dbo].[DepartmentServices]
			WHERE [Id] = @Id AND [DepartmentId] = @DepartmentId
			
		ELSE
			SELECT * FROM [dbo].[DepartmentServices] WHERE [DepartmentId] = @DepartmentId ORDER BY [Name]
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT <> 0 
		BEGIN
			RETURN NULL
		END
	END CATCH
END