CREATE TABLE [dbo].[Article] (
    [Id]        INT             IDENTITY (1, 1) NOT NULL,
    [Date]      SMALLDATETIME   NOT NULL,
    [Title]     NVARCHAR (150)  NOT NULL,
    [Detail]    NVARCHAR (1000) NOT NULL,
    [PatientId] NVARCHAR(128)             NOT NULL,
    [Status]    TINYINT         NOT NULL,-- 1: Just Created, 2: Approved, 3: Move to Trash
	[IsClosed] BIT NOT NULL, -- Closed Topic - comment is disable
    CONSTRAINT [PK_Article] PRIMARY KEY CLUSTERED ([Id] ASC)
);

