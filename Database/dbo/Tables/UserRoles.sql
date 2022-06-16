CREATE TABLE [dbo].[UserRoles] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [UserId]   NVARCHAR (50) NOT NULL,
    [UserRole] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_UserRoles_1] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserRoles_UserRoles] FOREIGN KEY ([Id]) REFERENCES [dbo].[Users] ([Id])
);

