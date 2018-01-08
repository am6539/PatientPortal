﻿CREATE PROC [dbo].[usp_Group_Transaction]
(
	@Action CHAR(1) = 'I',
	@Id INT = 1,
	@Name NVARCHAR(150) = '',
	@IsReadOnly BIT = 0
)
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED
	DECLARE @return INT = 0

	BEGIN TRY
		BEGIN TRAN;
		
			IF @Action = 'I' --INSERT
			BEGIN
				INSERT [dbo].[Group] VALUES(@Name, @IsReadOnly)

				SET @return = SCOPE_IDENTITY()
			END

			IF @Action = 'U' --UPDATE
			BEGIN
				UPDATE [dbo].[Group]
				SET [Name] = @Name, [IsReadOnly] = @IsReadOnly
				WHERE [Id] = @Id  

				SET @return = @Id
			END

			IF @Action = 'D' --DELETE
			BEGIN
				IF NOT EXISTS( SELECT TOP 1 1 FROM [dbo].[UserGroup] WHERE [GroupId] = @Id)
				BEGIN
					DELETE FROM [dbo].[Group]
					WHERE [Id] = @Id

					SET @return = @Id
				END
				ELSE
					SET @return = 0
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