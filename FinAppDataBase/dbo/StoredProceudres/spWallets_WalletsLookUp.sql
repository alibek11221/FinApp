CREATE PROCEDURE [dbo].[spWallets_WalletsLookUp]
	@UserId NVARCHAR(256)
	,@WalletName NVARCHAR(128)
	,@Out INT OUTPUT
AS
BEGIN
IF 
    (SELECT COUNT(*) FROM Wallets WHERE LOWER(WalletName) = LOWER(@WalletName) AND UserId = @UserId) > 0
    BEGIN
        SET @Out = 1
    END
ELSE
    BEGIN
        SET @Out = 0
    END
END
