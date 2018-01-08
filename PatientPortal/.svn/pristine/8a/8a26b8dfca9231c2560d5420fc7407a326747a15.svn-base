CREATE TABLE [dbo].[Organization] (
    [Id]       SMALLINT       IDENTITY (1, 1) NOT NULL,
    [ParentId] SMALLINT       NULL,
    [Name]     NVARCHAR (150) NOT NULL,
    [Phone]    VARCHAR (50)   NULL,
    [Fax]      VARCHAR (50)   NULL,
    [Email]    VARCHAR (256)  NULL,
    [Address]  NVARCHAR(150)  NULL,
    CONSTRAINT [PK_Organization] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_Organization_Organization] FOREIGN KEY ([ParentId]) REFERENCES [dbo].[Organization] ([Id])
);

