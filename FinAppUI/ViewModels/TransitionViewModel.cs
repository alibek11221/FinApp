using Caliburn.Micro;
using FinAppUi.Library.Api;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FinAppUi.Library.Models;
using FinAppUI.Models;
using AutoMapper;

namespace FinAppUI.ViewModels
{
    public class TransitionViewModel : Screen
    {
        private readonly IArticleEndPoint _articleEndPoint;
        private readonly ITransitionEndPoint _transitionEndPoint;
        private readonly IMapper _mapper;
        private readonly IWalletEndPoint _walletEndPoint;
        private bool _outcomeChecked;
        private bool _incomeChecked;
        private ArticleModel _article;
        private BindingList<ArticleModel> _articles;
        private BindingList<WalletModel> _wallets;
        private WalletModel _selectedwallet;
        private decimal _amount;
        public TransitionViewModel(IArticleEndPoint articleEndPoint, 
             ITransitionEndPoint transitionEndPoint, IMapper mapper
            , IWalletEndPoint walletEndPoint)
        {
            _articleEndPoint = articleEndPoint;
            _transitionEndPoint = transitionEndPoint;
            _mapper = mapper;
            _walletEndPoint = walletEndPoint;
        }

        public decimal Amount
        {
            get { return _amount; }
            set 
            {
                _amount = value;
                NotifyOfPropertyChange(() => Amount);
                NotifyOfPropertyChange(() => CanMakeTransition);
            }
        }
        protected async override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadWallets();
            await LoadArticles();
        }
        private async Task LoadWallets()
        {
            var walletsList = await _walletEndPoint.GetAll();
            if (!(walletsList == null))
            {
                Wallets = new BindingList<WalletModel>(walletsList);
            }
            else
            {
                Wallets = new BindingList<WalletModel>();
            }
        }
        public WalletModel SelectedWallet
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
            }
        }
        public BindingList<WalletModel> Wallets
        {
            get { return _wallets; }
            set
            {
                _wallets = value;
                NotifyOfPropertyChange(() => Wallets);
            }
        }
        public BindingList<ArticleModel> Articles
        {
            get { return _articles; }
            set 
            { 
                _articles = value;
                NotifyOfPropertyChange(() => Articles);
            }
        }
        public ArticleModel Article
        {
            get 
            { 
                return _article; 
            }
            set 
            {
                _article = value;
                NotifyOfPropertyChange(() => Article);
                NotifyOfPropertyChange(() => CanMakeTransition);
            }
        }
        public bool IncomeChecked
        {
            get { return _incomeChecked; }
            set 
            {
                if (value.Equals(IncomeChecked)) return;
                _incomeChecked = value;
                NotifyOfPropertyChange(() => IncomeChecked);
                NotifyOfPropertyChange(() => CanMakeTransition);
            }
        }
        public bool OutcomeChecked
        {
            get { return _outcomeChecked; }
            set
            {
                if (value.Equals(OutcomeChecked)) return;
                _outcomeChecked = value;
                NotifyOfPropertyChange(() => OutcomeChecked);
                NotifyOfPropertyChange(() => CanMakeTransition);
            }
        }
        private async Task LoadArticles()
        {
            List<ArticleModel> articlesList = await _articleEndPoint.GetArticlesAsync();
            Articles = new BindingList<ArticleModel>(articlesList);
        }
        public bool CanMakeTransition
        {
            get
            {
                bool output = true;
                if (SelectedWallet == null)
                {
                    output = false;
                }
                if (Article == null)
                {
                    output = false;
                }
                if (Amount <= 0)
                {
                    output = false;
                }
                if (!OutcomeChecked && !IncomeChecked)
                {
                    output = false;
                }
                return output;
            }
        }
        public async Task MakeTransitionAsync()
        {
            TranstitionModel transtition = new TranstitionModel
            {
                Amount = this.Amount,
                Article = this.Article,
                TransitionDate = DateTime.Now,
                Wallet = this._selectedwallet
            };
            if (IncomeChecked)
            {
                transtition.TransitionType = true;
            }
            if (OutcomeChecked)
            {
                transtition.TransitionType = false;
            }
            await _transitionEndPoint.Make(transtition);
        }
    }
}
