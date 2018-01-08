CREATE PROC [dbo].[usp_MessageFolder_Transaction]
(
	@Action CHAR(1) = 'I',
	@Id TINYINT = 1,
	@Name NVARCHAR(50) = '',
	@Path NVARCHAR(256) = ''
)
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED
	DECLARE @return INT = 0

	BEGIN TRY
		BEGIN TRAN;
		
			IF @Action = 'I' --INSERT
			BEGIN
				INSERT [dbo].[MessageFolder] VALUES(@Name, @Path)

				SET @return = SCOPE_IDENTITY()
			END

			IF @Action = 'U' --UPDATE
			BEGIN
				UPDATE [dbo].[MessageFolder]
				SET [Name] = @Name, [Path] = @Path
				WHERE [Id] = @Id  

				SET @return = @Id
			END

			IF @Action = 'D' --DELETE
			BEGIN
				IF NOT EXISTS(SELECT TOP 1 1 FROM [dbo].[Message] WITH(INDEX(idxMessageFolder)) WHERE [FolderId] = @Id)
				BEGIN
					DELETE FROM [dbo].[MessageFolder] WHERE [Id] = @Id

					SET @return = @Id
				END
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
	SELECT @return;
END