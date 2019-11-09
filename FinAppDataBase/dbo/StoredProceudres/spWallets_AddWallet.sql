CREATE PROCEDURE [dbo].[spWallets_AddWallet]
	@UserId NVARCHAR(256)
	,@WalletName NVARCHAR(128)
	,@CurrentAmount money
AS
BEGIN
	SET NOCOUNT ON

	INSERT 
	INTO [dbo].[Wallets](UserId, WalletName, CurrentAmount)
	VALUES (@UserId, @WalletName, @CurrentAmount);

END