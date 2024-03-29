﻿CREATE TABLE [dbo].[Wallets]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[UserId] NVARCHAR(256) NOT NULL,
	[WalletName] NVARCHAR(128) NOT NULL, 
    [CurrentAmount] MONEY NOT NULL DEFAULT 0, 
    [CreateDate] DATETIME2 NOT NULL DEFAULT getutcdate(), 
    CONSTRAINT [FK_Wallets_ToUsers] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id])

)
