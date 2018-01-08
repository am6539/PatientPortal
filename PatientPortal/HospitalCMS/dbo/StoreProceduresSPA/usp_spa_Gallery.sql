CREATE PROC [dbo].[usp_spa_Gallery]
	@Id VARCHAR(128),
	@DepartmentId TINYINT = 0
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED

	BEGIN TRY
		IF @Id <> ''
			SELECT * FROM [dbo].[Gallery]
			WHERE [Id] = @Id
			ORDER BY [Id]
		ELSE
		BEGIN
			IF @departmentId > 0
				SELECT * FROM [dbo].[Gallery]
				WHERE [DepartmentId] = @departmentId
			ELSE
				SELECT * FROM [dbo].[Gallery]
		END
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT <> 0 
		BEGIN
			RETURN NULL
		END
	END CATCH
END