CREATE TABLE [dbo].[WorkersBase] (
    [Id]         BIGINT         IDENTITY (1, 1) NOT NULL,
    [FirstName]  NVARCHAR (MAX) NULL,
    [LastName]   NVARCHAR (MAX) NULL,
    [MiddleName] NVARCHAR (MAX) NULL,
    [Email]      NVARCHAR (MAX) NULL,
    [Project_Id] BIGINT         NULL,
    CONSTRAINT [PK_dbo.WorkersBase] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[ProjectsBase] (
    [Id]                 BIGINT         IDENTITY (1, 1) NOT NULL,
    [Name]               NVARCHAR (MAX) NULL,
    [CustomerCompany]    NVARCHAR (MAX) NULL,
    [ConstractorCompany] NVARCHAR (MAX) NULL,
    [EmployeeId]         BIGINT         NULL,
    [LeaderId]           BIGINT         NULL,
    [Start]              DATETIME       NOT NULL,
    [End]                DATETIME       NOT NULL,
    [Priority]           INT            NOT NULL,
    [Comment]            NVARCHAR (MAX) NULL
    CONSTRAINT [PK_dbo.ProjectsBase] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.ProjectsBase_dbo.WorkersBase_EmployeeId] FOREIGN KEY ([EmployeeId]) REFERENCES [dbo].[WorkersBase] ([Id]),
    CONSTRAINT [FK_dbo.ProjectsBase_dbo.WorkersBase_LeaderId] FOREIGN KEY ([LeaderId]) REFERENCES [dbo].[WorkersBase] ([Id])
);

CREATE TABLE [dbo].[ProjectsWorkersBase] (
	[ProjectId]	BIGINT,
	[WorkerId]	BIGINT,
	CONSTRAINT Project_Worker_PK PRIMARY KEY (ProjectId, WorkerId),
	CONSTRAINT FK_ProjectsBase FOREIGN KEY (ProjectId) REFERENCES dbo.ProjectsBase (Id),
	CONSTRAINT FK_WorkersBase FOREIGN KEY (WorkerId) REFERENCES dbo.WorkersBase (Id)
);
GO
CREATE NONCLUSTERED INDEX [IX_EmployeeId]
    ON [dbo].[ProjectsBase]([EmployeeId] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_LeaderId]
    ON [dbo].[ProjectsBase]([LeaderId] ASC);