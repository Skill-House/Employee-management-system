CREATE TABLE [dbo].[Users] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [UserId]   NVARCHAR (50) NOT NULL,
    [Password] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Users_Users] FOREIGN KEY ([Id]) REFERENCES [dbo].[Users] ([Id])
);

