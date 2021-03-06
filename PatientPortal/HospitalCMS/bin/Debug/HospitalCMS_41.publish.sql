﻿/*
Deployment script for HospitalCMS

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "HospitalCMS"
:setvar DefaultFilePrefix "HospitalCMS"
:setvar DefaultDataPath "D:\MSSQL\DATA\"
:setvar DefaultLogPath "D:\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.	
 Use SQLCMD syntax to include a file in the pre-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
GO

GO
PRINT N'Altering [dbo].[usp_Category]...';


GO
ALTER PROC [dbo].[usp_Category]
	@Id TINYINT,
	@ParentId TINYINT
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED

	BEGIN TRY
		IF @Id > 0
			SELECT * FROM [dbo].Category
			WHERE Id = @Id
		IF @ParentId > 0
			SELECT * FROM [dbo].Category
			WHERE ParentId = @ParentId
		ELSE
			SELECT * FROM [dbo].[Category]
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT <> 0 
		BEGIN
			RETURN NULL
		END
	END CATCH
END
GO
PRINT N'Altering [dbo].[usp_Category_Transaction]...';


GO
ALTER PROC [dbo].[usp_Category_Transaction](
	@Action CHAR(1) = 'I',
	@Id TINYINT = 1,
	@Name NVARCHAR(50) = '',
	@Image VARCHAR(256) = '',
	@Handler VARCHAR(256) = '',
	@Sort TINYINT = 1,
	@ParentId TINYINT = 1
)
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED

	DECLARE @return bit = 1
	BEGIN TRY
		BEGIN TRAN;
		
		IF @Action = 'I' --INSERT
		BEGIN
			INSERT [dbo].[Category](Name, Image, Handler, Sort, ParentId)
			VALUES(@Name, @Image, @Handler, @Sort, @ParentId)
		END

		IF @Action = 'U' --UPDATE
		BEGIN
			UPDATE [dbo].[Category]
			SET [Name] = @Name, [Image] = @Image, [Handler] = @Handler, [Sort] = @Sort, [ParentId] = @ParentId
			WHERE [Id] = @Id  
		END

		IF @Action = 'D' --DELETE
		BEGIN
			IF NOT EXISTS( SELECT TOP 1 1 FROM [dbo].[Post] WITH(INDEX(idxPostCategory)) WHERE [CategoryId] = @Id)
			BEGIN
				DELETE FROM [dbo].[Category]
				WHERE [Id] = @Id
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
	SELECT @return
	
END
GO
/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
GO

GO
PRINT N'Update complete.';


GO
