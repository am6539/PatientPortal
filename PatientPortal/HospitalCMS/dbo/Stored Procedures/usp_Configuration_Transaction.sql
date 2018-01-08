CREATE PROC [dbo].[usp_Configuration_Transaction](
	@Action CHAR(1) = 'I',
	@Id TINYINT = 1,
	@Name NVARCHAR(250) = '',
	@Address NVARCHAR(250) = '',
	@Phone VARCHAR(100) = '',
	@Fax VARCHAR(100) = '',
	@Hotline VARCHAR(50) = '',
	@GoogleMap VARCHAR(50) = '',
	@GoogleEngineScript NVARCHAR(MAX) = '',
	@IsSendEmailWF BIT,
	@OpeningHours varchar(50),
	@Email varchar(256),
	@Youtube varchar(256) = '',
	@Twitter varchar(256) = '',
	@Facebook varchar(256) = '', 
	@Google varchar(256) = '',
	@Slogan varchar(256) = '',
	@SEOTitle nvarchar(70) = '',
	@SEODescription nvarchar(150) = '',
	@SEOKeyword nvarchar(150) = ''
)
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED

	DECLARE @return bit = 1
	BEGIN TRY
		BEGIN TRAN;
		
		IF EXISTS(SELECT TOP 1 1 FROM [dbo].[CMS])
		BEGIN
			UPDATE  [dbo].[CMS]
			SET
				[Name] = @Name, [Address] = @Address, [Phone] = @Phone, [Fax] = @Fax, [Hotline] = @Hotline,
				[GoogleMap] = @GoogleMap, [GoogleEngineScript] = @GoogleEngineScript, IsSendEmailWF = @IsSendEmailWF,
				[OpeningHours] = @OpeningHours, [Email] =  @Email, [Youtube] =  @Youtube, [Twitter] = @Twitter, 
				[Facebook] = @Facebook, [Google] = @Google, [Slogan] = @Slogan, [SEOTitle] = @SEOTitle, [SEODescription] = @SEODescription, [SEOKeyword] = @SEOKeyword
			WHERE [Id] = 1
		END
		ELSE
		BEGIN
			INSERT [dbo].[CMS] ([Id], [Name], [Address], [Phone], [Fax], [Hotline], [GoogleMap], [GoogleEngineScript], [IsSendEmailWF],
								[OpeningHours], [Email], [Youtube], [Twitter], [Facebook], [Google], [Slogan], [SEOTitle], [SEODescription], [SEOKeyword]
								)
			VALUES(1, @Name, @Address, @Phone, @Fax, @Hotline, @GoogleMap, @GoogleEngineScript, @IsSendEmailWF,
					@OpeningHours, @Email, @Youtube, @Twitter, @Facebook, @Google, @Slogan, @SEOTitle, @SEODescription, @SEOKeyword
					)
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