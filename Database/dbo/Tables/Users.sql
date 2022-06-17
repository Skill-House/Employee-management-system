CREATE TABLE [dbo].[Users] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Roll_Id]  INT           NOT NULL,
    [UserId]   NVARCHAR (50) NOT NULL,
    [Password] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Users_1] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Users_UserRoles] FOREIGN KEY ([Roll_Id]) REFERENCES [dbo].[UserRoles] ([Id])
);

