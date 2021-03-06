﻿/*
Deployment script for HospitalCore

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "HospitalCore"
:setvar DefaultFilePrefix "HospitalCore"
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
PRINT N'Altering [dbo].[usp_UserGroup_Transaction]...';


GO
ALTER PROCEDURE [dbo].[usp_UserGroup_Transaction]
	@Action CHAR(1) = 'I',
	@UserId INT,
	@GroupId TINYINT
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED
	DECLARE @return BIT = 1

	BEGIN TRY
		BEGIN TRAN
			IF @Action = 'I'
				IF NOT EXISTS (SELECT TOP 1 * FROM [dbo].UserGroup WHERE UserId = @UserId AND GroupId = @GroupId)
					INSERT INTO [dbo].UserGroup
					VALUES(@UserId, @GroupId)
				ELSE
					SET @return = 0
			IF @Action = 'U'
				IF NOT EXISTS (SELECT TOP 1 * FROM [dbo].UserGroup WHERE UserId = @UserId AND GroupId = @GroupId)
					UPDATE [dbo].UserGroup
					SET UserId = @UserId, GroupId = @GroupId
					WHERE UserId = @UserId
					AND GroupId = @GroupId
			ELSE
				SET @return = 0
			IF @Action = 'D'
				IF NOT EXISTS(SELECT TOP 1 * FROM [dbo].UserGroup WHERE UserId = @UserId AND GroupId = @GroupId)
				BEGIN
					IF @UserId <> 0 AND @GroupId <> 0
						DELETE [dbo].UserGroup
						WHERE UserId = @UserId
						AND GroupId = @GroupId
					ELSE
						SET @return = 0;
				END
				ELSE
					SET @return = 0;
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT <> 0
			BEGIN
				ROLLBACK TRAN
				SET @return = 0
			END
	END CATCH
END
GO
PRINT N'Altering [dbo].[usp_UserRole_Transaction]...';


GO
ALTER PROCEDURE [dbo].[usp_UserRole_Transaction]
	@Action CHAR(1) = 'I',
	@UserId int,
	@RoleId int
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED
	DECLARE @return bit = 1

	BEGIN TRY
		BEGIN TRAN
			IF @Action = 'I'
				IF NOT EXISTS (SELECT TOP 1 * FROM [dbo].[UserRole] WHERE UserId = @UserId AND RoleId = @RoleId)
					BEGIN
						INSERT INTO [dbo].UserRole
						VALUES(@UserId, @RoleId)
					END
				ELSE
					SET @return = 0;
			IF @Action = 'U'
				IF NOT EXISTS(SELECT TOP 1 * FROM [dbo].UserRole WHERE UserId = @UserId AND RoleId = @RoleId)
				BEGIN
					IF @UserId <> 0 AND @RoleId <> 0
						UPDATE [dbo].UserRole
						SET UserId = @UserId,
						RoleId = @RoleId
						WHERE UserId = @UserId
						AND RoleId = @RoleId
					ELSE
						SET @return = 0;
				END
				ELSE
					SET @return = 0;
				
			IF @Action = 'D'
				
				IF NOT EXISTS(SELECT TOP 1 * FROM [dbo].UserRole WHERE UserId = @UserId AND RoleId = @RoleId)
				BEGIN
					IF @UserId <> 0 AND @RoleId <> 0
						DELETE [dbo].UserRole
						WHERE UserId = @UserId
						AND RoleId = @RoleId
					ELSE
						SET @return = 0;
				END
				ELSE
					SET @return = 0;
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT <> 0
			BEGIN	
				ROLLBACK TRAN
				SET @return = 0;
			END
	END CATCH
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
--GO
--INSERT INTO [dbo].[Group] VALUES(N'Content Management System (CMS)', 1)
--GO
--INSERT INTO [dbo].[Group] VALUES(N'Patient Services', 1)
--GO
--INSERT INTO [dbo].[Group] VALUES(N'Internal Services', 1)
GO

GO
PRINT N'Update complete.';


GO
