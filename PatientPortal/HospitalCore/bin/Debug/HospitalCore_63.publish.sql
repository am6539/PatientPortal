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
/*
The column [dbo].[Survey].[IsBrading] is being dropped, data loss could occur.
*/

IF EXISTS (select top 1 1 from [dbo].[Survey])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
/*
The column [dbo].[SurveyAnswers].[IsRandomize] is being dropped, data loss could occur.

The column [dbo].[SurveyAnswers].[IsRequired] is being dropped, data loss could occur.
*/

IF EXISTS (select top 1 1 from [dbo].[SurveyAnswers])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
/*
The column [dbo].[SurveyQuestions].[IsRandomize] on table [dbo].[SurveyQuestions] must be added, but the column has no default value and does not allow NULL values. If the table contains data, the ALTER script will not work. To avoid this issue you must either: add a default value to the column, mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.

The column [dbo].[SurveyQuestions].[IsRequired] on table [dbo].[SurveyQuestions] must be added, but the column has no default value and does not allow NULL values. If the table contains data, the ALTER script will not work. To avoid this issue you must either: add a default value to the column, mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.
*/

IF EXISTS (select top 1 1 from [dbo].[SurveyQuestions])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
PRINT N'Dropping unnamed constraint on [dbo].[Survey]...';


GO
ALTER TABLE [dbo].[Survey] DROP CONSTRAINT [DF__tmp_ms_xx__IsBra__54CB950F];


GO
PRINT N'Dropping unnamed constraint on [dbo].[Survey]...';


GO
ALTER TABLE [dbo].[Survey] DROP CONSTRAINT [DF__tmp_ms_xx__IsSur__55BFB948];


GO
PRINT N'Dropping unnamed constraint on [dbo].[Survey]...';


GO
ALTER TABLE [dbo].[Survey] DROP CONSTRAINT [DF__tmp_ms_xx__IsPub__56B3DD81];


GO
PRINT N'Dropping unnamed constraint on [dbo].[Survey]...';


GO
ALTER TABLE [dbo].[Survey] DROP CONSTRAINT [DF__tmp_ms_xx__IsAct__57A801BA];


GO
PRINT N'Dropping unnamed constraint on [dbo].[SurveyAnswers]...';


GO
ALTER TABLE [dbo].[SurveyAnswers] DROP CONSTRAINT [DF__SurveyAns__Hight__2704CA5F];


GO
PRINT N'Dropping unnamed constraint on [dbo].[SurveyAnswers]...';


GO
ALTER TABLE [dbo].[SurveyAnswers] DROP CONSTRAINT [DF__SurveyAns__LowSc__2610A626];


GO
PRINT N'Dropping [dbo].[FK_SurveyQuestions_Survey]...';


GO
ALTER TABLE [dbo].[SurveyQuestions] DROP CONSTRAINT [FK_SurveyQuestions_Survey];


GO
PRINT N'Starting rebuilding table [dbo].[Survey]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Survey] (
    [Id]             VARCHAR (128)  NOT NULL,
    [Title]          NVARCHAR (150) NOT NULL,
    [Description]    NVARCHAR (MAX) NOT NULL,
    [Message]        NVARCHAR (300) NOT NULL,
    [IsBranding]     BIT            DEFAULT 1 NULL,
    [Logo]           VARCHAR (256)  NULL,
    [Url]            VARCHAR (256)  NULL,
    [IsSurveyInvite] BIT            DEFAULT 0 NULL,
    [IsPublic]       BIT            DEFAULT 0 NULL,
    [IsActive]       BIT            DEFAULT 0 NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Survey])
    BEGIN
        INSERT INTO [dbo].[tmp_ms_xx_Survey] ([Id], [Title], [Description], [Message], [Logo], [URL], [IsSurveyInvite], [IsPublic], [IsActive])
        SELECT   [Id],
                 [Title],
                 [Description],
                 [Message],
                 [Logo],
                 [URL],
                 [IsSurveyInvite],
                 [IsPublic],
                 [IsActive]
        FROM     [dbo].[Survey]
        ORDER BY [Id] ASC;
    END

DROP TABLE [dbo].[Survey];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Survey]', N'Survey';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Altering [dbo].[SurveyAnswers]...';


GO
ALTER TABLE [dbo].[SurveyAnswers] DROP COLUMN [IsRandomize], COLUMN [IsRequired];


GO
ALTER TABLE [dbo].[SurveyAnswers] ALTER COLUMN [HightScore] NVARCHAR (128) NULL;

ALTER TABLE [dbo].[SurveyAnswers] ALTER COLUMN [LowScore] NVARCHAR (128) NULL;


GO
PRINT N'Altering [dbo].[SurveyQuestions]...';


GO
ALTER TABLE [dbo].[SurveyQuestions]
    ADD [IsRequired]  BIT NOT NULL,
        [IsRandomize] BIT NOT NULL;


GO
PRINT N'Creating unnamed constraint on [dbo].[SurveyAnswers]...';


GO
ALTER TABLE [dbo].[SurveyAnswers]
    ADD DEFAULT 0 FOR [HightScore];


GO
PRINT N'Creating unnamed constraint on [dbo].[SurveyAnswers]...';


GO
ALTER TABLE [dbo].[SurveyAnswers]
    ADD DEFAULT 0 FOR [LowScore];


GO
PRINT N'Creating [dbo].[FK_SurveyQuestions_Survey]...';


GO
ALTER TABLE [dbo].[SurveyQuestions] WITH NOCHECK
    ADD CONSTRAINT [FK_SurveyQuestions_Survey] FOREIGN KEY ([SurveyId]) REFERENCES [dbo].[Survey] ([Id]);


GO
PRINT N'Altering [dbo].[usp_spa_User_HasScheduleExamine]...';


GO
ALTER PROCEDURE [dbo].usp_spa_User_HasScheduleExamine
	@Search nvarchar(250) = ''
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED

	BEGIN TRY
		
		DECLARE @bod DATETIME2
		SET @bod = cast (GETDATE() AS DATE) 
		SELECT DISTINCT 
				dbo.Users.*
		FROM    dbo.Schedule INNER JOIN
				dbo.Users ON dbo.Schedule.UserId = dbo.Users.Id
		WHERE   (dbo.Users.IsDoctor = 1)
				AND (Name like '%' + @Search + '%' OR @Search is null)
				AND (Tags like '%' + @Search + '%' OR @Search is null)
				AND IsExamine = 1
				AND GETDATE() BETWEEN 
				[Start] AND DATEADD(DAY, 2,DATEADD(ns, -100, DATEADD(s, 86400, @bod )))

	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT <> 0 
		BEGIN
			RETURN NULL
		END
	END CATCH
END
GO
PRINT N'Creating [dbo].[usp_Survey]...';


GO
CREATE PROCEDURE [dbo].[usp_Survey]
	@Id TINYINT
AS
	IF(@Id > 0)
	BEGIN
		SELECT * FROM [dbo].[Survey]
		WHERE [Id] = @Id
	END
	ELSE
	BEGIN
		SELECT * FROM [dbo].[Survey]
	END
RETURN 0
GO
PRINT N'Creating [dbo].[usp_Survey_Transaction]...';


GO
CREATE PROC [dbo].[usp_Survey_Transaction]
(
	@Action CHAR(1) = 'I',
	@Id VARCHAR(128) = '',
	@Title NVARCHAR(150) = '',
	@Description NVARCHAR(MAX) = '',
	@Message NVARCHAR(300) = '',
	@IsBranding BIT = 1,
	@Logo VARCHAR(256),
	@Url VARCHAR(256),
	@IsSurveyInvite BIT = 0,
	@IsPublic BIT = 0,
	@IsActive BIT = 0
)
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED
	DECLARE @return INT = 0

	BEGIN TRY
		BEGIN TRAN;
			IF @Action = 'I' --INSERT
			BEGIN
				INSERT [dbo].[Survey] VALUES(@Id, @Title, @Description, @Message, @IsBranding, @Logo, @Url, @IsSurveyInvite, @IsPublic, @IsActive)

				SET @return = 1
			END

			IF @Action = 'U' --UPDATE
			BEGIN
				UPDATE [dbo].[Survey]
				SET [Title] = @Title, [Description] = @Description, [Message] = @Message, [IsBranding] = @IsBranding, [Logo] = @Logo, [Url] = @Url, [IsSurveyInvite] = @IsSurveyInvite, [IsPublic] = @IsPublic, [IsActive] = @IsActive
				WHERE [Id] = @Id  

				SET @return = 1
			END

			IF @Action = 'D' --DELETE
			BEGIN
				BEGIN
					DELETE FROM [dbo].[Survey]
					WHERE [Id] = @Id

					SET @return = 1
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
	SELECT @return;
END
GO
PRINT N'Creating [dbo].[usp_SurveyAnswers_Transaction]...';


GO
CREATE PROC [dbo].[usp_SurveyAnswers_Transaction]
(
	@Action CHAR(1) = 'I',
	@Id TINYINT,
	@QuestionId VARCHAR(128) = '',
	@Answer NVARCHAR(150) = '',
	@LowScore NVARCHAR(128) = '',
	@HightScore NVARCHAR(128) = ''
)
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED
	DECLARE @return INT = 0

	BEGIN TRY
		BEGIN TRAN;
			IF @Action = 'I' --INSERT
			BEGIN
				INSERT [dbo].[SurveyAnswers] VALUES(@Id, @QuestionId, @Answer, @LowScore, @HightScore)

				SET @return = 1
			END

			IF @Action = 'U' --UPDATE
			BEGIN
				UPDATE [dbo].[SurveyAnswers]
				SET [QuestionId] = @QuestionId, [Answer] = @Answer, [LowScore] = @LowScore, [HightScore] = @HightScore
				WHERE [Id] = @Id  

				SET @return = 1
			END

			IF @Action = 'D' --DELETE
			BEGIN
				BEGIN
					DELETE FROM [dbo].[SurveyAnswers]
					WHERE [Id] = @Id

					SET @return = 1
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
	SELECT @return;
END
GO
PRINT N'Creating [dbo].[usp_SurveyQuestions_Transaction]...';


GO
CREATE PROC [dbo].[usp_SurveyQuestions_Transaction]
(
	@Action CHAR(1) = 'I',
	@Id VARCHAR(128) = '',
	@SurveyId VARCHAR(128) = '',
	@Question NVARCHAR(300) = '',
	@Type TINYINT,
	@IsRequired BIT = 0,
	@IsRandomize BIT = 0
)
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED
	DECLARE @return INT = 0

	BEGIN TRY
		BEGIN TRAN;
			IF @Action = 'I' --INSERT
			BEGIN
				INSERT [dbo].[SurveyQuestions] VALUES(@Id, @SurveyId, @Question, @Type, @IsRequired, @IsRandomize)

				SET @return = 1
			END

			IF @Action = 'U' --UPDATE
			BEGIN
				UPDATE [dbo].[SurveyQuestions]
				SET [SurveyId] = @SurveyId, [Question] = @Question, [Type] = @Type, [IsRequired] = @IsRequired, [IsRandomize] = @IsRandomize
				WHERE [Id] = @Id  

				SET @return = 1
			END

			IF @Action = 'D' --DELETE
			BEGIN
				BEGIN
					DELETE FROM [dbo].[SurveyQuestions]
					WHERE [Id] = @Id

					SET @return = 1
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
	SELECT @return;
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
DELETE FROM [dbo].[Group]
GO
INSERT INTO [dbo].[Group] VALUES(N'Content Management System (CMS)', 1)
GO
INSERT INTO [dbo].[Group] VALUES(N'Patient Services', 1)
GO
INSERT INTO [dbo].[Group] VALUES(N'Internal Services', 1)
GO

GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[SurveyQuestions] WITH CHECK CHECK CONSTRAINT [FK_SurveyQuestions_Survey];


GO
PRINT N'Update complete.';


GO
