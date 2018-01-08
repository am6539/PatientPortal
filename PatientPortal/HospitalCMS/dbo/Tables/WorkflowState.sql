CREATE TABLE [dbo].[WorkflowState] (
    [Id]         SMALLINT      IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (50) NOT NULL,
    [WorkflowId] TINYINT       NOT NULL,
    [IsActive]   BIT           NOT NULL,
    [IsFirst] BIT NOT NULL, 
    CONSTRAINT [PK_WorkflowStatus] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_WorkflowState_Workflow] FOREIGN KEY ([WorkflowId]) REFERENCES [dbo].[Workflow] ([Id])
);

GO
CREATE NONCLUSTERED INDEX [idxWorkflowStateWorkflow]
    ON [dbo].[WorkflowState]([WorkflowId] ASC);

