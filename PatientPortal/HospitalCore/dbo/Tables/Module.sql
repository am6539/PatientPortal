CREATE TABLE [dbo].[Module] (
	[Id]       SMALLINT  NOT NULL,
	[Title]    NVARCHAR (128) NOT NULL,
	[Handler]  NVARCHAR (256) NOT NULL,
	[Sort]     TINYINT        NOT NULL,
	[ParentId] SMALLINT       NOT NULL,
	[Group] CHAR(1) NOT NULL, 
	[ClassName] VARCHAR(50) NULL, 
    CONSTRAINT [PK_Module] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO
CREATE NONCLUSTERED INDEX [idxModuleGroup]
	ON [dbo].[Module]([Group] ASC);
