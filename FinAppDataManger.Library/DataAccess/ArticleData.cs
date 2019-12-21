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
        private readonly SqlDataAccess _sql;
        public ArticleData(IConfiguration config)
        {
            _config = config;
            _sql = new SqlDataAccess(_config);
        }
        public List<ArticleModel> GetAll()
        {
            var output = _sql.LoadData<ArticleModel, dynamic>("spArticles_GetAll", new { }, "FinAppData");
            return output;
        }
        public bool AddArticle(ArticleModel article)
        {
            if (ArticleDoesNotExist(article.ArticleName))
            {
                _sql.Execute("spArticles_AddAritcle", article, "FinAppData");
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool ArticleDoesNotExist(string nametocheck)
        {
            var p = new DynamicParameters();
            p.Add("@ArticleName", nametocheck);
            p.Add("@Out", DbType.Int32, direction: ParameterDirection.Output);
            _sql.LoadData<dynamic, dynamic>("spArticles_ArticleLookUp", p, "FinAppData");
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
