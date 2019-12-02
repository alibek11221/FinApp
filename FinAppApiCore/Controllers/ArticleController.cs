using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinAppDataManger.Library.DataAccess;
using FinAppDataManger.Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FinAppApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : Controller
    {
        private readonly IConfiguration _config;

        public ArticleController(IConfiguration config)
        {
            _config = config;
        }
        [HttpGet]
        public List<ArticleModel> GetAll()
        {
            ArticleData data = new ArticleData(_config);
            List<ArticleModel> output = data.GetAll();
            return output;
        }
        [HttpPost]
        public void AddArticle(ArticleModel article)
        {
            ArticleData data = new ArticleData(_config);
            data.AddArticle(article);
        }
    }
}