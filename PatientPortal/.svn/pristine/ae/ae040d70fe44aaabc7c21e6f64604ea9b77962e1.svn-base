CREATE TABLE [dbo].[SiteTranslation]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[ResourceId] INT NOT NULL, -- Primary Key
	[LanguageId] TINYINT NOT NULL,
	[Translation_Reference] CHAR(128) NOT NULL, -- Table Name +  Column Name EXP: Slider_Title
	[Translation_TXT]  NVARCHAR(500) NOT NULL -- Translation text
)

GO

CREATE INDEX [IX_SiteTranslation_References] ON [dbo].[SiteTranslation] ([ResourceId],[LanguageId], [Translation_Reference])

