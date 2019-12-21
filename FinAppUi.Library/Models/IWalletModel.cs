namespace FinAppUi.Library.Models
{
    public interface IWalletModel
    {
        int Id { get; set; }
        string WalletName { get; set; }
        decimal CurrentAmount { get; set; }
    }
}