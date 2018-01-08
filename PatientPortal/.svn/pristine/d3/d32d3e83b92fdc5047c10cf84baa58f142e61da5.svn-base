CREATE PROCEDURE [dbo].[usp_GalleryStore_Transaction]
	@Action CHAR(1) = 'I',
	@Id VARCHAR(128) = '',
	@ParentId VARCHAR(128)= '',
	@Img VARCHAR(256) = ''
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED

	DECLARE @return bit = 1
	BEGIN TRY
		BEGIN TRAN;

		IF @Action = 'I' --INSERT
		BEGIN
			INSERT [dbo].[GalleryStore]([Id], [ParentId],[Img])
			VALUES(@Id, @ParentId, @Img)
		END

		IF @Action = 'U' --UPDATE
		BEGIN
			UPDATE [dbo].[GalleryStore]
			SET [Img] = @Img
			WHERE [Id] = @Id  
		END

		IF @Action = 'D' --DELETE
		BEGIN
			DELETE FROM [dbo].[GalleryStore]
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