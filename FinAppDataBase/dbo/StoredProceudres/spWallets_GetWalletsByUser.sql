CREATE PROCEDURE [dbo].[spWallets_GetWalletsByUser]
	@Id nvarchar(256)
AS
BEGIN
	SET NOCOUNT ON
	SELECT Id, WalletName, CurrentAmount
	FROM [dbo].[Wallets]
	WHERE [Wallets].UserId = @Id
END