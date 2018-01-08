CREATE PROC [dbo].[usp_Module]
( 
	@Id SMALLINT = 0
)
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED
	--DEFAULT: 1 - CMS, 2 - Patient Services, 3 - Internal Services
	BEGIN TRY
		IF(@Id > 0)
			SELECT * FROM [dbo].[Module] WHERE [Id] = @Id
		ELSE
			SELECT * FROM [dbo].[Module]-- WITH(INDEX(idxModuleGroup)) WHERE [Group] = @GroupId
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT <> 0 
		BEGIN
			RETURN NULL
		END
	END CATCH
END