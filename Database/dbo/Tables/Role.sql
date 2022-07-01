﻿CREATE TABLE [dbo].[Role] (
    [RoleId]   INT          IDENTITY (1, 1) NOT NULL,
    [RoleName] VARCHAR (50) NULL,
    CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED ([RoleId] ASC)
);

