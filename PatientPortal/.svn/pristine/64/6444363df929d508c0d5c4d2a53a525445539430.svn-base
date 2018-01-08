CREATE TABLE [dbo].[Appointment] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [PhysicianId]  NVARCHAR(128)            NOT NULL, -- refer Id  from Users 
    [PatientId]    NVARCHAR(128)            NOT NULL, -- refer Id from Users
    [Symptom]      NVARCHAR (MAX) NOT NULL,
    [CreatedDate]  VARCHAR (20)   NOT NULL,
    [ModifiedDate] VARCHAR (20)   NOT NULL,
    [ModifedUser] NVARCHAR(128) NOT NULL, 
    CONSTRAINT [PK_Appointment] PRIMARY KEY CLUSTERED ([Id] ASC)
);

GO


GO
CREATE NONCLUSTERED INDEX [idxAppointmentPatient]
    ON [dbo].[Appointment]([PatientId] ASC);


GO
CREATE NONCLUSTERED INDEX [idxAppointmentPhysician]
    ON [dbo].[Appointment]([PhysicianId] ASC);

