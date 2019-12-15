using Caliburn.Micro;
using FinAppUi.Library.Api;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FinAppUi.Library.Models;

namespace FinAppUI.ViewModels
{
    public class TransitionViewModel : Screen
    {
        private readonly IArticleEndPoint _articleEndPoint;
        public TransitionViewModel(IArticleEndPoint articleEndPoint)
        {
            _articleEndPoint = articleEndPoint;
        }
        private int _amount;
        public int Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
        protected async override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadArticles();
        }
        private BindingList<ArticleModel> _articles;
        public BindingList<ArticleModel> Articles
        {
            get { return _articles; }
            set 
            { 
                _articles = value;
                NotifyOfPropertyChange(() => Articles);
            }
        }
        private async Task LoadArticles()
        {
            List<ArticleModel> articlesList = await _articleEndPoint.GetArticlesAsync();
            Articles = new BindingList<ArticleModel>(articlesList);
        }
        public async Task MakeTransitionAsync()
        {
            
        }
    }
}
