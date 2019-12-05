using Dapper;
using FinAppDataManger.Library.Internals.DataAccess;
using FinAppDataManger.Library.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace FinAppDataManger.Library.DataAccess
{
    public class ArticleData
    {
        private readonly IConfiguration _config;

        public ArticleData(IConfiguration config)
        {
            _config = config;
        }
        public List<ArticleModel> GetAll()
        {
            SqlDataAccess sql = new SqlDataAccess(_config);
            var output = sql.LoadData<ArticleModel, dynamic>("spArticles_GetAll", new { }, "FinAppData");
            return output;
        }
        public void AddArticle(ArticleModel article)
        {
            SqlDataAccess data = new SqlDataAccess(_config);
            if (IfArticleDoesNotExists(article.ArticleName))
            {
                data.SaveData("spArticles_AddAritcle", article, "FinAppData");
            }
            else
            {
                
            }
        }
        private bool IfArticleDoesNotExists(string nametocheck)
        {
            SqlDataAccess sql = new SqlDataAccess(_config);
            var p = new DynamicParameters();
            p.Add("@ArticleName", nametocheck);
            p.Add("@Out", DbType.Int32, direction: ParameterDirection.Output);
            sql.LoadData<dynamic, dynamic>("spArticles_ArticleLookUp", p, "FinAppData");
            var retval = p.Get<int>("@Out");
            if (retval == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
