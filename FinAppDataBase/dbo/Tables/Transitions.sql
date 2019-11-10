CREATE TABLE [dbo].[Transitions]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[WalletId] INT NOT NULL,
	[TransitionDate] datetime2 NOT NULL,
	[TransitionAmount] MONEY NOT NULL DEFAULT 0
)
