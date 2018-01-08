CREATE TABLE [dbo].[MailSetting] (
    [Id]    TINYINT       IDENTITY (1, 1) NOT NULL,
	[Name] NVARCHAR (256) NOT NULL,
    [Email] VARCHAR (256) NOT NULL,
	[Pwd] VARCHAR(60) NOT NULL,
    [Host]  VARCHAR (150) NOT NULL,
    [Port]  INT   NOT NULL,
    [IsSSL] BIT           NOT NULL,
    CONSTRAINT [PK_MailConfig] PRIMARY KEY CLUSTERED ([Id] ASC)
);

