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
PRINT N'Rename refactoring operation with key 141e94c4-9e9f-49a8-9d99-eea05fb40d33 is skipped, element [dbo].[AppointmentLog].[Status] (SqlSimpleColumn) will not be renamed to PatientName';


GO
PRINT N'Rename refactoring operation with key 4be774d4-1722-4de7-a0a7-0ff30c260eaf, c6b00e0b-8dad-4f94-ae5c-632cc6bb929d is skipped, element [dbo].[AppointmentCollection].[No] (SqlSimpleColumn) will not be renamed to AppointmentNo';


GO
PRINT N'Rename refactoring operation with key 8fe1fd97-031d-4b23-b015-f154896d757d is skipped, element [dbo].[AppointmentCollection].[PatientAddeess] (SqlSimpleColumn) will not be renamed to PatientAddress';


GO
PRINT N'Creating [dbo].[Appointment]...';


GO
CREATE TABLE [dbo].[Appointment] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [PhysicianId]  INT            NOT NULL,
    [PatientId]    INT            NOT NULL,
    [Symptom]      NVARCHAR (MAX) NOT NULL,
    [CreatedDate]  VARCHAR (20)   NOT NULL,
    [ModifiedDate] VARCHAR (20)   NOT NULL,
    CONSTRAINT [PK_Appointment] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[Appointment].[idxAppointmentPatient]...';


GO
CREATE NONCLUSTERED INDEX [idxAppointmentPatient]
    ON [dbo].[Appointment]([PatientId] ASC);


GO
PRINT N'Creating [dbo].[Appointment].[idxAppointmentPhysician]...';


GO
CREATE NONCLUSTERED INDEX [idxAppointmentPhysician]
    ON [dbo].[Appointment]([PhysicianId] ASC);


GO
PRINT N'Creating [dbo].[AppointmentCollection]...';


GO
CREATE TABLE [dbo].[AppointmentCollection] (
    [Id]             INT            NOT NULL,
    [Date]           DATE           NOT NULL,
    [Time]           INT            NOT NULL,
    [AppointmentNo]  SMALLINT       NOT NULL,
    [PatientName]    NVARCHAR (50)  NOT NULL,
    [PatientAddress] NVARCHAR (150) NOT NULL,
    [PatientEmail]   VARCHAR (256)  NULL,
    [PatientPhone]   VARCHAR (20)   NULL,
    [PatientGender]  TINYINT        NOT NULL,
    [PatientDoB]     DATE           NULL,
    [Status]         TINYINT        NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[AppointmentCollection].[idxAppointmentCollection]...';


GO
CREATE NONCLUSTERED INDEX [idxAppointmentCollection]
    ON [dbo].[AppointmentCollection]([Date] ASC, [AppointmentNo] ASC, [PatientName] ASC);


GO
PRINT N'Creating [dbo].[AppointmentLog]...';


GO
CREATE TABLE [dbo].[AppointmentLog] (
    [Id]             UNIQUEIDENTIFIER NOT NULL,
    [Date]           DATE             NOT NULL,
    [Time]           INT              NOT NULL,
    [PhysicianId]    INT              NOT NULL,
    [PatientId]      INT              NOT NULL,
    [Symptom]        NVARCHAR (MAX)   NOT NULL,
    [PatientName]    NVARCHAR (50)    NULL,
    [PatientAddress] NVARCHAR (150)   NULL,
    [PatientEmail]   VARCHAR (256)    NULL,
    [PatientPhone]   VARCHAR (20)     NULL,
    [PatientGender]  TINYINT          NULL,
    [PatientDoB]     DATE             NULL,
    [CreatedDate]    VARCHAR (20)     NOT NULL,
    [ModifiedDate]   VARCHAR (20)     NOT NULL,
    [Status]         TINYINT          NOT NULL,
    CONSTRAINT [PK_AppointmentLog] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[AppointmentLog].[idxAppointmentLogDate]...';


GO
CREATE NONCLUSTERED INDEX [idxAppointmentLogDate]
    ON [dbo].[AppointmentLog]([Date] ASC);


GO
PRINT N'Creating [dbo].[AppointmentLog].[idxAppointmentLogPatient]...';


GO
CREATE NONCLUSTERED INDEX [idxAppointmentLogPatient]
    ON [dbo].[AppointmentLog]([PatientId] ASC);


GO
PRINT N'Creating [dbo].[AppointmentLog].[idxAppointmentLogPhysician]...';


GO
CREATE NONCLUSTERED INDEX [idxAppointmentLogPhysician]
    ON [dbo].[AppointmentLog]([PhysicianId] ASC);


GO
PRINT N'Creating [dbo].[Article]...';


GO
CREATE TABLE [dbo].[Article] (
    [Id]        INT             IDENTITY (1, 1) NOT NULL,
    [Date]      SMALLDATETIME   NOT NULL,
    [Title]     NVARCHAR (150)  NOT NULL,
    [Detail]    NVARCHAR (1000) NOT NULL,
    [PatientId] INT             NOT NULL,
    [Status]    TINYINT         NOT NULL,
    [IsClosed]  BIT             NOT NULL,
    CONSTRAINT [PK_Article] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[ArticleComment]...';


GO
CREATE TABLE [dbo].[ArticleComment] (
    [Id]          SMALLINT        NOT NULL,
    [ArticleId]   INT             NOT NULL,
    [Date]        SMALLDATETIME   NOT NULL,
    [Detail]      NVARCHAR (1000) NOT NULL,
    [CreatedUser] INT             NOT NULL,
    [Status]      TINYINT         NOT NULL,
    CONSTRAINT [PK_ArticleComment] PRIMARY KEY CLUSTERED ([Id] ASC, [ArticleId] ASC)
);


GO
PRINT N'Creating [dbo].[BlockedIpHandler]...';


GO
CREATE TABLE [dbo].[BlockedIpHandler] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [IP]       VARCHAR (50)   NOT NULL,
    [Note]     NVARCHAR (150) NOT NULL,
    [IsLocked] BIT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[Group]...';


GO
CREATE TABLE [dbo].[Group] (
    [Id]         TINYINT       IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (50) NOT NULL,
    [IsReadOnly] BIT           NOT NULL,
    CONSTRAINT [PK_Group] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[MailSetting]...';


GO
CREATE TABLE [dbo].[MailSetting] (
    [Id]    TINYINT        IDENTITY (1, 1) NOT NULL,
    [Name]  NVARCHAR (256) NOT NULL,
    [Email] VARCHAR (256)  NOT NULL,
    [Pwd]   VARCHAR (60)   NOT NULL,
    [Host]  VARCHAR (150)  NOT NULL,
    [Port]  INT            NOT NULL,
    [IsSSL] BIT            NOT NULL,
    CONSTRAINT [PK_MailConfig] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[Message]...';


GO
CREATE TABLE [dbo].[Message] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [FolderId]   TINYINT        NOT NULL,
    [Subject]    NVARCHAR (250) NOT NULL,
    [Date]       SMALLDATETIME  NOT NULL,
    [SenderId]   INT            NOT NULL,
    [ReceiverId] INT            NOT NULL,
    [IsRead]     BIT            NOT NULL,
    [IsSend]     BIT            NOT NULL,
    [IsPriority] BIT            NOT NULL,
    CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[Message].[idxMessageFolder]...';


GO
CREATE NONCLUSTERED INDEX [idxMessageFolder]
    ON [dbo].[Message]([FolderId] ASC);


GO
PRINT N'Creating [dbo].[Message].[idxMessageSender]...';


GO
CREATE NONCLUSTERED INDEX [idxMessageSender]
    ON [dbo].[Message]([SenderId] ASC);


GO
PRINT N'Creating [dbo].[Message].[idxMessageReceiver]...';


GO
CREATE NONCLUSTERED INDEX [idxMessageReceiver]
    ON [dbo].[Message]([ReceiverId] ASC);


GO
PRINT N'Creating [dbo].[MessageContent]...';


GO
CREATE TABLE [dbo].[MessageContent] (
    [MessageId] INT            NOT NULL,
    [Detail]    NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_MessageContent] PRIMARY KEY CLUSTERED ([MessageId] ASC)
);


GO
PRINT N'Creating [dbo].[MessageFolder]...';


GO
CREATE TABLE [dbo].[MessageFolder] (
    [Id]   TINYINT        IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50)  NOT NULL,
    [Path] NVARCHAR (256) NOT NULL,
    CONSTRAINT [PK_MessageFolder] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[MessageRecipient]...';


GO
CREATE TABLE [dbo].[MessageRecipient] (
    [MessageId]  INT NOT NULL,
    [ReceiverId] INT NOT NULL,
    [IsUsed]     BIT NOT NULL,
    CONSTRAINT [PK_MessageRecipient] PRIMARY KEY CLUSTERED ([MessageId] ASC, [ReceiverId] ASC)
);


GO
PRINT N'Creating [dbo].[Module]...';


GO
CREATE TABLE [dbo].[Module] (
    [Id]       SMALLINT       IDENTITY (1, 1) NOT NULL,
    [Title]    NVARCHAR (128) NOT NULL,
    [Handler]  NVARCHAR (256) NOT NULL,
    [Sort]     TINYINT        NOT NULL,
    [ParentId] SMALLINT       NOT NULL,
    [GroupId]  TINYINT        NOT NULL,
    CONSTRAINT [PK_Module] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[Module].[idxModuleGroup]...';


GO
CREATE NONCLUSTERED INDEX [idxModuleGroup]
    ON [dbo].[Module]([GroupId] ASC);


GO
PRINT N'Creating [dbo].[OfferAdvise]...';


GO
CREATE TABLE [dbo].[OfferAdvise] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Date]      SMALLDATETIME  NOT NULL,
    [Detail]    NVARCHAR (MAX) NOT NULL,
    [PatientId] INT            NOT NULL,
    [IsRead]    BIT            NOT NULL,
    [IsSent]    BIT            NOT NULL,
    [Tag]       NVARCHAR (150) NOT NULL,
    CONSTRAINT [PK_OfferAdvise] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[Organization]...';


GO
CREATE TABLE [dbo].[Organization] (
    [Id]       SMALLINT       IDENTITY (1, 1) NOT NULL,
    [ParentId] SMALLINT       NULL,
    [Name]     NVARCHAR (150) NOT NULL,
    [Phone]    VARCHAR (50)   NULL,
    [Fax]      VARCHAR (50)   NULL,
    [Email]    VARCHAR (256)  NULL,
    [Address]  NVARCHAR (150) NULL,
    CONSTRAINT [PK_Organization] PRIMARY KEY CLUSTERED ([Id] ASC)
);


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
PRINT N'Creating [dbo].[Role]...';


GO
CREATE TABLE [dbo].[Role] (
    [Id]   SMALLINT       IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[Schedule]...';


GO
CREATE TABLE [dbo].[Schedule] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Title]     NVARCHAR (50)  NOT NULL,
    [Priority]  TINYINT        NOT NULL,
    [Detail]    NVARCHAR (300) NOT NULL,
    [IsAlarm]   BIT            NOT NULL,
    [Start]     DATETIME       NOT NULL,
    [End]       DATETIME       NOT NULL,
    [Color]     VARCHAR (6)    NOT NULL,
    [IsExamine] BIT            NOT NULL,
    [UserId]    INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[Setting]...';


GO
CREATE TABLE [dbo].[Setting] (
    [Id]                  TINYINT        IDENTITY (1, 1) NOT NULL,
    [Title]               NVARCHAR (70)  NOT NULL,
    [Description]         NVARCHAR (150) NOT NULL,
    [Keyword]             NVARCHAR (150) NOT NULL,
    [Membership]          BIT            NOT NULL,
    [DefaultRole]         SMALLINT       NOT NULL,
    [LoginURL]            VARCHAR (256)  NOT NULL,
    [LockedIPNoteDefault] NVARCHAR (150) NOT NULL,
    CONSTRAINT [PK_Setting] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[SupportOnline]...';


GO
CREATE TABLE [dbo].[SupportOnline] (
    [Id]          TINYINT        IDENTITY (1, 1) NOT NULL,
    [Code]        VARCHAR (50)   NOT NULL,
    [Name]        NVARCHAR (50)  NOT NULL,
    [WelcomeNote] NVARCHAR (150) NOT NULL,
    [IsUsed]      BIT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[UserGroup]...';


GO
CREATE TABLE [dbo].[UserGroup] (
    [UserId]  INT     NOT NULL,
    [GroupId] TINYINT NOT NULL,
    CONSTRAINT [PK_UserGroup] PRIMARY KEY CLUSTERED ([UserId] ASC, [GroupId] ASC)
);


GO
PRINT N'Creating [dbo].[UserRole]...';


GO
CREATE TABLE [dbo].[UserRole] (
    [UserId] INT      NOT NULL,
    [RoleId] SMALLINT NOT NULL,
    CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED ([UserId] ASC, [RoleId] ASC)
);


GO
PRINT N'Creating [dbo].[Users]...';


GO
CREATE TABLE [dbo].[Users] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [Name]           NVARCHAR (32)  NOT NULL,
    [Code]           CHAR (20)      NOT NULL,
    [Email]          VARCHAR (256)  NOT NULL,
    [PasswordHash]   VARCHAR (60)   NOT NULL,
    [PhoneNumber]    VARCHAR (20)   NULL,
    [HomePhone]      VARCHAR (20)   NULL,
    [DateOfBirth]    DATE           NULL,
    [Gender]         TINYINT        NOT NULL,
    [Image]          VARCHAR (256)  NULL,
    [OrganizationId] SMALLINT       NOT NULL,
    [Status]         BIT            NOT NULL,
    [PatientId]      CHAR (10)      NULL,
    [IsAdmin]        BIT            NOT NULL,
    [IsDoctor]       BIT            NOT NULL,
    [Tags]           NVARCHAR (150) NOT NULL,
    CONSTRAINT [PK_USERS] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [UQ__USERS__A9D1053429B4C0C0] UNIQUE NONCLUSTERED ([Email] ASC)
);


GO
PRINT N'Creating [dbo].[Users].[idxUserAccess]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [idxUserAccess]
    ON [dbo].[Users]([Code] ASC, [Email] ASC);


GO
PRINT N'Creating unnamed constraint on [dbo].[Group]...';


GO
ALTER TABLE [dbo].[Group]
    ADD DEFAULT 0 FOR [IsReadOnly];


GO
PRINT N'Creating unnamed constraint on [dbo].[MessageRecipient]...';


GO
ALTER TABLE [dbo].[MessageRecipient]
    ADD DEFAULT 1 FOR [IsUsed];


GO
PRINT N'Creating [dbo].[DF__USERS__Gender__108B795B]...';


GO
ALTER TABLE [dbo].[Users]
    ADD CONSTRAINT [DF__USERS__Gender__108B795B] DEFAULT ((1)) FOR [Gender];


GO
PRINT N'Creating [dbo].[DF__USERS__Status__117F9D94]...';


GO
ALTER TABLE [dbo].[Users]
    ADD CONSTRAINT [DF__USERS__Status__117F9D94] DEFAULT ((1)) FOR [Status];


GO
PRINT N'Creating [dbo].[FK_Article_Users]...';


GO
ALTER TABLE [dbo].[Article] WITH NOCHECK
    ADD CONSTRAINT [FK_Article_Users] FOREIGN KEY ([PatientId]) REFERENCES [dbo].[Users] ([Id]);


GO
PRINT N'Creating [dbo].[FK_ArticleComment_Article]...';


GO
ALTER TABLE [dbo].[ArticleComment] WITH NOCHECK
    ADD CONSTRAINT [FK_ArticleComment_Article] FOREIGN KEY ([ArticleId]) REFERENCES [dbo].[Article] ([Id]);


GO
PRINT N'Creating [dbo].[FK_Message_MessageFolder]...';


GO
ALTER TABLE [dbo].[Message] WITH NOCHECK
    ADD CONSTRAINT [FK_Message_MessageFolder] FOREIGN KEY ([FolderId]) REFERENCES [dbo].[MessageFolder] ([Id]);


GO
PRINT N'Creating [dbo].[FK_Message_Sender]...';


GO
ALTER TABLE [dbo].[Message] WITH NOCHECK
    ADD CONSTRAINT [FK_Message_Sender] FOREIGN KEY ([SenderId]) REFERENCES [dbo].[Users] ([Id]);


GO
PRINT N'Creating [dbo].[FK_Message_Receiver]...';


GO
ALTER TABLE [dbo].[Message] WITH NOCHECK
    ADD CONSTRAINT [FK_Message_Receiver] FOREIGN KEY ([ReceiverId]) REFERENCES [dbo].[Users] ([Id]);


GO
PRINT N'Creating [dbo].[FK_MessageContent_Message]...';


GO
ALTER TABLE [dbo].[MessageContent] WITH NOCHECK
    ADD CONSTRAINT [FK_MessageContent_Message] FOREIGN KEY ([MessageId]) REFERENCES [dbo].[Message] ([Id]);


GO
PRINT N'Creating [dbo].[FK_MessageRecipient_Message]...';


GO
ALTER TABLE [dbo].[MessageRecipient] WITH NOCHECK
    ADD CONSTRAINT [FK_MessageRecipient_Message] FOREIGN KEY ([MessageId]) REFERENCES [dbo].[Message] ([Id]);


GO
PRINT N'Creating [dbo].[FK_MessageRecipient_Users]...';


GO
ALTER TABLE [dbo].[MessageRecipient] WITH NOCHECK
    ADD CONSTRAINT [FK_MessageRecipient_Users] FOREIGN KEY ([ReceiverId]) REFERENCES [dbo].[Users] ([Id]);


GO
PRINT N'Creating [dbo].[FK_Module_Module]...';


GO
ALTER TABLE [dbo].[Module] WITH NOCHECK
    ADD CONSTRAINT [FK_Module_Module] FOREIGN KEY ([ParentId]) REFERENCES [dbo].[Module] ([Id]);


GO
PRINT N'Creating [dbo].[FK_OfferAdvise_Users]...';


GO
ALTER TABLE [dbo].[OfferAdvise] WITH NOCHECK
    ADD CONSTRAINT [FK_OfferAdvise_Users] FOREIGN KEY ([PatientId]) REFERENCES [dbo].[Users] ([Id]);


GO
PRINT N'Creating [dbo].[FK_Organization_Organization]...';


GO
ALTER TABLE [dbo].[Organization] WITH NOCHECK
    ADD CONSTRAINT [FK_Organization_Organization] FOREIGN KEY ([ParentId]) REFERENCES [dbo].[Organization] ([Id]);


GO
PRINT N'Creating [dbo].[FK_Permission_Module]...';


GO
ALTER TABLE [dbo].[Permission] WITH NOCHECK
    ADD CONSTRAINT [FK_Permission_Module] FOREIGN KEY ([ModuleId]) REFERENCES [dbo].[Module] ([Id]);


GO
PRINT N'Creating [dbo].[FK_Permission_Role]...';


GO
ALTER TABLE [dbo].[Permission] WITH NOCHECK
    ADD CONSTRAINT [FK_Permission_Role] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role] ([Id]);


GO
PRINT N'Creating [dbo].[FK_Schedule_User]...';


GO
ALTER TABLE [dbo].[Schedule] WITH NOCHECK
    ADD CONSTRAINT [FK_Schedule_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]);


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
PRINT N'Creating [dbo].[FK_Users_Organization]...';


GO
ALTER TABLE [dbo].[Users] WITH NOCHECK
    ADD CONSTRAINT [FK_Users_Organization] FOREIGN KEY ([OrganizationId]) REFERENCES [dbo].[Organization] ([Id]);


GO
PRINT N'Altering [dbo].[usp_Appointment]...';


GO
ALTER PROC [dbo].[usp_Appointment](
	@Id INT = 0,
	@Date DATE = '',
	@AppointmentNo INT = 0,
	@PatientName NVARCHAR(50) = ''
)
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED

	BEGIN TRY
		IF (@Id > 0)
		BEGIN
			SELECT a.*,
				b.[Date], b.[Time], b.[AppointmentNo],
				b.[PatientName], b.[PatientAddress], b.[PatientEmail], b.[PatientPhone],
				b.[PatientGender], b.[PatientDoB], b.[Status]
			FROM [dbo].[Appointment] a  RIGHT JOIN [dbo].[AppointmentCollection] b 
			ON a.[Id] = b.[Id] WHERE a.[Id] = @Id
		END
		ELSE
		BEGIN
			DECLARE @SQLString NVARCHAR(500);
			DECLARE @ParmDefinition nvarchar(500); 

			SET @ParmDefinition = N'@Appointment_Date DATE, @Appointment_No INT,@Patient_Name NVARCHAR(50)';
			SET @SQLString = N'SELECT a.*,
				b.[Date], b.[Time], b.[AppointmentNo],
				b.[PatientName], b.[PatientAddress], b.[PatientEmail], b.[PatientPhone],
				b.[PatientGender], b.[PatientDoB], b.[Status]
			FROM [dbo].[Appointment] a  WITH(INDEX(idxAppointmentPhysician)) RIGHT JOIN [dbo].[AppointmentCollection] b 
			ON a.[Id] = b.[Id] WHERE b.[Date] = @Appointment_Date AND b.[AppointmentNo] = @Appointment_No';
			IF @PatientName != ''
				SET @SQLString = @SQLString + N' AND b.[PatientName]  LIKE N''%@Patient_Name%''';

			EXECUTE sp_executesql @SQLString, @ParmDefinition, @Appointment_Date = @Date, @Appointment_No = @AppointmentNo, @Patient_Name = @PatientName
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
PRINT N'Altering [dbo].[usp_Appointment_Transaction]...';


GO
ALTER PROC [dbo].[usp_Appointment_Transaction]
(
	@Action CHAR(1) = 'I',
	@Id INT = 1,--Appointment
	@PhysicianId INT = 0,
	@PatientId INT = 0,
	@Symptom NVARCHAR(300) = '',
	@Date DATE = '', --AppointmentCollection
	@Time int = 8,
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
				VALUES(@PhysicianId, @PatientId, @Symptom, @CreatedDate, @ModifiedDate)

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
PRINT N'Altering [dbo].[usp_Article]...';


GO
ALTER PROC [dbo].[usp_Article]
	@Id int
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED

	BEGIN TRY
		IF @Id = 0 
			SELECT *,  (SELECT COUNT(b.Id) from ArticleComment b where ArticleId = a.Id) as CountComments
			FROM [dbo].[Article] a
		ELSE
			SELECT * , (SELECT COUNT(b.Id) from ArticleComment b where ArticleId = a.Id) as CountComments
			FROM [dbo].[Article] a WHERE Id = @Id
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT <> 0 
		BEGIN
			RETURN NULL
		END
	END CATCH
END
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
	@PatientId INT = 0,
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
PRINT N'Altering [dbo].[usp_ArticleComment]...';


GO
ALTER PROC [dbo].[usp_ArticleComment] (
	@TypeGet tinyint = 0, -- 0: get all comment by ArticleId ; 1: Get comment by Id
	@Id INT = 0,
	@ArticleId INT = 0
)
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED

	BEGIN TRY
		IF @TypeGet = 0
			SELECT * FROM [dbo].[ArticleComment] WHERE [ArticleId] = @ArticleId
		ELSE If @TypeGet = 1
			SELECT * FROM [dbo].[ArticleComment] WHERE [Id] = @Id AND [ArticleId] = @ArticleId

	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT <> 0 
		BEGIN
			RETURN NULL
		END
	END CATCH
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
	@CreatedUser INT = 0,
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
PRINT N'Altering [dbo].[usp_Setting]...';


GO
ALTER PROC [dbo].[usp_Setting]
	@Id TINYINT
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED

	BEGIN TRY
		SELECT TOP 1 * FROM [dbo].[Setting]
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT <> 0 
		BEGIN
			RETURN NULL
		END
	END CATCH
END
GO
PRINT N'Altering [dbo].[usp_Setting_Transaction]...';


GO
ALTER PROC [dbo].[usp_Setting_Transaction]
(
	@Action CHAR(1) = 'I',
	@Id TINYINT = 1,
	@Title NVARCHAR(70) = '',
	@Description NVARCHAR(150) = '',
	@Keyword NVARCHAR(150) = '',
	@Membership BIT = 1,
	@DefaultRole SMALLINT = 1,
	@LoginURL VARCHAR(256) = '',
	@LockedIPNoteDefault NVARCHAR(150) = ''
)
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED

	DECLARE @return bit = 1
	BEGIN TRY
		BEGIN TRAN;
		
		IF EXISTS(SELECT TOP 1 1 FROM [dbo].[Setting])
		BEGIN
			UPDATE [dbo].[Setting]
				SET [Title] = @Title, [Keyword] = @Keyword, [Description] =  @Description, [Membership] = @Membership,
				[DefaultRole] = @DefaultRole, [LoginURL] = @LoginURL,
				[LockedIPNoteDefault] = @LockedIPNoteDefault
				WHERE [Id] = 1
		END
		ELSE
		BEGIN
			INSERT INTO [dbo].[Setting] VALUES(@Title, @Description, @Keyword, @Membership, @DefaultRole, @LoginURL, @LockedIPNoteDefault)
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
PRINT N'Altering [dbo].[usp_User]...';


GO
ALTER PROC [dbo].[usp_User]
	@Id int = 0,
	@Type tinyint = 0,
	@Search nvarchar(250) = ''
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED

	BEGIN TRY
	IF(@Id > 0)
		SELECT * FROM [dbo].[Users]
		WHERE Id = @Id
	ELSE
	BEGIN
		IF(@Type = 1)
			SELECT * FROM [dbo].[Users]
			WHERE IsAdmin = 1 AND (Name like '%' + @Search + '%' OR @Search is null)
		IF(@Type = 2)
			SELECT * FROM [dbo].[Users]
			WHERE IsDoctor = 1 AND (Name like '%' + @Search + '%' OR @Search is null)
							   AND (Tags like '%' + @Search + '%' OR @Search is null)
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
PRINT N'Creating [dbo].[usp_AppointmentLog]...';


GO
CREATE PROC [dbo].[usp_AppointmentLog]
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED

	BEGIN TRY
		SELECT * FROM [dbo].[AppointmentLog]
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT <> 0 
		BEGIN
			RETURN NULL
		END
	END CATCH
END
GO
PRINT N'Creating [dbo].[usp_AppointmentLog_Transaction]...';


GO
CREATE PROC [dbo].[usp_AppointmentLog_Transaction]
(
	@Action CHAR(1) = 'I',
	@Id UNIQUEIDENTIFIER,
	@Date DATE = '',
	@Time int = 8,
	@PhysicianId INT = 0,
	@PatientId INT = 0,
	@Symptom NVARCHAR(300) = '',
	@PatientName NVARCHAR(50) = '',
	@PatientAddress NVARCHAR(150) = '',
	@PatientEmail VARCHAR(256) = '',
	@PatientPhone VARCHAR(20) = '',
	@PatientGender TINYINT = 1,
	@PatientDoB DATE = NULL,
	@Status TINYINT = 1
)
AS BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED
	DECLARE @return BIT = 1
	DECLARE @CreatedDate VARCHAR(20)
	DECLARE @ModifiedDate VARCHAR(20)

	BEGIN TRY
		BEGIN TRAN;

			SET @ModifiedDate = [dbo].[ufnGetDate]()
			IF @Action = 'I' --INSERT
			BEGIN
				SET @Id = NEWID(); 
				SET @CreatedDate = @ModifiedDate

				INSERT [dbo].[AppointmentLog]
				VALUES(@Id, @Date, @Time, @PhysicianId, @PatientId, @Symptom,@PatientName,@PatientAddress,@PatientEmail,@PatientPhone,@PatientGender,@PatientDoB, @CreatedDate, @ModifiedDate, @Status)

			END

			IF @Action = 'U' --UPDATE
			BEGIN
				--STATUS: 0 - Just Created/Pending, 1 - Approved, 2 - Canceled
				IF EXISTS( SELECT TOP 1 1 FROM [dbo].[AppointmentLog] WHERE [Id] = @Id)
				BEGIN
					UPDATE [dbo].[AppointmentLog]
					SET [Date] = @Date, [Time] = @Time, [PhysicianId] = @PhysicianId, 
					[PatientId] = @PatientId, [Symptom] = @Symptom,
					[PatientName] = @PatientName, [PatientAddress] = @PatientAddress, [PatientEmail] = @PatientEmail, [PatientPhone] = @PatientPhone,
					[PatientGender] = @PatientGender, [PatientDoB] = @PatientDoB,
					[ModifiedDate] = @ModifiedDate, [Status] = @Status
					WHERE [Id] = @Id  

				END
			END

			IF @Action = 'D' --DELETE
			BEGIN
				IF EXISTS( SELECT TOP 1 1 FROM [dbo].[AppointmentLog] WHERE [Id] = @Id)
				BEGIN
					DELETE FROM [dbo].[AppointmentLog]
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
	SELECT @return;
END
GO
-- Refactoring step to update target server with deployed transaction logs
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '141e94c4-9e9f-49a8-9d99-eea05fb40d33')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('141e94c4-9e9f-49a8-9d99-eea05fb40d33')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '4be774d4-1722-4de7-a0a7-0ff30c260eaf')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('4be774d4-1722-4de7-a0a7-0ff30c260eaf')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'c6b00e0b-8dad-4f94-ae5c-632cc6bb929d')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('c6b00e0b-8dad-4f94-ae5c-632cc6bb929d')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '8fe1fd97-031d-4b23-b015-f154896d757d')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('8fe1fd97-031d-4b23-b015-f154896d757d')

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
ALTER TABLE [dbo].[Article] WITH CHECK CHECK CONSTRAINT [FK_Article_Users];

ALTER TABLE [dbo].[ArticleComment] WITH CHECK CHECK CONSTRAINT [FK_ArticleComment_Article];

ALTER TABLE [dbo].[Message] WITH CHECK CHECK CONSTRAINT [FK_Message_MessageFolder];

ALTER TABLE [dbo].[Message] WITH CHECK CHECK CONSTRAINT [FK_Message_Sender];

ALTER TABLE [dbo].[Message] WITH CHECK CHECK CONSTRAINT [FK_Message_Receiver];

ALTER TABLE [dbo].[MessageContent] WITH CHECK CHECK CONSTRAINT [FK_MessageContent_Message];

ALTER TABLE [dbo].[MessageRecipient] WITH CHECK CHECK CONSTRAINT [FK_MessageRecipient_Message];

ALTER TABLE [dbo].[MessageRecipient] WITH CHECK CHECK CONSTRAINT [FK_MessageRecipient_Users];

ALTER TABLE [dbo].[Module] WITH CHECK CHECK CONSTRAINT [FK_Module_Module];

ALTER TABLE [dbo].[OfferAdvise] WITH CHECK CHECK CONSTRAINT [FK_OfferAdvise_Users];

ALTER TABLE [dbo].[Organization] WITH CHECK CHECK CONSTRAINT [FK_Organization_Organization];

ALTER TABLE [dbo].[Permission] WITH CHECK CHECK CONSTRAINT [FK_Permission_Module];

ALTER TABLE [dbo].[Permission] WITH CHECK CHECK CONSTRAINT [FK_Permission_Role];

ALTER TABLE [dbo].[Schedule] WITH CHECK CHECK CONSTRAINT [FK_Schedule_User];

ALTER TABLE [dbo].[UserGroup] WITH CHECK CHECK CONSTRAINT [FK_UserGroup_Group];

ALTER TABLE [dbo].[UserGroup] WITH CHECK CHECK CONSTRAINT [FK_UserGroup_Users];

ALTER TABLE [dbo].[UserRole] WITH CHECK CHECK CONSTRAINT [FK_UserRole_Role];

ALTER TABLE [dbo].[UserRole] WITH CHECK CHECK CONSTRAINT [FK_UserRole_Users];

ALTER TABLE [dbo].[Users] WITH CHECK CHECK CONSTRAINT [FK_Users_Organization];


GO
PRINT N'Update complete.';


GO
