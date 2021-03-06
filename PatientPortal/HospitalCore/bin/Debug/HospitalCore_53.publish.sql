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
The type for column Name in table [dbo].[Role] is currently  NVARCHAR (256) NOT NULL but is being changed to  NVARCHAR (128) NOT NULL. Data loss could occur.
*/

IF EXISTS (select top 1 1 from [dbo].[Role])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
/*
The column [dbo].[Users].[Code] on table [dbo].[Users] must be added, but the column has no default value and does not allow NULL values. If the table contains data, the ALTER script will not work. To avoid this issue you must either: add a default value to the column, mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.

The column [dbo].[Users].[HomePhone] on table [dbo].[Users] must be added, but the column has no default value and does not allow NULL values. If the table contains data, the ALTER script will not work. To avoid this issue you must either: add a default value to the column, mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.

The column [dbo].[Users].[Status] on table [dbo].[Users] must be added, but the column has no default value and does not allow NULL values. If the table contains data, the ALTER script will not work. To avoid this issue you must either: add a default value to the column, mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.

The column DoB on table [dbo].[Users] must be changed from NULL to NOT NULL. If the table contains data, the ALTER script may not work. To avoid this issue, you must add values to this column for all rows or mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.

The column Image on table [dbo].[Users] must be changed from NULL to NOT NULL. If the table contains data, the ALTER script may not work. To avoid this issue, you must add values to this column for all rows or mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.

The type for column Image in table [dbo].[Users] is currently  NVARCHAR (MAX) NULL but is being changed to  VARCHAR (256) NOT NULL. Data loss could occur.

The column Name on table [dbo].[Users] must be changed from NULL to NOT NULL. If the table contains data, the ALTER script may not work. To avoid this issue, you must add values to this column for all rows or mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.

The type for column OrganizationId in table [dbo].[Users] is currently  INT NOT NULL but is being changed to  SMALLINT NOT NULL. Data loss could occur.

The column PatientId on table [dbo].[Users] must be changed from NULL to NOT NULL. If the table contains data, the ALTER script may not work. To avoid this issue, you must add values to this column for all rows or mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.

The column Tags on table [dbo].[Users] must be changed from NULL to NOT NULL. If the table contains data, the ALTER script may not work. To avoid this issue, you must add values to this column for all rows or mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.
*/

IF EXISTS (select top 1 1 from [dbo].[Users])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
PRINT N'Rename refactoring operation with key 43d96ec9-b487-4601-8a5b-066abec94212 is skipped, element [dbo].[Users].[DateOfBirth] (SqlSimpleColumn) will not be renamed to DoB';


GO
PRINT N'Dropping [dbo].[Message].[idxMessageReceiver]...';


GO
DROP INDEX [idxMessageReceiver]
    ON [dbo].[Message];


GO
PRINT N'Dropping [dbo].[Message].[idxMessageSender]...';


GO
DROP INDEX [idxMessageSender]
    ON [dbo].[Message];


GO
PRINT N'Dropping [dbo].[Role].[RoleNameIndex]...';


GO
DROP INDEX [RoleNameIndex]
    ON [dbo].[Role];


GO
PRINT N'Dropping [dbo].[UserRole].[IX_RoleId]...';


GO
DROP INDEX [IX_RoleId]
    ON [dbo].[UserRole];


GO
PRINT N'Dropping [dbo].[UserRole].[IX_UserId]...';


GO
DROP INDEX [IX_UserId]
    ON [dbo].[UserRole];


GO
PRINT N'Dropping [dbo].[Users].[UserNameIndex]...';


GO
DROP INDEX [UserNameIndex]
    ON [dbo].[Users];


GO
PRINT N'Dropping unnamed constraint on [dbo].[MessageRecipient]...';


GO
ALTER TABLE [dbo].[MessageRecipient] DROP CONSTRAINT [DF__MessageRe__IsUse__3E52440B];


GO
PRINT N'Dropping [dbo].[FK_MessageRecipient_Message]...';


GO
ALTER TABLE [dbo].[MessageRecipient] DROP CONSTRAINT [FK_MessageRecipient_Message];


GO
PRINT N'Dropping [dbo].[FK_dbo.UserRole_dbo.Users_UserId]...';


GO
ALTER TABLE [dbo].[UserRole] DROP CONSTRAINT [FK_dbo.UserRole_dbo.Users_UserId];


GO
PRINT N'Dropping [dbo].[FK_dbo.UserClaim_dbo.Users_UserId]...';


GO
ALTER TABLE [dbo].[UserClaim] DROP CONSTRAINT [FK_dbo.UserClaim_dbo.Users_UserId];


GO
PRINT N'Dropping [dbo].[FK_dbo.UserLogin_dbo.Users_UserId]...';


GO
ALTER TABLE [dbo].[UserLogin] DROP CONSTRAINT [FK_dbo.UserLogin_dbo.Users_UserId];


GO
PRINT N'Dropping [dbo].[FK_dbo.UserRole_dbo.Role_RoleId]...';


GO
ALTER TABLE [dbo].[UserRole] DROP CONSTRAINT [FK_dbo.UserRole_dbo.Role_RoleId];


GO
PRINT N'Altering [dbo].[Article]...';


GO
ALTER TABLE [dbo].[Article] ALTER COLUMN [PatientId] NVARCHAR (128) NOT NULL;


GO
PRINT N'Altering [dbo].[ArticleComment]...';


GO
ALTER TABLE [dbo].[ArticleComment] ALTER COLUMN [CreatedUser] NVARCHAR (128) NOT NULL;


GO
PRINT N'Altering [dbo].[Message]...';


GO
ALTER TABLE [dbo].[Message] ALTER COLUMN [ReceiverId] NVARCHAR (128) NOT NULL;

ALTER TABLE [dbo].[Message] ALTER COLUMN [SenderId] NVARCHAR (128) NOT NULL;


GO
PRINT N'Creating [dbo].[Message].[idxMessageReceiver]...';


GO
CREATE NONCLUSTERED INDEX [idxMessageReceiver]
    ON [dbo].[Message]([ReceiverId] ASC);


GO
PRINT N'Creating [dbo].[Message].[idxMessageSender]...';


GO
CREATE NONCLUSTERED INDEX [idxMessageSender]
    ON [dbo].[Message]([SenderId] ASC);


GO
PRINT N'Starting rebuilding table [dbo].[MessageRecipient]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_MessageRecipient] (
    [MessageId]  INT            NOT NULL,
    [ReceiverId] NVARCHAR (128) NOT NULL,
    [IsUsed]     BIT            DEFAULT 1 NOT NULL,
    CONSTRAINT [tmp_ms_xx_constraint_PK_MessageRecipient1] PRIMARY KEY CLUSTERED ([MessageId] ASC, [ReceiverId] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[MessageRecipient])
    BEGIN
        INSERT INTO [dbo].[tmp_ms_xx_MessageRecipient] ([MessageId], [ReceiverId], [IsUsed])
        SELECT   [MessageId],
                 [ReceiverId],
                 [IsUsed]
        FROM     [dbo].[MessageRecipient]
        ORDER BY [MessageId] ASC, [ReceiverId] ASC;
    END

DROP TABLE [dbo].[MessageRecipient];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_MessageRecipient]', N'MessageRecipient';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_PK_MessageRecipient1]', N'PK_MessageRecipient', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Altering [dbo].[OfferAdvise]...';


GO
ALTER TABLE [dbo].[OfferAdvise] ALTER COLUMN [PatientId] NVARCHAR (128) NOT NULL;


GO
PRINT N'Starting rebuilding table [dbo].[Role]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Role] (
    [Id]   NVARCHAR (128) NOT NULL,
    [Name] NVARCHAR (128) NOT NULL,
    CONSTRAINT [tmp_ms_xx_constraint_PK_Role1] PRIMARY KEY CLUSTERED ([Id] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Role])
    BEGIN
        INSERT INTO [dbo].[tmp_ms_xx_Role] ([Id], [Name])
        SELECT   [Id],
                 [Name]
        FROM     [dbo].[Role]
        ORDER BY [Id] ASC;
    END

DROP TABLE [dbo].[Role];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Role]', N'Role';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_PK_Role1]', N'PK_Role', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[Users]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Users] (
    [Id]                   NVARCHAR (128) NOT NULL,
    [Email]                NVARCHAR (256) NULL,
    [EmailConfirmed]       BIT            NOT NULL,
    [PasswordHash]         NVARCHAR (MAX) NULL,
    [SecurityStamp]        NVARCHAR (MAX) NULL,
    [PhoneNumber]          NVARCHAR (MAX) NULL,
    [PhoneNumberConfirmed] BIT            NOT NULL,
    [TwoFactorEnabled]     BIT            NOT NULL,
    [LockoutEndDateUtc]    DATETIME       NULL,
    [LockoutEnabled]       BIT            NOT NULL,
    [AccessFailedCount]    INT            NOT NULL,
    [UserName]             NVARCHAR (256) NOT NULL,
    [OrganizationId]       SMALLINT       NOT NULL,
    [Tags]                 NVARCHAR (250) NOT NULL,
    [HomePhone]            VARCHAR (20)   NOT NULL,
    [IsAdmin]              BIT            NOT NULL,
    [IsDoctor]             BIT            NOT NULL,
    [Gender]               TINYINT        NOT NULL,
    [Code]                 CHAR (20)      NOT NULL,
    [Name]                 NVARCHAR (100) NOT NULL,
    [PatientId]            NVARCHAR (128) NOT NULL,
    [DoB]                  DATE           NOT NULL,
    [Image]                VARCHAR (256)  NOT NULL,
    [Status]               BIT            NOT NULL,
    UNIQUE NONCLUSTERED ([Email] ASC),
    CONSTRAINT [tmp_ms_xx_constraint_PK_USERS1] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [tmp_ms_xx_constraint_UQ__USERS__A9D1053429B4C0C01] UNIQUE NONCLUSTERED ([Email] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Users])
    BEGIN
        INSERT INTO [dbo].[tmp_ms_xx_Users] ([Id], [Name], [PatientId], [DoB], [Gender], [Image], [OrganizationId], [IsDoctor], [IsAdmin], [Tags], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName])
        SELECT   [Id],
                 [Name],
                 [PatientId],
                 [DoB],
                 [Gender],
                 [Image],
                 [OrganizationId],
                 [IsDoctor],
                 [IsAdmin],
                 [Tags],
                 [Email],
                 [EmailConfirmed],
                 [PasswordHash],
                 [SecurityStamp],
                 [PhoneNumber],
                 [PhoneNumberConfirmed],
                 [TwoFactorEnabled],
                 [LockoutEndDateUtc],
                 [LockoutEnabled],
                 [AccessFailedCount],
                 [UserName]
        FROM     [dbo].[Users]
        ORDER BY [Id] ASC;
    END

DROP TABLE [dbo].[Users];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Users]', N'Users';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_PK_USERS1]', N'PK_USERS', N'OBJECT';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_UQ__USERS__A9D1053429B4C0C01]', N'UQ__USERS__A9D1053429B4C0C0', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Creating [dbo].[Users].[idxUserAccess]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [idxUserAccess]
    ON [dbo].[Users]([Code] ASC, [Email] ASC);


GO
PRINT N'Starting rebuilding table [dbo].[UserRole]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_UserRole] (
    [UserId] NVARCHAR (128) NOT NULL,
    [RoleId] NVARCHAR (128) NOT NULL,
    CONSTRAINT [tmp_ms_xx_constraint_PK_UserRole1] PRIMARY KEY CLUSTERED ([UserId] ASC, [RoleId] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[UserRole])
    BEGIN
        INSERT INTO [dbo].[tmp_ms_xx_UserRole] ([UserId], [RoleId])
        SELECT   [UserId],
                 [RoleId]
        FROM     [dbo].[UserRole]
        ORDER BY [UserId] ASC, [RoleId] ASC;
    END

DROP TABLE [dbo].[UserRole];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_UserRole]', N'UserRole';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_PK_UserRole1]', N'PK_UserRole', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Creating [dbo].[Permission]...';


GO
CREATE TABLE [dbo].[Permission] (
    [RoleId]    SMALLINT NOT NULL,
    [ModuleId]  SMALLINT NOT NULL,
    [IsRead]    BIT      NOT NULL,
    [IsWrite]   BIT      NOT NULL,
    [IsCreate]  BIT      NOT NULL,
    [IsModify]  BIT      NOT NULL,
    [IsDestroy] BIT      NOT NULL,
    [IsPrint]   BIT      NOT NULL,
    CONSTRAINT [PK_Permission] PRIMARY KEY CLUSTERED ([RoleId] ASC, [ModuleId] ASC)
);


GO
PRINT N'Creating [dbo].[UserGroup]...';


GO
CREATE TABLE [dbo].[UserGroup] (
    [UserId]  NVARCHAR (128) NOT NULL,
    [GroupId] TINYINT        NOT NULL,
    CONSTRAINT [PK_UserGroup] PRIMARY KEY CLUSTERED ([UserId] ASC, [GroupId] ASC)
);


GO
PRINT N'Creating [dbo].[FK_MessageRecipient_Message]...';


GO
ALTER TABLE [dbo].[MessageRecipient] WITH NOCHECK
    ADD CONSTRAINT [FK_MessageRecipient_Message] FOREIGN KEY ([MessageId]) REFERENCES [dbo].[Message] ([Id]);


GO
PRINT N'Creating [dbo].[FK_Users_Organization]...';


GO
ALTER TABLE [dbo].[Users] WITH NOCHECK
    ADD CONSTRAINT [FK_Users_Organization] FOREIGN KEY ([OrganizationId]) REFERENCES [dbo].[Organization] ([Id]);


GO
PRINT N'Creating [dbo].[FK_UserRole_Role]...';


GO
ALTER TABLE [dbo].[UserRole] WITH NOCHECK
    ADD CONSTRAINT [FK_UserRole_Role] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role] ([Id]);


GO
PRINT N'Creating [dbo].[FK_UserRole_Users]...';


GO
ALTER TABLE [dbo].[UserRole] WITH NOCHECK
    ADD CONSTRAINT [FK_UserRole_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]);


GO
PRINT N'Creating [dbo].[FK_Permission_Module]...';


GO
ALTER TABLE [dbo].[Permission] WITH NOCHECK
    ADD CONSTRAINT [FK_Permission_Module] FOREIGN KEY ([ModuleId]) REFERENCES [dbo].[Module] ([Id]);


GO
PRINT N'Creating [dbo].[FK_UserGroup_Group]...';


GO
ALTER TABLE [dbo].[UserGroup] WITH NOCHECK
    ADD CONSTRAINT [FK_UserGroup_Group] FOREIGN KEY ([GroupId]) REFERENCES [dbo].[Group] ([Id]);


GO
PRINT N'Creating [dbo].[FK_UserGroup_Users]...';


GO
ALTER TABLE [dbo].[UserGroup] WITH NOCHECK
    ADD CONSTRAINT [FK_UserGroup_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]);


GO
PRINT N'Altering [dbo].[usp_Article_Transaction]...';


GO
ALTER PROC [dbo].[usp_Article_Transaction]
(
	@Action CHAR(1) = 'I',
	@Id INT = 1,
	@Date datetime,
	@Title NVARCHAR(150) = '',
	@Detail NVARCHAR(1000) = '',
	@PatientId NVARCHAR(128) = 0,
	@Status TINYINT = 1,
	@IsClosed BIT, 
	@CountComments INT
)
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED
	DECLARE @return INT = 0
	DECLARE @CurrentDate SMALLDATETIME

	BEGIN TRY
		BEGIN TRAN;
			SET @CurrentDate = GETDATE()

			IF @Action = 'I' --INSERT
			BEGIN
				INSERT [dbo].[Article]
				VALUES(@CurrentDate, @Title, @Detail, @PatientId, @Status, @IsClosed)

				SET @return = SCOPE_IDENTITY()
			END

			IF @Action = 'U' --UPDATE
			BEGIN
				IF NOT EXISTS(SELECT TOP 1 1 FROM [dbo].[ArticleComment] WHERE [ArticleId] = @Id)
				BEGIN
					UPDATE [dbo].[Article]
					SET [Title] = @Title, [Detail] = @Detail, [Status] = @Status, [IsClosed] = @IsClosed
					WHERE [Id] = @Id  

					SET @return = @Id
				END
				ELSE
					SET @return = 0
			END

			IF @Action = 'D' --DELETE
			BEGIN
				IF NOT EXISTS(SELECT TOP 1 1 FROM [dbo].[ArticleComment] WHERE [ArticleId] = @Id)
				BEGIN	
					-- Article Comment Table
					DELETE FROM [dbo].[ArticleComment] WHERE [ArticleId] = @Id

					-- Article Table
					DELETE FROM [dbo].[Article] WHERE [Id] = @Id

					SET @return = @Id
				END
				ELSE
					SET @return = 0
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
PRINT N'Altering [dbo].[usp_ArticleComment_Transaction]...';


GO
ALTER PROC [dbo].[usp_ArticleComment_Transaction]
(
	@Action CHAR(1) = 'I',
	@Id INT = 1,
	@ArticleId SMALLINT = 1,
	@Date datetime,
	@Detail NVARCHAR(1000) ='',
	@CreatedUser NVARCHAR(128) = 0,
	@Status TINYINT = 1
)
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED
	DECLARE @return INT = 0
	DECLARE @CurrentDate SMALLDATETIME

	BEGIN TRY
		BEGIN TRAN;
			SET @CurrentDate = GETDATE()

			IF @Action = 'I' --INSERT
			BEGIN				
				SELECT @Id = ISNULL(MAX([Id]),0) + 1 FROM [dbo].[ArticleComment] WHERE [ArticleId] = @ArticleId
				INSERT [dbo].[ArticleComment]
				VALUES(@Id, @ArticleId, @CurrentDate, @Detail, @CreatedUser, @Status)

				--SET @return = SCOPE_IDENTITY()
				SET @return = @Id
			END

			IF @Action = 'U' --UPDATE
			BEGIN
				IF @ArticleId > 0 AND @Id > 0
				BEGIN

					UPDATE [dbo].[ArticleComment]
					SET [Detail] = @Detail, [Status] = @Status, [Date] = @CurrentDate
					WHERE [Id] = @Id  AND [ArticleId] = @ArticleId
					
					SET @return = @Id
					print @return
				END
				ELSE
					SET @return = 0
			END

			IF @Action = 'D' --DELETE
			BEGIN
				IF @ArticleId > 0 AND @Id > 0
				BEGIN
					DELETE FROM [dbo].[ArticleComment]
					WHERE [Id] = @Id  AND [ArticleId] = @ArticleId

					SET @return = @Id
				END
				ELSE
					SET @return = 0
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
PRINT N'Altering [dbo].[usp_Message]...';


GO
ALTER PROC [dbo].[usp_Message]
(
	@FolderId TINYINT = 1,
	@UserId NVARCHAR(128) = '',
	@PageIndex INT,
	@NumberInPage INT,
	@TotalItem INT OUT
)
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED

	BEGIN TRY
		-- Folder: Inbox, Sent, Draff, Trash
		SELECT *, ROW_NUMBER() OVER (ORDER BY [Date],[Id] DESC) AS RowNumb 
		INTO #DataTMP
		FROM (SELECT * FROM [dbo].[Message]
		WHERE [FolderId] = @FolderId AND ([SenderId] = @UserId OR [ReceiverId] = @UserId)) AS Tmp

		SELECT @TotalItem = COUNT([Id]) FROM #DataTMP

		-- Paging
		SELECT * FROM #DataTMP
		WHERE RowNum BETWEEN (@PageIndex - 1) * @NumberInPage + 1
				AND @PageIndex * @NumberInPage ;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT <> 0 
		BEGIN
			RETURN NULL
		END
	END CATCH
END
GO
PRINT N'Altering [dbo].[usp_Message_Transaction]...';


GO
ALTER PROC [dbo].[usp_Message_Transaction]
(
	@Action CHAR(1) = 'I',
	--Message
	@Id INT,
	@FolderId TINYINT = 1,
	@Subject NVARCHAR(250) = '',
	@Date SMALLDATETIME,
	@SenderId NVARCHAR(128) = '',
	@ReceiverId NVARCHAR(128) = '',
	@IsRead BIT = 0,
	@IsSend BIT = 0,
	@IsPrioriry BIT = 0,
	--MessageContent
	@Detail NVARCHAR(MAX) = '',
	--MessageRecipient
	@ListReceiverId INTLIST READONLY
)
AS BEGIN


	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED
	DECLARE @return INT = 0

	BEGIN TRY
		BEGIN TRAN;
		
			-- Local Variable
			DECLARE @item INT

			IF @Action = 'I' --INSERT
			BEGIN
				SET @Date = GETDATE()

				-- Message Table
				INSERT [dbo].[Message] VALUES(@FolderId, @Subject, @Date, @SenderId, @ReceiverId, @IsRead, @IsSend, @IsPrioriry)
				SET @Id = SCOPE_IDENTITY()

				-- Message Content Table
				INSERT [dbo].[MessageContent] VALUES(@Id, @Detail)

				-- Message Recipient Table
				DECLARE cursorListReceiver CURSOR READ_ONLY FOR SELECT [Item] FROM @ListReceiverId WHERE [Item] > 0
				
				OPEN cursorListReceiver
				FETCH NEXT FROM cursorListReceiver INTO @Item
				
				WHILE @@FETCH_STATUS = 0
				BEGIN
					INSERT INTO [dbo].[MessageRecipient] VALUES(@Id, @item, 1) --Default IsUsed = True
					FETCH NEXT FROM cursorListReceiver INTO @Item
				END
				
				CLOSE cursorListReceiver
				DEALLOCATE cursorListReceiver

				SET @return = @Id
			END

			IF @Action = 'U' --UPDATE
			BEGIN
				IF @IsSend = 0 -- AVAILABLE UPDATE WHEN EMAIL IS NOT SENT
				BEGIN
					-- Message Table
					UPDATE [dbo].[Message]
					SET [FolderId] = @FolderId, [Subject] = @Subject, [ReceiverId] = @ReceiverId, [IsPriority]  = @IsPrioriry
					WHERE [Id] = @Id  

					-- Message Content Table
					UPDATE [dbo].[MessageContent] SET [Detail] = @Detail WHERE [MessageId] = @Id

					-- Message Recipient Table
					DELETE FROM [dbo].[MessageRecipient] WHERE [MessageId] = @Id
				
					DECLARE cursorListReceiver CURSOR READ_ONLY FOR SELECT [Item] FROM @ListReceiverId WHERE [Item] > 0
				
					OPEN cursorListReceiver
					FETCH NEXT FROM cursorListReceiver INTO @Item
				
					WHILE @@FETCH_STATUS = 0
					BEGIN
						INSERT INTO [dbo].[MessageRecipient] VALUES(@Id, @item, 1) --Default IsUsed = True
						FETCH NEXT FROM cursorListReceiver INTO @Item
					END
				
					CLOSE cursorListReceiver
					DEALLOCATE cursorListReceiver

					SET @return = @Id
				END
			END

			IF @Action = 'D' --DELETE
			BEGIN
				-- Message Content Table
				DELETE FROM [dbo].[MessageContent] WHERE  [MessageId] = @Id

				-- Message Recipient Table
				DELETE FROM [dbo].[MessageRecipient] WHERE [MessageId] = @Id

				-- Message Table
				DELETE FROM [dbo].[Message] WHERE [Id] = @Id

				SET @return = @Id
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
PRINT N'Altering [dbo].[usp_MessageRecipient_Transaction]...';


GO
ALTER PROCEDURE [dbo].[usp_MessageRecipient_Transaction]
	@MessageId INT,
	@ReceiverId NVARCHAR(128) = ''
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED
	DECLARE @return INT = 0

	BEGIN TRY
		BEGIN TRAN
			IF @MessageId > 0 AND @ReceiverId > 0
				IF NOT EXISTS (SELECT TOP 1 * FROM [dbo].MessageRecipient WHERE MessageId = @MessageId AND ReceiverId = @ReceiverId)
					BEGIN
						INSERT INTO [dbo].MessageRecipient
						VALUES(@MessageId, @ReceiverId, 1)

						SET @return = @MessageId
					END
				ELSE
					SET @return = 0
			ELSE
				SET @return = 0
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
PRINT N'Altering [dbo].[usp_OfferAdvise_Transaction]...';


GO
ALTER PROC [dbo].[usp_OfferAdvise_Transaction]
(
	@Action CHAR(1) = 'I',
	@Date SMALLDATETIME,
	@Id INT = 1,
	@Detail NVARCHAR(MAX) = '',
	@PatientId NVARCHAR(128),
	@IsRead BIT = 0,
	@IsSent BIT = 0,
	@Tag NVARCHAR(150)
)
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED
	DECLARE @return INT = 0

	BEGIN TRY
		BEGIN TRAN;
			--DECLARE @Date SMALLDATETIME

			IF @Action = 'I' --INSERT
			BEGIN
				SET @Date = GETDATE()

				INSERT [dbo].[OfferAdvise] VALUES(@Date, @Detail, @PatientId, @IsRead, @IsSent, @Tag)

				SET @return = SCOPE_IDENTITY()
			END

			IF @Action = 'U' --UPDATE
			BEGIN
				UPDATE [dbo].[OfferAdvise]
				SET [Detail] = @Detail, [IsRead] = @IsRead, [IsSent] = @IsSent, Tag = @Tag
				WHERE [Id] = @Id  

				SET @return = @Id
			END

			IF @Action = 'D' --DELETE
			BEGIN
				BEGIN
					DELETE FROM [dbo].[OfferAdvise]
					WHERE [Id] = @Id

					SET @return = @Id
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
PRINT N'Altering [dbo].[usp_Role_Transaction]...';


GO
ALTER PROCEDURE [dbo].[usp_Role_Transaction]
	@Action CHAR(1) = 'I',
	@Id NVARCHAR(128),
	@Name NVARCHAR(128)
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED
	DECLARE @return BIT = 1

	BEGIN TRY
		BEGIN TRAN
			IF @Action = 'I'
				SET @Id = CAST(NEWID() as NVARCHAR(128));
				IF NOT EXISTS (SELECT TOP 1 * FROM [dbo].[Role] WHERE Name = @Name)
					INSERT INTO [dbo].[Role]
					VALUES(@Id, @Name)
				ELSE
					SET @return = 0
			IF @Action = 'U'
				IF EXISTS (SELECT TOP 1 * FROM [dbo].[Role] WHERE Id = @Id)
					UPDATE [dbo].[Role]
					SET Name = @Name
					WHERE Id = @Id
				ELSE
					SET @return = 0
			IF @Action = 'D'
				IF EXISTS (SELECT TOP 1 * FROM [dbo].[Role] WHERE Id = @Id)
					DELETE FROM [dbo].[Role]
					WHERE Id = @Id
				ELSE
					SET @return = 0
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
PRINT N'Altering [dbo].[usp_spa_User_HasScheduleExamine]...';


GO
ALTER PROCEDURE [dbo].usp_spa_User_HasScheduleExamine
	@Search nvarchar(250) = ''
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED

	BEGIN TRY
		SELECT DISTINCT 
				dbo.Users.*
		FROM    dbo.Schedule INNER JOIN
				dbo.Users ON dbo.Schedule.UserId = dbo.Users.Id
		WHERE   (dbo.Users.IsDoctor = 1)
				AND (Name like '%' + @Search + '%' OR @Search is null)
				AND (Tags like '%' + @Search + '%' OR @Search is null)
				AND IsExamine = 1
				AND GETDATE() BETWEEN 
				[Start] AND DATEADD(day,2,[Start]) + '23:59:59:999'

	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT <> 0 
		BEGIN
			RETURN NULL
		END
	END CATCH
END
GO
PRINT N'Altering [dbo].[usp_User_HasScheduleExamine]...';


GO
ALTER PROCEDURE [dbo].[usp_User_HasScheduleExamine]
	@Search nvarchar(250) = ''
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED

	BEGIN TRY
		SELECT DISTINCT 
				dbo.Users.*
		FROM    dbo.Schedule INNER JOIN
				dbo.Users ON dbo.Schedule.UserId = dbo.Users.Id
		WHERE   (dbo.Users.IsDoctor = 1)
				AND (Name like '%' + @Search + '%' OR @Search is null)
				AND (Tags like '%' + @Search + '%' OR @Search is null)
				AND IsExamine = 1
				AND GETDATE() BETWEEN 
				[Start] AND DATEADD(day,2,[Start]) + '23:59:59:999'

	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT <> 0 
		BEGIN
			RETURN NULL
		END
	END CATCH
END
GO
PRINT N'Altering [dbo].[usp_Users_Transaction]...';


GO
ALTER PROCEDURE [dbo].[usp_Users_Transaction]
	@Action CHAR(1) = 'I',
	@Id NVARCHAR(128) = '',
	@Name NVARCHAR(32),
	@Code CHAR(20),
	@Email NVARCHAR(256),
	@PasswordHash VARCHAR(60),
	@PhoneNumber VARCHAR(20),
	@HomePhone VARCHAR(20),
	@DoB DATE,
	@Gender TINYINT,
	@Image VARCHAR(256),
	@OrganizationId SMALLINT,
	@Status BIT,
	@PatientId NVARCHAR(128) = '',
	@IsAdmin BIT,
	@IsDoctor BIT,
	@Tag NVARCHAR(150) = ''
AS BEGIN
	SET NOCOUNT ON
	DECLARE @return BIT = 1

	BEGIN TRY
		BEGIN TRAN
			IF @Action = 'I'
				IF NOT EXISTS (SELECT TOP 1 1 FROM [dbo].Users WHERE [Email] = @Email)
					INSERT INTO [dbo].[Users](Id, Name, Code, Email, PasswordHash, PhoneNumber, HomePhone, DoB, Gender, [Image], OrganizationId, [Status], PatientId, IsAdmin, IsDoctor, Tags)
					VALUES(@Id, @Name, @Code, @Email, @PasswordHash, @PhoneNumber, @HomePhone, 
					@DoB, @Gender, @Image, @OrganizationId, @Status, @PatientId,
					@IsAdmin, @IsDoctor, @Tag)
				ELSE
					SET @return = 0
			IF @Action = 'U'
				IF EXISTS (SELECT TOP 1 1 FROM [dbo].[Users] WHERE [Id] = @Id)
					UPDATE [dbo].[Users]
					SET [Name] = @Name,
					[Code] = @Code,
					[PhoneNumber] = @PhoneNumber,
					[HomePhone] = @HomePhone,
					[DoB] = @DoB,
					[Gender] = @Gender,
					[Image] = @Image,
					[OrganizationId] = @OrganizationId,
					[PatientId] = @PatientId,
					[IsAdmin] = @IsAdmin,
					[IsDoctor] = @IsDoctor,
					[Tags] = @Tag
					WHERE [Id] = @Id
				ELSE
					SET @return = 0
			IF @Action = 'D'
				IF EXISTS (SELECT TOP 1 1 FROM [dbo].[Users] WHERE [Id] = @Id)
					DELETE FROM [dbo].[Users]
					WHERE [Id] = @Id
				ELSE
					SET @return = 0
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
PRINT N'Altering [dbo].[usp_Appointment_Transaction]...';


GO
ALTER PROC [dbo].[usp_Appointment_Transaction]
(
	@Action CHAR(1) = 'I',
	@Id INT = 1,--Appointment
	@Date DATE = '',
	@Time int = 8,
	@PhysicianId NVARCHAR(128) = '',
	@PatientId NVARCHAR(128) = '',
	@Symptom NVARCHAR(300) = '',
	@AppointmentNo SMALLINT = 0,
	@PatientName NVARCHAR(50) = '',
	@PatientAddress NVARCHAR(150) = '',
	@PatientEmail VARCHAR(256) = '',
	@PatientPhone VARCHAR(20) = '',
	@PatientGender TINYINT = 1,
	@PatientDoB DATE = '',
	@Status TINYINT = 1
)
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED
	DECLARE @return INT = 0
	DECLARE @CreatedDate VARCHAR(20)
	DECLARE @ModifiedDate VARCHAR(20)

	BEGIN TRY
		BEGIN TRAN;

			SET @ModifiedDate = [dbo].[ufnGetDate]()

			IF @Action = 'I' --INSERT
			BEGIN
				
				SET @CreatedDate = @ModifiedDate

				INSERT [dbo].[Appointment]
				VALUES(@PhysicianId, @PatientId, @Symptom, @CreatedDate, @ModifiedDate, @PatientId)

				SET @return = SCOPE_IDENTITY()

				INSERT [dbo].[AppointmentCollection] 
				VALUES(@Id, @Date, @Time, @AppointmentNo, @PatientName, @PatientAddress, @PatientEmail, @PatientPhone, @PatientGender, @PatientDoB, @Status)
				
			END

			IF @Action = 'U' --UPDATE
			BEGIN
				--STATUS: 0 - Just Created/Pending, 1 - Approved, 2 - Canceled
				IF EXISTS( SELECT TOP 1 1 FROM [dbo].[Appointment] WHERE [Id] = @Id)
				BEGIN
					UPDATE [dbo].[Appointment]
					SET [PhysicianId] = @PhysicianId, [PatientId] = @PatientId, [Symptom] = @Symptom, [ModifiedDate] = @ModifiedDate
					WHERE [Id] = @Id  

					UPDATE [dbo].[AppointmentCollection]
					SET [AppointmentNo] = @AppointmentNo, [PatientName] = @PatientName, [PatientEmail] = @PatientEmail,
					[PatientAddress] = @PatientAddress, [PatientPhone] = @PatientPhone ,[PatientGender] = @PatientGender, [PatientDoB] =  @PatientDoB, [Status] = @Status
					WHERE [Id] = @Id  

					SET @return = @Id
				END
				ELSE
					SET @return = 0
			END

			IF @Action = 'D' --DELETE
			BEGIN
				IF EXISTS( SELECT TOP 1 1 FROM [dbo].[Appointment] WHERE [Id] = @Id)
				BEGIN
					DELETE FROM [dbo].[AppointmentCollection]
					WHERE [Id] = @Id

					DELETE FROM [dbo].[Appointment]
					WHERE [Id] = @Id

					SET @return = @Id
				END
				ELSE
					SET @return = 0
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
PRINT N'Altering [dbo].[usp_Schedule_Transaction]...';


GO
ALTER PROCEDURE [dbo].[usp_Schedule_Transaction]
	@Action CHAR(1) = 'I',
	@Id INT,
	@Title NVARCHAR(50),
	@Priority TINYINT,
	@Detail NVARCHAR(300),
	@IsAlarm BIT,
	@Start DATETIME,
	@End DATETIME,
	@Color VARCHAR(6),
	@IsExamine BIT,
	@UserId NVARCHAR(128) = ''
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED

	DECLARE @return INT = 0;

	BEGIN TRY
		BEGIN TRAN
			IF @Action = 'I'
				INSERT INTO [dbo].Schedule
				VALUES(@Title, @Priority, @Detail, @IsAlarm, @Start, @End, @Color, @IsExamine, @UserId)
				SET @return = SCOPE_IDENTITY()
			IF @Action = 'U'
				UPDATE [dbo].Schedule
				SET Title = @Title,
				[Priority] = @Priority,
				Detail = @Detail,
				IsAlarm = @IsAlarm,
				[Start] = @Start,
				[End] = @End,
				Color = @Color,
				IsExamine = @IsExamine,
				UserId = @UserId
				WHERE Id = @Id

				SET @return = @Id
			IF @Action = 'D'
				IF EXISTS (SELECT TOP 1 1 FROM [dbo].Schedule WHERE Id = @Id)
					BEGIN
						DELETE FROM [dbo].Schedule
						WHERE Id = @Id

						SET @return = @Id
					END
				ELSE
					SET @return = 0
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
PRINT N'Altering [dbo].[usp_spa_ScheduleExamine]...';


GO
ALTER PROCEDURE [dbo].[usp_spa_ScheduleExamine]
	@UserId NVARCHAR(128) = '',
	@Start DATETIME
AS
BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED

	BEGIN TRY
		SELECT *
			FROM [dbo].Schedule
			WHERE UserId = @UserId
			AND [Start] 
			BETWEEN CAST(@Start AS DateTime)
			AND CAST(@Start + '23:59:59:999' AS DateTime)
			AND [IsExamine] = 1
	END TRY

	BEGIN CATCH
		IF @@TRANCOUNT <> 0
			RETURN NULL
	END CATCH
END
GO
PRINT N'Altering [dbo].[usp_UserGroup_Transaction]...';


GO
ALTER PROCEDURE [dbo].[usp_UserGroup_Transaction]
	@Action CHAR(1) = 'I',
	@UserId NVARCHAR(128) = '',
	@GroupId TINYINT
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED
	DECLARE @return BIT = 1

	BEGIN TRY
		BEGIN TRAN

			IF @Action = 'I' -- INSERT
				IF NOT EXISTS (SELECT TOP 1 1 FROM [dbo].[UserGroup] WHERE [UserId] = @UserId AND [GroupId] = @GroupId)
					INSERT INTO [dbo].[UserGroup] VALUES(@UserId, @GroupId)
				ELSE
					SET @return = 0

			IF @Action = 'U' -- UPDATE
				IF EXISTS (SELECT TOP 1 1 FROM [dbo].[UserGroup] WHERE [UserId] = @UserId AND [GroupId] = @GroupId)
					UPDATE [dbo].[UserGroup]
					SET [UserId] = @UserId, [GroupId] = @GroupId
					WHERE [UserId] = @UserId
					AND [GroupId] = @GroupId
			ELSE
				SET @return = 0

			IF @Action = 'D' -- DELETE
				IF EXISTS(SELECT TOP 1 1 FROM [dbo].[UserGroup] WHERE [UserId] = @UserId AND [GroupId] = @GroupId)
				BEGIN
					IF @UserId <> 0 AND @GroupId <> 0
						DELETE [dbo].[UserGroup]
						WHERE [UserId] = @UserId
						AND [GroupId] = @GroupId
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
	SELECT @return
END
GO
PRINT N'Altering [dbo].[usp_UserRole_Transaction]...';


GO
ALTER PROCEDURE [dbo].[usp_UserRole_Transaction]
	@Action CHAR(1) = 'I',
	@UserId NVARCHAR(128) = '',
	@RoleId int
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED
	DECLARE @return bit = 1

	BEGIN TRY
		BEGIN TRAN
			IF @Action = 'I'
				IF NOT EXISTS (SELECT TOP 1 1 FROM [dbo].[UserRole] WHERE [UserId] = @UserId AND [RoleId] = @RoleId)
					BEGIN
						INSERT INTO [dbo].[UserRole]
						VALUES(@UserId, @RoleId)
					END
				ELSE
					SET @return = 0;
			IF @Action = 'U'
				IF EXISTS(SELECT TOP 1 1 FROM [dbo].UserRole WHERE [UserId] = @UserId AND [RoleId] = @RoleId)
				BEGIN
					IF @UserId <> 0 AND @RoleId <> 0
						UPDATE [dbo].[UserRole]
						SET [UserId] = @UserId,
						[RoleId] = @RoleId
						WHERE [UserId] = @UserId
						AND [RoleId] = @RoleId
					ELSE
						SET @return = 0;
				END
				ELSE
					SET @return = 0;
				
			IF @Action = 'D'
				
				IF EXISTS(SELECT TOP 1 1 FROM [dbo].[UserRole] WHERE [UserId] = @UserId AND [RoleId] = @RoleId)
				BEGIN
					IF @UserId <> 0 AND @RoleId <> 0
						DELETE [dbo].[UserRole]
						WHERE [UserId] = @UserId
						AND [RoleId] = @RoleId
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
	SELECT @return
END
GO
PRINT N'Refreshing [dbo].[usp_Article]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[usp_Article]';


GO
PRINT N'Refreshing [dbo].[usp_ArticleComment]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[usp_ArticleComment]';


GO
PRINT N'Refreshing [dbo].[usp_MessageFolder_Transaction]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[usp_MessageFolder_Transaction]';


GO
PRINT N'Refreshing [dbo].[usp_OfferAdvise]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[usp_OfferAdvise]';


GO
PRINT N'Refreshing [dbo].[usp_Login]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[usp_Login]';


GO
PRINT N'Refreshing [dbo].[usp_Role]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[usp_Role]';


GO
PRINT N'Refreshing [dbo].[usp_Organization_Transaction]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[usp_Organization_Transaction]';


GO
PRINT N'Refreshing [dbo].[usp_spa_User]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[usp_spa_User]';


GO
PRINT N'Refreshing [dbo].[usp_User]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[usp_User]';


GO
PRINT N'Refreshing [dbo].[usp_User_ChangePassword]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[usp_User_ChangePassword]';


GO
-- Refactoring step to update target server with deployed transaction logs
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '43d96ec9-b487-4601-8a5b-066abec94212')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('43d96ec9-b487-4601-8a5b-066abec94212')

GO

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
ALTER TABLE [dbo].[MessageRecipient] WITH CHECK CHECK CONSTRAINT [FK_MessageRecipient_Message];

ALTER TABLE [dbo].[Users] WITH CHECK CHECK CONSTRAINT [FK_Users_Organization];

ALTER TABLE [dbo].[UserRole] WITH CHECK CHECK CONSTRAINT [FK_UserRole_Role];

ALTER TABLE [dbo].[UserRole] WITH CHECK CHECK CONSTRAINT [FK_UserRole_Users];

ALTER TABLE [dbo].[Permission] WITH CHECK CHECK CONSTRAINT [FK_Permission_Module];

ALTER TABLE [dbo].[UserGroup] WITH CHECK CHECK CONSTRAINT [FK_UserGroup_Group];

ALTER TABLE [dbo].[UserGroup] WITH CHECK CHECK CONSTRAINT [FK_UserGroup_Users];


GO
PRINT N'Update complete.';


GO
