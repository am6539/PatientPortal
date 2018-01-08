CREATE TABLE [dbo].[Workflow] (
    [Id]   TINYINT       IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Workflow] PRIMARY KEY CLUSTERED ([Id] ASC)
);

