CREATE PROC [dbo].[usp_DepartmentServices_Transaction](
	@Action CHAR(1) = 'I',
	@Id SMALLINT = 1, @DepartmentId SMALLINT = 1,
	@Name NVARCHAR(80)= '',
	@Price NUMERIC(13,3) = 0,
	@Category TINYINT = 1
)
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED

	DECLARE @return bit = 1
	BEGIN TRY
		BEGIN TRAN;
		
		IF @Action = 'I' --INSERT
		BEGIN
			SELECT @Id = ISNULL(MAX(id),0) + 1  FROM [dbo].[DepartmentServices] WHERE [DepartmentId] = @DepartmentId
			INSERT [dbo].[DepartmentServices] (Id, DepartmentId, Name, Price, Category)
			VALUES(@Id, @DepartmentId, @Name, @Price, @Category)
		END

		IF @Action = 'U' --UPDATE
		BEGIN
			UPDATE [dbo].[DepartmentServices]
			SET [Name] = @Name, [Price] = @Price, [Category] = @Category
			WHERE [Id] = @Id  AND [DepartmentId] = @DepartmentId
		END

		IF @Action = 'D' --DELETE
		BEGIN
			DELETE FROM [dbo].[DepartmentServices]
			WHERE [Id] = @Id AND [DepartmentId] = @DepartmentId
		END

		COMMIT TRAN;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT <> 0 
		BEGIN
			ROLLBACK TRAN;
			SET  @return = 0
		END
	END CATCH
	SELECT @return
	
END