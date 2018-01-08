CREATE TABLE [dbo].[OfferAdvise] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Date]      SMALLDATETIME  NOT NULL,
    [Detail]    NVARCHAR (MAX) NOT NULL,
    [PatientId] NVARCHAR(128)            NOT NULL,
    [Tag] NVARCHAR(150) NOT NULL, 
    [Status] TINYINT NOT NULL, 
    [Message] NVARCHAR(MAX) NULL, 
    CONSTRAINT [PK_OfferAdvise] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO

CREATE INDEX [IX_OfferAdvise_PatientId] ON [dbo].[OfferAdvise] ([PatientId])
