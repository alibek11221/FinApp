using FinAppUi.Library.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FinAppUi.Library.Api
{
    public class ArticleEndPoint : IArticleEndPoint
    {
        private readonly IAPIHelper _aPIHelper;
        public ArticleEndPoint(IAPIHelper aPIHelper)
        {
            _aPIHelper = aPIHelper;
        }
        public async Task<List<ArticleModel>> GetArticlesAsync()
        {
            using (HttpResponseMessage response = await _aPIHelper.ApiClient.GetAsync("api/Article"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<ArticleModel>>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
        public async Task PostArticle(ArticleModel article)
        {
            HttpResponseMessage response = await _aPIHelper.ApiClient.PostAsJsonAsync("api/Article", article);
            response.Dispose();
        }
    }
}
