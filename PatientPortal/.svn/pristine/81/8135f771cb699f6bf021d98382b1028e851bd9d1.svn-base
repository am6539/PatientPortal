CREATE PROC [dbo].[usp_Feature_Transaction](
	@Action CHAR(1) = 'I',
	@Id TINYINT = 1,
	@Title NVARCHAR(50) = '',
	@Image VARCHAR(256) = '',
	@Description NVARCHAR(256) = '',
	@Handler NVARCHAR(256) = '',
	@IsUsed BIT = 1
)
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED

	DECLARE @return bit = 1
	BEGIN TRY
		BEGIN TRAN;
		
		IF @Action = 'I' --INSERT
		BEGIN
			INSERT [dbo].[Feature] ([Title], [Image], [Description], [Handler], [IsUsed])
			VALUES(@Title, @Image, @Description, @Handler, @IsUsed)
		END

		IF @Action = 'U' --UPDATE
		BEGIN
			UPDATE [dbo].[Feature]
			SET [Title] = @Title, [Image] = @Image, [Description] = @Description, [Handler] = @Handler, [IsUsed] = @IsUsed
			WHERE [Id] = @Id  
		END

		IF @Action = 'D' --DELETE
		BEGIN
			DELETE FROM [dbo].[Feature]
			WHERE [Id] = @Id
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