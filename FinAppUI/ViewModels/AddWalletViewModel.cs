using AutoMapper;
using Caliburn.Micro;
using FinAppUi.Library.Api;
using FinAppUi.Library.Models;
using FinAppUI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace FinAppUI.ViewModels
{
	public class AddWalletViewModel : Screen
	{
		public AddWalletViewModel(IWalletEndPoint walletEndPoint, IMapper mapper)
		{
			_walletEndPoint = walletEndPoint;
			_mapper = mapper;
		}
		private string _walletName;
		private decimal _currentAmount;
		private readonly IWalletEndPoint _walletEndPoint;
		private readonly IMapper _mapper;
		private BindingList<WalletDisplayModel> _wallets;

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
			await LoadWallets();
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
		private async Task LoadWallets()
		{
			var walletsList = await _walletEndPoint.GetAll();
			if (!(walletsList == null))
			{
				var wallets = _mapper.Map<List<WalletDisplayModel>>(walletsList);
				Wallets = new BindingList<WalletDisplayModel>(wallets);
			}
			else
			{
				Wallets = new BindingList<WalletDisplayModel>();
			}
		}
		public BindingList<WalletDisplayModel> Wallets
		{
			get { return _wallets; }
			set
			{
				_wallets = value;
				NotifyOfPropertyChange(() => Wallets);
			}
		}
		protected override async void OnViewLoaded(object view)
		{
			base.OnViewLoaded(view);
			await LoadWallets();
		}
		private WalletDisplayModel _selectedwallet;
		public WalletDisplayModel SelectedWallet
		{
			get
			{
				return _selectedwallet;
			}
			set
			{
				_selectedwallet = value;
				NotifyOfPropertyChange(() => SelectedWallet);
				NotifyOfPropertyChange(() => CanRemoveWallet);
			}
		}
		public bool CanRemoveWallet
		{
			get
			{
				bool output = true;
				if (SelectedWallet == null)
				{
					output = false;
				}
				return output;
			}
		}
		public async Task RemoveWalletAsync()
		{
			WalletModel wallet = _mapper.Map<WalletModel>(SelectedWallet);
			await _walletEndPoint.Remove(wallet);
			await LoadWallets();
		}
	}
}
