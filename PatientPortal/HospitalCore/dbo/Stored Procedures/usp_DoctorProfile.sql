CREATE PROCEDURE [dbo].[usp_DoctorProfile]
	@UserId NVARCHAR(128) = ''
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED

	BEGIN TRY
		IF @UserId <> N''
			SELECT p.*, u.[Name], u.[Image] 
			FROM  [dbo].[Users] u Left JOIN [dbo].[DoctorProfile] p 
			ON p.UserId = u.Id
			WHERE [UserId] = @UserId
		ELSE
			SELECT p.*, u.[Name], u.[Image] 
			FROM  [dbo].[Users] u  Left JOIN [dbo].[DoctorProfile] p
			ON p.UserId = u.Id
			WHERE u.[IsDoctor] = 1
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT <> 0 
		BEGIN
			RETURN NULL
		END
	END CATCH
END
GO


