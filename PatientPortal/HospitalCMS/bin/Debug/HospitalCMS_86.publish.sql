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
PRINT N'Altering [dbo].[usp_Post_Transaction]...';


GO
ALTER PROCEDURE [dbo].[usp_Post_Transaction]
	@Action CHAR(1) = 'I',
	@Id INT,
	@Image VARCHAR(256),
	@Author NVARCHAR(50),
	@WorkflowStateId TINYINT = 1,
	@CategoryId TINYINT,
	@Status TINYINT = 1,
	@CreatedBy INT,
	@ModifiedBy INT,
	@Priority TINYINT,
	@ExpiredDate DATE,
	-- PostSEO
	@PostId INT,
	@TitleSEO NVARCHAR(71),
	@DescriptionSEO NVARCHAR(160),
	@Canonical VARCHAR(256),
	@BreadcrumbsTitle NVARCHAR(71),
	@MetaRobotIndex TINYINT,
	@MetaRobotFollow TINYINT,
	@MetaRobotAdvanced TINYINT,
	-- PostTrans
	@LanguageId TINYINT,
	@TitleTrans NVARCHAR(256),
	@DescriptionTrans NVARCHAR(1000),
	@Detail NVARCHAR(MAX),
	@Tag NVARCHAR(60),
	-- PostStateHistory
	@UserId INT,
	@Note NVARCHAR(500) 
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED

	DECLARE @return BIT = 1
	DECLARE @Date SMALLDATETIME, @PresentDate VARCHAR(20)
	SET @Date = GETDATE()
	SET @PresentDate = [dbo].[ufnGetDate]()

	BEGIN TRY
		BEGIN TRAN
			IF @Action = 'I' 
			BEGIN
				-- Post Table
				INSERT INTO [dbo].[Post]
				VALUES(@Date, @Image, @Author, @WorkflowStateId, @CategoryId, @Status, @PresentDate,
				@CreatedBy, @PresentDate, @ModifiedBy, @Priority, @ExpiredDate)

				-- PostSEO Table
				SET @PostId = SCOPE_IDENTITY()
				INSERT INTO [dbo].[PostSEO]
				VALUES(@PostId, @TitleSEO, @DescriptionSEO, @Canonical, @BreadcrumbsTitle, @MetaRobotIndex,
				@MetaRobotFollow, @MetaRobotAdvanced)

				-- PostTrans Table
				INSERT INTO [dbo].[PostTrans]
				VALUES(@PostId, @LanguageId, @TitleTrans, @DescriptionTrans, @Detail, @Tag)

				-- PostStateHistory Table
				INSERT INTO [dbo].[PostStateHistory]
				VALUES(@PostId, @WorkflowStateId, @UserId, @Note, @PresentDate)
			END				
			IF @Action = 'U' 
			BEGIN
				
				IF((SELECT WorkflowStateId FROM [dbo].Post WHERE Id = @PostId) <> 1)
				BEGIN
					-- Post Table
					UPDATE [dbo].[Post]
					SET [PublishDate] = @Date, [Image] = @Image, [Author] = @Author,
					[CategoryId] = @CategoryId, [Status] = @Status,
					[ModifiedDate] = @PresentDate, [ModifiedBy] = @ModifiedBy,
					[Priority] = @Priority, [ExpiredDate] = @ExpiredDate
					WHERE [Id] = @Id

					-- PostSEO Table
					UPDATE [dbo].[PostSEO]
					SET [PostId] = @Id, [Title] = @TitleSEO, [Description] = @DescriptionSEO,
					[Canonical] = @Canonical, [BreadcrumbsTitle] = @BreadcrumbsTitle, [MetaRobotIndex] = @MetaRobotIndex,
					[MetaRobotFollow] = @MetaRobotFollow, [MetaRobotAdvanced] = @MetaRobotAdvanced
					WHERE [PostId] = @Id

					-- PostTrans Table
					UPDATE [dbo].[PostTrans]
					SET [LanguageId] = @LanguageId, [Title] = @TitleTrans,
					[Description] = @DescriptionTrans, [Detail] = @Detail, [Tag] = @Tag
					WHERE [PostId] = @Id AND [LanguageId] = @LanguageId

					-- PostStateHistory Table
					IF NOT EXISTS( SELECT TOP 1 1 FROM [dbo].[PostStateHistory] WITH(INDEX(IdxPostStateHistoryPost)) WHERE [PostId] = @Id AND [WorkflowStateId] = @WorkflowStateId )
					BEGIN
						INSERT INTO [dbo].[PostStateHistory]
						VALUES(@Id, @WorkflowStateId, @UserId, @Note, @PresentDate)
					END
				END
				ELSE
					SET @return = 0
			END
			IF @Action = 'D' 
			BEGIN
				IF((SELECT WorkflowStateId FROM [dbo].Post WHERE Id = @PostId) <> 1)
				BEGIN
					--  PostSEO Table
					DELETE FROM [dbo].[PostSEO]
					WHERE [PostId] = @Id

					-- PostTrans Table
					DELETE FROM [dbo].[PostTrans]
					WHERE [PostId] = @Id

					-- PostStateHistory
					DELETE FROM [dbo].[PostStateHistory]
					WHERE [PostId] = @Id

					-- Post Table
					DELETE FROM [dbo].[Post]
					WHERE [Id] = @Id
				END
				ELSE
					SET @return = 0
			END
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT <> 0
			BEGIN
				ROLLBACK TRAN
				SET @return = 0
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

IF NOT EXISTS (SELECT TOP 1 1 FROM [dbo].[Workflow] WHERE Name = N'Workflow post')
BEGIN
	DECLARE @WorkflowId TINYINT = 0
	DECLARE @WorkflowStateId TINYINT = 0
	DECLARE @NextWorkflowStateId TINYINT = 0
	---------------
	INSERT INTO [dbo].Workflow
	VALUES(N'Workflow post')
	---------
	IF NOT EXISTS (SELECT TOP 1 1 FROM [dbo].WorkflowState WHERE Name = N'Đang soạn thảo')
		BEGIN
			SET @WorkflowId = SCOPE_IDENTITY()
			INSERT INTO [dbo].WorkflowState
			VALUES(N'Đang soạn thảo', @WorkflowId, 1, 1)

			SET @WorkflowStateId = SCOPE_IDENTITY()
		END
	---------------
	IF NOT EXISTS (SELECT TOP 1 1 FROM [dbo].WorkflowState WHERE Name = N'Đã duyệt')
		BEGIN
			INSERT INTO [dbo].WorkflowState
			VALUES(N'Đã duyệt', @WorkflowId, 1, 0)

			SET @WorkflowStateId = SCOPE_IDENTITY()
		END
	--------------
	IF NOT EXISTS (SELECT TOP 1 1 FROM [dbo].WorkflowState WHERE Name = N'Đã đăng bài')
		BEGIN
			INSERT INTO [dbo].WorkflowState
			VALUES(N'Đã đăng bài', @WorkflowId, 1, 0)

			SET @NextWorkflowStateId = SCOPE_IDENTITY()
		END
	----------------------
	IF @WorkflowStateId > 0 AND @NextWorkflowStateId > 0
		BEGIN
			INSERT INTO [dbo].WorkflowNavigation
			VALUES(@WorkflowStateId, @NextWorkflowStateId)
		END
END
GO

GO
PRINT N'Update complete.';


GO
