CREATE TABLE [dbo].[WorkflowNavigation] (
    [WorkflowStateId]     SMALLINT NOT NULL,
    [NextWorkflowStateId] SMALLINT NOT NULL,
    CONSTRAINT [PK_WorkflowNavigation] PRIMARY KEY CLUSTERED ([WorkflowStateId] ASC, [NextWorkflowStateId] ASC),
    CONSTRAINT [FK_WorkflowNavigation_WorkflowState] FOREIGN KEY ([WorkflowStateId]) REFERENCES [dbo].[WorkflowState] ([Id]),
    CONSTRAINT [FK_WorkflowNavigation_WorkflowState1] FOREIGN KEY ([NextWorkflowStateId]) REFERENCES [dbo].[WorkflowState] ([Id])
);

