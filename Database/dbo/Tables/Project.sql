CREATE TABLE [dbo].[Project] (
    [ProjectId]          INT          IDENTITY (1, 1) NOT NULL,
    [ProjectName]        VARCHAR (50) NOT NULL,
    [ProjectDescription] VARCHAR (50) NOT NULL,
    [ProjectDuration]    INT          NOT NULL,
    CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED ([ProjectId] ASC)
);



