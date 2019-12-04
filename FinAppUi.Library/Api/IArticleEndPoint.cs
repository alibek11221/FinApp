using FinAppUi.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinAppUi.Library.Api
{
    public interface IArticleEndPoint
    {
        Task<List<ArticleModel>> GetArticlesAsync();
        Task PostArticle(ArticleModel article);
    }
}