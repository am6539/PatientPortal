CREATE PROC [dbo].[usp_LinkBuilding_Transaction](
	@Action CHAR(1) = 'I',
	@Id SMALLINT = 1,
	@Title NVARCHAR(150) = '',
	@Url VARCHAR(256) = '',
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
			INSERT [dbo].[LinkBuilding] ([Title], [Url], [IsUsed])
			VALUES(@Title, @Url, @IsUsed)
		END

		IF @Action = 'U' --UPDATE
		BEGIN
			UPDATE [dbo].[LinkBuilding]
			SET [Title] = @Title, [Url] = @Url, [IsUsed] = @IsUsed
			WHERE [Id] = @Id  
		END

		IF @Action = 'D' --DELETE
		BEGIN
			
			DELETE FROM [dbo].[LinkBuilding]
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