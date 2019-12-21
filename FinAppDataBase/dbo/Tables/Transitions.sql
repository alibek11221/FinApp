CREATE TABLE [dbo].[Transitions]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[UserId]  NVARCHAR(256) NOT NULL, 
	[WalletId] INT NOT NULL,
	[TransitionDate] datetime2 NOT NULL,
	[TransitionAmount] MONEY NOT NULL DEFAULT 0,
	[TransitionType] BIT NOT NULL, 
    [ArticleId] INT NOT NULL, 
    CONSTRAINT [FK_Transition_ToUsers] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id]), 
    CONSTRAINT [FK_Transitions_ToWallets] FOREIGN KEY ([WalletId]) REFERENCES [Wallets]([Id]), 
    CONSTRAINT [FK_Transitions_ToArticles] FOREIGN KEY ([ArticleId]) REFERENCES [Articles]([Id])
)
