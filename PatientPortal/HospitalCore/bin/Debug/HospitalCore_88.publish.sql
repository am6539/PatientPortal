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
The column [dbo].[QA].[Doctor] is being dropped, data loss could occur.

The column [dbo].[QA].[DoctorId] on table [dbo].[QA] must be added, but the column has no default value and does not allow NULL values. If the table contains data, the ALTER script will not work. To avoid this issue you must either: add a default value to the column, mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.
*/

IF EXISTS (select top 1 1 from [dbo].[QA])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
PRINT N'Starting rebuilding table [dbo].[QA]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_QA] (
    [Id]         INT             IDENTITY (1, 1) NOT NULL,
    [Date]       SMALLDATETIME   NOT NULL,
    [Title]      NVARCHAR (150)  NOT NULL,
    [Question]   NVARCHAR (1000) NOT NULL,
    [Name]       NVARCHAR (32)   NOT NULL,
    [Email]      VARCHAR (256)   NULL,
    [Phone]      VARCHAR (20)    NULL,
    [DoctorId]   NVARCHAR (128)  NOT NULL,
    [Answer]     NVARCHAR (MAX)  NOT NULL,
    [Department] NVARCHAR (100)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[QA])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_QA] ON;
        INSERT INTO [dbo].[tmp_ms_xx_QA] ([Id], [Date], [Title], [Question], [Name], [Email], [Phone], [Answer], [Department])
        SELECT   [Id],
                 [Date],
                 [Title],
                 [Question],
                 [Name],
                 [Email],
                 [Phone],
                 [Answer],
                 [Department]
        FROM     [dbo].[QA]
        ORDER BY [Id] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_QA] OFF;
    END

DROP TABLE [dbo].[QA];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_QA]', N'QA';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Altering [dbo].[usp_QA_Transaction]...';


GO

ALTER PROC [dbo].[usp_QA_Transaction]
(
	@Action CHAR(1) = 'I',
	@Id INT = 1,
	@Title NVARCHAR(150) = '',
	@Question NVARCHAR(1000) = '',
	@Name NVARCHAR(32) = '',
	@Email VARCHAR(256),
	@Phone VARCHAR(20),
	@Doctor NVARCHAR(100) = '',
	@Answer NVARCHAR(MAX) = '',
	@Department NVARCHAR(100) = ''
)
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED
	DECLARE @return INT = 0

	BEGIN TRY
		BEGIN TRAN;
			DECLARE @Date SMALLDATETIME

			IF @Action = 'I' --INSERT
			BEGIN
				SET @Date = GETDATE()

				INSERT [dbo].[QA] VALUES(@Date, @Title, @Question, @Name, @Email, @Phone, @Doctor, @Answer, @Department)

				SET @return = 1
			END

			IF @Action = 'U' --UPDATE
			BEGIN
				UPDATE [dbo].[QA]
				SET [Title] = @Title, [Question] = @Question, [Name] = @Name, [Email] = @Email, [Phone] = @Phone, [DoctorId] = @Doctor, [Answer] =  @Answer, [Department] = @Department
				WHERE [Id] = @Id  

				SET @return = 1
			END

			IF @Action = 'D' --DELETE
			BEGIN
				BEGIN
					DELETE FROM [dbo].[QA]
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
PRINT N'Creating [dbo].[usp_spa_QA]...';


GO
CREATE PROCEDURE [dbo].[usp_spa_QA]
	@pageIndex TINYINT = 1, 
	@numberInPage TINYINT = 10, 
	@Search nvarchar(250) = '',
	@totalItem int out
AS BEGIN
	BEGIN TRY
	SET NOCOUNT ON
		SET TRANSACTION ISOLATION LEVEL READ COMMITTED

		BEGIN
				SELECT  *, ROW_NUMBER() OVER (ORDER BY [Date]) AS RowNum INTO #tmpPost FROM (
					
				SELECT 
					q.*,
					u.[Name]
				FROM 
					[dbo].QA q, 
					[dbo].Users u
				WHERE 
					q.DoctorId = u.Id
					AND ((q.Title like '%' + @Search + '%' OR  @Search is null OR @Search = '')
					OR (q.Question like N'%' + @Search +'%' OR  @Search is null OR @Search = ''))

				) AS tmp
				

				set @totalItem = (SELECT count(*) FROM #tmpPost)
				SELECT  *
				FROM	#tmpPost
				WHERE   RowNum BETWEEN (@PageIndex - 1) * @numberInPage + 1
						AND @PageIndex * @numberInPage ;
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
PRINT N'Refreshing [dbo].[usp_QA]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[usp_QA]';


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
PRINT N'Update complete.';


GO
