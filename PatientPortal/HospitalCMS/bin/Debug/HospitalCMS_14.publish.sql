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
PRINT N'Creating [dbo].[PostStateHistory].[idxPostStateHistoryPost]...';


GO
CREATE NONCLUSTERED INDEX [idxPostStateHistoryPost]
    ON [dbo].[PostStateHistory]([PostId] ASC);


GO
PRINT N'Creating [dbo].[WorkflowState].[idxWorkflowStateWorkflow]...';


GO
CREATE NONCLUSTERED INDEX [idxWorkflowStateWorkflow]
    ON [dbo].[WorkflowState]([WorkflowId] ASC);


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
			INSERT [dbo].[Category]
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
PRINT N'Altering [dbo].[usp_Post_Transaction]...';


GO
ALTER PROCEDURE [dbo].[usp_Post_Transaction]
	@Action CHAR(1) = 'I',
	@Id INT,
	@Date DATE,
	@Image VARCHAR(256),
	@Author NVARCHAR(50),
	@WorkflowStateId TINYINT,
	@CategoryId TINYINT,
	@Status TINYINT,
	@CreatedBy INT,
	@ModifiedBy INT,
	-- PostSEO
	@postId INT,
	@Title_SEO NVARCHAR(71),
	@Description_SEO NVARCHAR(160),
	@Canonical VARCHAR(256),
	@BreadcrumbsTitle NVARCHAR(71),
	@MetaRobotIndex TINYINT,
	@MetaRobotFollow TINYINT,
	@MetaRobotAdvanced TINYINT,
	-- PostTrans
	@LanguageId TINYINT,
	@Title_Trans NVARCHAR(256),
	@Decription_Trans NVARCHAR(1000),
	@Detail NVARCHAR(MAX),
	@Tag NVARCHAR(60),
	-- PostStateHistory
	@PostStateHistoryId INT,
	@UserId INT,
	@Note NVARCHAR(500)
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED

	DECLARE @return BIT = 1
	BEGIN TRY
		BEGIN TRAN
			IF @Action = 'I' 
			BEGIN
				-- Post Table
				INSERT INTO [dbo].[Post]
				VALUES(@Date, @Image, @Author, @WorkflowStateId, @CategoryId, @Status, GETDATE(),
				@CreatedBy, GETDATE(),@ModifiedBy)
				-- INSERT POST
				INSERT INTO [dbo].Post
				VALUES(GETDATE(),@image,@author,@workflowStateId,@categoryId,@status,GETDATE(),
				@createdBy,GETDATE(),@modifiedBy)


				-- PostSEO Table
				SET @Id = SCOPE_IDENTITY()
				INSERT INTO [dbo].[PostSEO]
				VALUES(@Id, @Title_SEO, @Description_SEO, @Canonical, @BreadcrumbsTitle, @MetaRobotIndex,
				@MetaRobotFollow, @MetaRobotAdvanced)

				-- PostTrans Table
				INSERT INTO [dbo].[PostTrans]
				VALUES(@Id, @LanguageId, @Title_Trans, @Decription_Trans, @Detail, @Tag)

				-- PostStateHistory Table
				INSERT INTO [dbo].[PostStateHistory]
				VALUES(@Id, @WorkflowStateId, @UserId, @Note, GETDATE())
			END				
			IF @Action = 'U' 
			BEGIN
				-- Post Table
				UPDATE [dbo].[Post]
				SET [Date] = @Date, [Image] = @Image, [Author] = @Author, [WorkflowStateId] = @WorkflowStateId,
				[CategoryId] = @CategoryId, [Status] = @Status, [CreatedDate] = GETDATE(), [CreatedBy] = @CreatedBy,
				[ModifiedDate] = GETDATE(), [ModifiedBy] = @ModifiedBy
				WHERE [Id] = @Id

				-- PostSEO Table
				UPDATE [dbo].[PostSEO]
				SET [PostId] = @Id, [Title] = @Title_SEO, [Description] = @Description_SEO,
				[Canonical] = @Canonical, [BreadcrumbsTitle] = @BreadcrumbsTitle, [MetaRobotIndex] = @MetaRobotIndex,
				[MetaRobotFollow] = @MetaRobotFollow, [MetaRobotAdvanced] = @MetaRobotAdvanced
				WHERE [PostId] = @Id

				-- PostTrans Table
				UPDATE [dbo].[PostTrans]
				SET [LanguageId] = @LanguageId, [Title] = @Title_Trans,
				[Description] = @Decription_Trans, [Detail] = @Detail, [Tag] = @Tag
				WHERE [PostId] = @Id AND [LanguageId] = @LanguageId

				-- PostStateHistory Table
				IF NOT EXISTS( SELECT TOP 1 1 FROM [dbo].[PostStateHistory] WITH(INDEX(IdxPostStateHistoryPost)) WHERE [PostId] = @Id AND [WorkflowStateId] = @WorkflowStateId )
				BEGIN
					INSERT INTO [dbo].[PostStateHistory]
					VALUES(@Id, @WorkflowStateId, @UserId, @Note, GETDATE())
				END
			END
			IF @Action = 'D' 
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
PRINT N'Altering [dbo].[usp_Workflow]...';


GO
ALTER PROCEDURE [dbo].[usp_Workflow]
AS BEGIN
	BEGIN TRY
		SELECT * FROM [dbo].[Workflow]
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT <> 0
			BEGIN
				RETURN NULL
			END
	END CATCH
END
GO
PRINT N'Altering [dbo].[usp_Workflow_Transaction]...';


GO
ALTER PROCEDURE [dbo].[usp_Workflow_Transaction]
	@Action VARCHAR(1) = 'I',
	@Id TINYINT,
	@Name NVARCHAR(50)
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED

	DECLARE @return BIT = 1
	BEGIN TRY
		BEGIN TRAN
			IF @Action = 'I' -- INSERT
			BEGIN
				INSERT INTO [dbo].[Workflow]
				VALUES(@Name)
			END

			IF @Action = 'U' -- UPDATE
			BEGIN
				UPDATE [dbo].[Workflow]
				SET [Name] = @Name
			END

			IF @Action = 'D' -- DELETE
			BEGIN
				IF NOT EXISTS( SELECT TOP 1 1 FROM [dbo].[WorkflowState] WITH(INDEX(idxWorkflowStateWorkflow)) WHERE [WorkflowId] = @Id)
				BEGIN
					DELETE FROM [dbo].[Workflow]
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
PRINT N'Altering [dbo].[usp_WorkflowNavigation]...';


GO
ALTER PROCEDURE [dbo].[usp_WorkflowNavigation]
AS BEGIN
	BEGIN TRY
		SELECT * FROM [dbo].[WorkflowNavigation]
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT <> 0 
			BEGIN
				RETURN NULL
			END
	END CATCH
END
GO
PRINT N'Altering [dbo].[usp_WorkflowState]...';


GO
ALTER PROCEDURE [dbo].[usp_WorkflowState]
AS BEGIN
	BEGIN TRY
		SELECT * FROM [dbo].[WorkflowState]
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT <> 0
			BEGIN
				RETURN NULL
			END
	END CATCH
END
GO
PRINT N'Creating [dbo].[usp_PostStateHistory_Transaction]...';


GO
CREATE PROCEDURE [dbo].[usp_PostStateHistory_Transaction]
	@Action CHAR(1) = 'I',
	@PostId INT,
	@WorkflowStateId TINYINT,
	@UserId INT,
	@Note NVARCHAR(500)
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED

	DECLARE @return bit = 1
	BEGIN TRY
		BEGIN TRAN

			IF @Action = 'I' -- INSERT
			BEGIN
				INSERT INTO [dbo].[PostStateHistory]
				VALUES(@PostId, @WorkflowStateId, @UserId, @Note, GETDATE())
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
PRINT N'Creating [dbo].[usp_WorkflowNavigation_Transaction]...';


GO
CREATE PROCEDURE [dbo].[usp_WorkflowNavigation_Transaction]
	@Action VARCHAR(1) = 'I',
	@WorkflowStateId SMALLINT,
	@NextWorkflowStateId SMALLINT
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED

	DECLARE @return BIT = 1
	BEGIN TRY
		BEGIN TRAN
			IF @Action = 'I' -- INSERT
			BEGIN
				IF NOT EXISTS( SELECT TOP 1 1 FROM [dbo].[Post] WHERE [WorkflowStateId] = @WorkflowStateId)
				BEGIN
					DELETE FROM [dbo].[WorkflowNavigation] WHERE [WorkflowStateId] = @WorkflowStateId

					INSERT INTO [dbo].[WorkflowNavigation]
					VALUES(@WorkflowStateId, @NextWorkflowStateId)
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
PRINT N'Creating [dbo].[usp_WorkflowState_Transaction]...';


GO
CREATE PROCEDURE [dbo].[usp_WorkflowState_Transaction]
	@Action VARCHAR(1) = 'I',
	@Id SMALLINT,
	@Name NVARCHAR(50) = '',
	@WorkflowId TINYINT = 0,
	@IsActive BIT = 1
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED

	DECLARE @return BIT = 1
	BEGIN TRY
		BEGIN TRAN
			IF @Action = 'I' -- INSERT
			BEGIN
				INSERT INTO [dbo].[WorkflowState]
				VALUES(@Name, @WorkflowId, @IsActive)
			END

			IF @Action = 'U' -- UPDATE
			BEGIN
				IF NOT EXISTS( SELECT TOP 1 1 FROM [dbo].[WorkflowNavigation] WHERE [WorkflowStateId] = @Id)  AND NOT EXISTS( SELECT TOP 1 1 FROM [dbo].[Post] WHERE [WorkflowStateId] = @Id)
				BEGIN
					UPDATE [dbo].[WorkflowState]
					SET [Name] = @Name, [WorkflowId] = @WorkflowId, [IsActive] = @IsActive
					WHERE [Id] = @Id
				END
				ELSE
					SET @return = 0
			END

			IF @Action = 'U' -- DELETE
			BEGIN
				IF NOT EXISTS( SELECT TOP 1 1 FROM [dbo].[Post] WHERE [WorkflowStateId] = @Id)
				BEGIN
					DELETE FROM [dbo].[WorkflowState]
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
GO

GO
PRINT N'Update complete.';


GO
