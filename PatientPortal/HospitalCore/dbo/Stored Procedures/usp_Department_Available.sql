﻿CREATE PROC [dbo].[usp_Department_Available]
	@Id SMALLINT
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED

	BEGIN TRY
		IF @Id > 0
			SELECT * FROM [dbo].[Department]
			WHERE [Id] = @Id
			ORDER BY [Id]
		ELSE
			SELECT * FROM [dbo].[Department] WHERE [IsUsed] = 1
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT <> 0 
		BEGIN
			RETURN NULL
		END
	END CATCH
END