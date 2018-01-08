CREATE PROC [dbo].[usp_Module_Transaction]
(
	@Action CHAR(1) = 'I',
	@Id SMALLINT = 1,
	@Title NVARCHAR(128) = '',
	@Handler NVARCHAR(256) = '',
	@Sort TINYINT = 1,
	@ParentId SMALLINT = 1,
	@Group CHAR(1)  = '1',
	@ClassName VARCHAR(50) = ''
)
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED
	DECLARE @return INT = 0

	BEGIN TRY
		BEGIN TRAN;
			IF @Action = 'I' --INSERT
			BEGIN
				SELECT @Id = ISNULL(MAX(Id),0) + 1 FROM dbo.[Module]
				INSERT [dbo].[Module] VALUES(@Id, @Title, @Handler, @Sort, @ParentId, @Group, @ClassName)

				SET @return = 1
			END

			IF @Action = 'U' --UPDATE
			BEGIN
				UPDATE [dbo].[Module]
				SET [Title] = @Title, [Handler] = @Handler, [Sort] = @Sort, [ParentId] = @ParentId, [Group] = @Group, [ClassName] = @ClassName
				WHERE [Id] = @Id  

				SET @return = 1
			END

			IF @Action = 'D' --DELETE
			BEGIN
				DELETE FROM [dbo].[Module]
				WHERE [Id] = @Id

				SET @return = 1
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