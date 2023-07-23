using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project_API.DTO;
using Project_API.Models;

namespace Project_Web_Client
{
    public class ArticlesController : Controller
    {
        private readonly PRN_ProjectContext _context;
        private readonly HttpClient client = null;
        private string ArticleApiUrl = "";

        public ArticlesController()
        {
            client = new HttpClient();
            //_context = context;

            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ArticleApiUrl = "http://localhost:5071/api/Article/";
        }
        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var uri = ArticleApiUrl + "GetArticles/";
            HttpResponseMessage response = await client.GetAsync(uri);
            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            List<Article> listArticles = JsonSerializer.Deserialize<List<Article>>(strData, options);
            return View(listArticles);
        }
        public async Task<IActionResult> Details(int articleId)
        {

            var uri = "http://localhost:5071/api/Article/GetArticle/" + articleId;
            var response = await client.GetAsync(uri);

            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            Article article = JsonSerializer.Deserialize<Article>(strData, options);
            return View(article);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int articleId)
        {
            var uri = "http://localhost:5071/api/Article/GetArticle/" + articleId;
            var response = await client.GetAsync(uri);

            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            Article article = JsonSerializer.Deserialize<Article>(strData, options);
            return View(article);
        }

        //[HttpPost]
        //public async Task<IActionResult> Edit(ArticleDTO articleId)
        //{
        //    var uri = "http://localhost:5071/api/Article/GetArticle/ " + articleId;
        //    var response = await client.GetAsync(uri);

        //    string strData = await response.Content.ReadAsStringAsync();
        //    var options = new JsonSerializerOptions
        //    {
        //        PropertyNameCaseInsensitive = true,
        //    };
        //    Article article = JsonSerializer.Deserialize<Article>(strData, options);
        //    return View(article);
        //}


    }
}
