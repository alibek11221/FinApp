CREATE PROCEDURE [dbo].[spWallets_RemoweWallet]
	@UserId NVARCHAR(256)
	, @WalletName NVARCHAR(128)
AS
BEGIN
	DELETE 
	FROM [dbo].[Wallets]
	WHERE UserId = @UserId AND WalletName = @WalletName;
END
