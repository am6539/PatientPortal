CREATE TABLE [dbo].[GalleryStore]
(
	[Id] VARCHAR(128) NOT NULL PRIMARY KEY, 
	[ParentId] VARCHAR(128) NOT NULL, 
	[Img] VARCHAR(256) NOT NULL, 
	CONSTRAINT [FK_GalleryStore_Gallery] FOREIGN KEY ([ParentId]) REFERENCES [Gallery]([Id])
)
