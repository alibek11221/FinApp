using Caliburn.Micro;
using FinAppUi.Library.Api;
using FinAppUi.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FinAppUI.ViewModels
{
    public class AddWalletViewModel : Screen
    {
		public AddWalletViewModel(IWalletEndPoint walletEndPoint)
		{
			_walletEndPoint = walletEndPoint;
		}
		private string _walletName;
		private decimal _currentAmount = 0;
		private readonly IWalletEndPoint _walletEndPoint;

		public string WalletName
		{
			get 
			{ 
				return _walletName; 
			}
			set 
			{ 
				_walletName = value;
				NotifyOfPropertyChange(() => WalletName);
				NotifyOfPropertyChange(() => CanAddWallet);
			}
		}
		public decimal CurrentAmount
		{
			get 
			{
				return _currentAmount;
			}
			set 
			{
				_currentAmount = value;
				NotifyOfPropertyChange(() => CurrentAmount);
				NotifyOfPropertyChange(() => CanAddWallet);
			}
		}
		public async Task AddWalletAsync()
		{
			WalletModel wallet = new WalletModel();
			wallet.CurrentAmount = this.CurrentAmount;
			wallet.WalletName = this.WalletName;
			await _walletEndPoint.Add(wallet);
		}
		public bool CanAddWallet
		{
			get 
			{
				bool output = true;
				if (string.IsNullOrWhiteSpace(WalletName))
				{
					output = false;
				}
				if (string.IsNullOrWhiteSpace(CurrentAmount.ToString()))
				{
					output = false;
				}
				return output;
			}
		}

	}
}
