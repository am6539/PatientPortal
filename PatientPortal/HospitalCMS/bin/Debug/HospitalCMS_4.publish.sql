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
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED

	BEGIN TRY
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
			DELETE FROM [dbo].[Category]
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
GO
PRINT N'Altering [dbo].[usp_Post_Transaction]...';


GO
ALTER PROCEDURE [dbo].[usp_Post_Transaction]
	@Action CHAR(1) = 'I',
	@id INT,
	@date DATE,
	@image VARCHAR(256),
	@author NVARCHAR(50),
	@workflowStateId TINYINT,
	@categoryId TINYINT,
	@status TINYINT,
	@createdBy INT,
	@modifiedBy INT,
	-- parameter PostSEO
	@postId INT,
	@title_SEO NVARCHAR(71),
	@description_SEO NVARCHAR(160),
	@canonical VARCHAR(256),
	@breadcrumbsTitle NVARCHAR(71),
	@metaRobotIndex TINYINT,
	@metaRobotFollow TINYINT,
	@metaRobotAdvanced TINYINT,
	-- parameter PostTrans
	@languageId TINYINT,
	@title_Trans NVARCHAR(256),
	@decription_Trans NVARCHAR(1000),
	@detail NVARCHAR(MAX),
	@tag NVARCHAR(60),
	-- parameter PostStateHistory
	@idPostStateHis INT,
	@userId INT,
	@note NVARCHAR(500)
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED

	DECLARE @return bit = 1
	BEGIN TRY
		BEGIN TRAN
			IF @Action = 'I' 
			BEGIN
				-- INSERT POST
				INSERT INTO [dbo].Post
				VALUES(@date,@image,@author,@workflowStateId,@categoryId,@status,GETDATE(),
				@createdBy,GETDATE(),@modifiedBy)

				-- INSERT POST_SEO
				SET @postId = SCOPE_IDENTITY()
				INSERT INTO [dbo].PostSEO
				VALUES(@postId,@title_SEO,@description_SEO,@canonical,@breadcrumbsTitle,@metaRobotIndex,
				@metaRobotFollow,@metaRobotAdvanced)

				-- INSERT POST_TRANS
				INSERT INTO [dbo].PostTrans
				VALUES(@postId,@languageId,@title_Trans,@decription_Trans,@detail,@tag)

				-- INSERT INTO PostStateHistory
				SET IDENTITY_INSERT [dbo].PostStateHistory ON
				INSERT INTO PostStateHistory
				VALUES(@postId,@workflowStateId,@userId,@note,GETDATE())
				SET IDENTITY_INSERT [dbo].PostStateHistory OFF
			END				
			IF @Action = 'U' 
			BEGIN
				-- UPDATE POST
				UPDATE [dbo].Post
				SET [Date] = @date, [Image] = @image, [Author] = @author, [WorkflowStateId] = @workflowStateId,
				[CategoryId] = @categoryId, [Status] = @status, [CreatedDate] = GETDATE(), [CreatedBy] = @createdBy,
				[ModifiedDate] = GETDATE(), [ModifiedBy] = @modifiedBy
				WHERE [Id] = @postId

				-- UPDATE POST_SEO
				UPDATE [dbo].PostSEO
				SET [PostId] = @postId, [Title] = @title_SEO, [Description] = @description_SEO,
				[Canonical] = @canonical, [BreadcrumbsTitle] = @breadcrumbsTitle, [MetaRobotIndex] = @metaRobotIndex,
				[MetaRobotFollow] = @metaRobotFollow, [MetaRobotAdvanced] = @metaRobotAdvanced
				WHERE [PostId] = @postId

				-- UPDATE POST_TRANS
				UPDATE [dbo].PostTrans
				SET [PostId] = @postId, [LanguageId] = @languageId, [Title] = @title_Trans,
				[Description] = @decription_Trans, [Detail] = @detail, [Tag] = @tag
				WHERE [PostId] = @postId AND [LanguageId] = @languageId

				-- UPDATE POST_STATE_HISTORY
				UPDATE [dbo].PostStateHistory
				SET [PostId] = @postId, [WorkflowStateId] = @workflowStateId, [UserId] = @userId,
				[Note] = @note, [CreatedDate] = GETDATE()
				WHERE [Id] = @idPostStateHis AND [PostId] = @postId
			END
			IF @Action = 'D' 
			BEGIN
				-- DELETE POST_SEO
				DELETE FROM [dbo].PostSEO
				WHERE [PostId] = @postId

				-- DELTE POST_TRANS
				DELETE FROM [dbo].PostTrans
				WHERE [PostId] = @postId

				-- DELETE POST
				DELETE FROM [dbo].Post 
				WHERE [Id] = @id
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
PRINT N'Creating [dbo].[usp_DefaultData_Insert]...';


GO
create proc usp_DefaultData_Insert
as
begin
	SET NOCOUNT ON
		SET TRANSACTION ISOLATION LEVEL READ COMMITTED

		BEGIN TRY
			declare @countCat int;
			---Insert Category
			set @countCat = (SELECT count(*) FROM [dbo].[Category]);
			if(@countCat = 0)
			begin
				insert into Category(Name, Handler, Sort, ParentId) values(N'Tin sức khỏe', N'', 1, 0)
			end
			
			---Insert workflow
			declare @countWorkflow int;
			set @countWorkflow = (select COUNT(*) from [dbo].Workflow);
			if(@countWorkflow = 0)
			begin
				insert into Workflow(Name) values(N'workflow 1')
			end

			---Insert workfow state
			declare @countWorkflowSate int;
			set @countWorkflowSate = (select COUNT(*) from WorkflowState)
			if(@countWorkflowSate = 0)
			begin
				declare @workflowId tinyint;
				set @workflowId = (SELECT MAX(Id) FROM Workflow)
				insert into WorkflowState(Name, WorkflowId, IsActive) values(N'work flow state 1', @workflowId, 1)
			end
		END TRY
		BEGIN CATCH
			IF @@TRANCOUNT <> 0 
			BEGIN
				RETURN NULL
			END
	END CATCH
end
GO
PRINT N'Creating [dbo].[usp_DefaultData_Exec]...';


GO


create proc [dbo].[usp_DefaultData_Exec]
as
begin
	exec usp_DefaultData_Insert
end
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
