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
        IMapper _mapper;
        IWalletEndPoint _walletEndPoint;
        ILoggedInUserModel _loggedInUser;
        IWindowManager _manager;
        TransitionViewModel _transitionVM;

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

        private string _userName;

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

        protected async override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadWallets();
            UserName = _loggedInUser?.FirstName;
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
                NotifyOfPropertyChange(() => CanMakeTransition);
                CurrentAmount = SelectedWallet?.CurrentAmount.ToString("C");
            }
        }

        private string _currentAmount;

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

        private BindingList<WalletDisplayModel> _wallets;

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
            var wallets = _mapper.Map<List<WalletDisplayModel>>(walletsList);
            Wallets = new BindingList<WalletDisplayModel>(wallets);
        }
        public void ResetForm()
        {
            UserName = "";
            SelectedWallet = null;
            CurrentAmount = "";

        }
        public async void MakeTransition()
        {
          await _manager.ShowDialogAsync(_transitionVM);
        }
    }
}
