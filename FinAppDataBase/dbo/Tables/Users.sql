﻿CREATE TABLE [dbo].[Users]
(
	[Id] NVARCHAR(256) NOT NULL PRIMARY KEY, 
    [FirstName] NVARCHAR(128) NOT NULL, 
    [LastName] NVARCHAR(128) NOT NULL, 
    [EmailAddress] NVARCHAR(128) NOT NULL
)