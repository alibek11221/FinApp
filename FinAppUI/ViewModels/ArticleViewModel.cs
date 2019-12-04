using Caliburn.Micro;
using FinAppUi.Library.Api;
using FinAppUi.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FinAppUI.ViewModels
{
    public class ArticleViewModel : Screen
    {
        private readonly IArticleEndPoint _article;

        public ArticleViewModel(IArticleEndPoint article)
        {
            _article = article;
        }
        private string _articleName;
        private ArticleModel _articleModel = new ArticleModel();
        public string ArticleName
        {
            get { return _articleName; }
            set
            { 
                _articleName = value;
                NotifyOfPropertyChange(() => ArticleName);
            }
        }
        public bool IsErrorVisible
        {
            get
            {
                bool output = false;
                if (ErrorMessage?.Length > 0)
                {
                    output = true;
                }
                return output;

            }
        }
        private string _errorMessage;

        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                NotifyOfPropertyChange(() => ErrorMessage);
                NotifyOfPropertyChange(() => IsErrorVisible);
            }
        }

        public async Task AddArticleAsync()
        {
            try
            {
                _articleModel.ArticleName = this.ArticleName;
                await _article.PostArticle(_articleModel);
                this.ArticleName = "";            
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}
