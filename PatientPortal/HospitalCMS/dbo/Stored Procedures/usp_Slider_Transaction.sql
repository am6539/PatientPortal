CREATE PROC [dbo].[usp_Slider_Transaction](
	@Action CHAR(1) = 'I',
	@Id SMALLINT = 1,
	@Title NVARCHAR(150) = '',
	@Description NVARCHAR(300) = '',
	@Image VARCHAR(256) = '',
	@ExpiredDate Date = '',
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
			INSERT [dbo].[Slider] ([Title], [Description], [Image], [ExpiredDate], [IsUsed])
			VALUES(@Title, @Description, @Image, @ExpiredDate, @IsUsed)
		END

		IF @Action = 'U' --UPDATE
		BEGIN
			UPDATE [dbo].[Slider]
			SET [Title] = @Title, [Image] = @Image, [Description] = @Description, [ExpiredDate] = @ExpiredDate, [IsUsed] = @IsUsed
			WHERE [Id] = @Id  
		END

		IF @Action = 'D' --DELETE
		BEGIN
			DELETE FROM [dbo].[Slider]
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