CREATE PROCEDURE [dbo].[usp_Advertise_Transaction]
	@Action CHAR(1) = 'I',
	@Id SMALLINT,
	@Name NVARCHAR(256), 
    @Description NVARCHAR(256) = '', 
    @StartDate DATE, 
    @EndDate DATE, 
    @Position TINYINT = 0, 
    @Handler VARCHAR(256) = '', 
    @Resouce VARCHAR(256) = '',
	@Type tinyint = 0, 
    @IsUsed BIT  = 1
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED

	DECLARE @return bit = 1
	BEGIN TRY
		BEGIN TRAN;
		
		IF @Action = 'I' --INSERT
		BEGIN
			INSERT [dbo].[Advertise](Name, [Description], [StartDate], [EndDate], [Position], [Handler], [Resouce], [IsUsed], [Type])
			VALUES(@Name, @Description, @StartDate, @EndDate, @Position, @Handler, @Resouce, @IsUsed, @Type)
		END

		IF @Action = 'U' --UPDATE
		BEGIN
			UPDATE [dbo].[Advertise]
			SET [Name] = @Name, [Description] = @Description, [StartDate] = @StartDate, [EndDate]= @EndDate, Position = @Position, Handler=@Handler, Resouce = @Resouce, IsUsed = @IsUsed, [Type] = @Type
			WHERE [Id] = @Id
		END

		IF @Action = 'D' --DELETE
		BEGIN
			DELETE FROM [dbo].[Advertise]
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