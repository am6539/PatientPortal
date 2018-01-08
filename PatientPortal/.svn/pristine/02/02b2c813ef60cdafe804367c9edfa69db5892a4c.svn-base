CREATE PROCEDURE [dbo].[usp_User_ByGroupType]
	@GroupType NVARCHAR(128)
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED

	BEGIN TRY
		-- là Bệnh nhân
		IF @GroupType = N'BenhNhan'
		BEGIN
			SELECT DISTINCT *
			FROM   [dbo].Users u
			WHERE  u.PatientId IS NOT NULL
		END

		-- là Bác sĩ
		IF @GroupType = N'BacSi'
		BEGIN
			SELECT DISTINCT *
			FROM   [dbo].Users u
			WHERE  u.IsDoctor = 1
		END

		-- là Nội bộ
		IF @GroupType = N'NoiBo'
		BEGIN
			SELECT DISTINCT *
			FROM   [dbo].Users u
			WHERE  u.PatientId = NULL
		END

		-- Tất cả
		IF @GroupType = N'TatCa'
		BEGIN
			SELECT DISTINCT *
			FROM   [dbo].Users u
		END
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT <> 0 
		BEGIN
			RETURN NULL
		END
	END CATCH
END
GO

