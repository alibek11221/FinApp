using AutoMapper;
using Caliburn.Micro;
using FinAppUi.Library.Api;
using FinAppUi.Library.Models;
using FinAppUI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinAppUI.ViewModels
{
    public class WalletViewModel : Screen
    {
        private readonly IMapper _mapper;
        private readonly IWalletEndPoint _walletEndPoint;
        private readonly ILoggedInUserModel _loggedInUser;
        private readonly IWindowManager _manager;
        private readonly TransitionViewModel _transitionVM;
        private string _userName;
        private WalletDisplayModel _selectedwallet;
        private string _currentAmount;
        private BindingList<WalletDisplayModel> _wallets;
        public WalletViewModel(IMapper mapper, IWalletEndPoint walletEndPoint
            , ILoggedInUserModel loggedInUser, IWindowManager manager
            , TransitionViewModel transitionVM)
        {
            _mapper = mapper;
            _walletEndPoint = walletEndPoint;
            _loggedInUser = loggedInUser;
            _manager = manager;
            _transitionVM = transitionVM;
        }
        public bool CanMakeTransition
        {
            get
            {
                bool output = false;
                if (SelectedWallet != null)
                {
                    output = true;
                }
                return  output;
            }
        }
        public string UserName
        {
            get 
            {
                return _userName; 
            }
            set 
            { 
                _userName = value;
                NotifyOfPropertyChange(() => UserName);
            }
        }
        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadWallets();
            UserName = _loggedInUser?.FirstName;
        }
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
                NotifyOfPropertyChange(() => CanMakeTransition);
                CurrentAmount = SelectedWallet?.CurrentAmount.ToString("C");
            }
        }
        public string CurrentAmount
        {
            get 
            { 
                return _currentAmount; 
            }
            set 
            {
                _currentAmount = value;
                NotifyOfPropertyChange(() => CurrentAmount);
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
        private async Task LoadWallets()
        {
            var walletsList = await _walletEndPoint.GetAll();
            if (!(walletsList==null))
            {
                var wallets = _mapper.Map<List<WalletDisplayModel>>(walletsList);
                Wallets = new BindingList<WalletDisplayModel>(wallets);
            }
            else
            {
                Wallets = new BindingList<WalletDisplayModel>();
            }
        }
        public async Task MakeTransitionAsync()
        {
            WalletModel currentWallet = _mapper.Map<WalletModel>(SelectedWallet);
            await _manager.ShowDialogAsync(_transitionVM);
        }
    }
}
