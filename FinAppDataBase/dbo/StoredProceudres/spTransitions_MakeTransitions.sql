CREATE PROCEDURE [dbo].[spTransitions_MakeTransitions]
	@UserId NVARCHAR(256)
	, @WalletId INT
	, @TransitionAmount MONEY
	, @TransitionDate datetime2
	, @TransitionType BIT
	, @ArticleId INT

AS
	BEGIN
		INSERT INTO [dbo].[Transitions](UserId, WalletId, TransitionAmount, TransitionDate, TransitionType, ArticleId)
		VALUES (@UserId, @WalletId, @TransitionAmount, @TransitionDate, @TransitionType, @ArticleId);
		IF(@TransitionType = 0)
		BEGIN
				UPDATE Wallets
				SET CurrentAmount = CurrentAmount - @TransitionAmount
				WHERE Wallets.UserId = @UserId AND Wallets.Id = @WalletId;
		END
		IF(@TransitionType = 1)
		BEGIN
			UPDATE Wallets
				SET CurrentAmount = CurrentAmount + @TransitionAmount
				WHERE Wallets.UserId = @UserId AND Wallets.Id = @WalletId;
		END
	END