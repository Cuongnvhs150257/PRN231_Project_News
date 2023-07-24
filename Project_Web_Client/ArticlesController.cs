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
            ArticleDTO article = JsonSerializer.Deserialize<ArticleDTO>(strData, options);
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
            ArticleDTO article = JsonSerializer.Deserialize<ArticleDTO>(strData, options);
            
            return View(article);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int articleId, ArticleDTO article)
        {

            if (articleId == null)
            {
                return NotFound("ArticleId is null");
            }



            var listCate = new List<Category>();
            var cate = new Category()
            {
                CategoryId = 3,
                CategoryName = "đời sống"
            };
            listCate.Add(cate);

            var newaticle = new Article
            {
                ArticleId = article.ArticleId,
                Content = article.Content,
                Title = article.Title,
                CreateDate = article.CreateDate,
                EditDate = article.EditDate,
                Img = article.Img,
                View = article.View,
                Summary = article.Summary,
                UserId = article.UserId,
                Categories = listCate
            };

            var content = new StringContent(JsonSerializer.Serialize(newaticle));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var uri = "http://localhost:5071/api/Article/EditNews?articleId=" + articleId;
            var response = await client.PutAsync(uri, content);

            if (response.IsSuccessStatusCode)
            {
                // Return the user data to the view
                return RedirectToAction("Index", "Articles");
            }
            else
            {
                // The request was not successful, so return an error
                return BadRequest();
            }
        }

        public async Task<IActionResult> Delete(int articleId)
        {
            if (articleId == null)
            {
                return NotFound("userid is null");
            }
            var uri = "http://localhost:5071/api/Article/DeleteArticle/" + articleId;
            var response = await client.DeleteAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Articles");
            }
            else
            {
                // The request was not successful, so return an error
                return BadRequest();
            }
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            return View();
        }

        ////[HttpPost]
        public async Task<IActionResult> Create(ArticleDTO article)
        {
            if (article == null)
            {
                return NotFound("category name is null");
            }

            var listCate = new List<Category>();
            var cate = new Category()
            {
                CategoryId = 2,
                CategoryName = "công nghệ"
            };
            listCate.Add(cate);
            var newArticle = new Article
            {
               ArticleId = new int(),
               Categories = listCate,
               Title = article.Title,
               Summary = article.Summary,
               Content = article.Content,
               CreateDate = article.CreateDate,
               EditDate = article.EditDate,
               Img = article.Img,
               UserId = article.UserId,              
            };
            var content = new StringContent(JsonSerializer.Serialize(newArticle));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var uri = "http://localhost:5071/api/Article/CreateNews";

            var response = await client.PostAsync(uri, content);

            if (response.IsSuccessStatusCode)
            {

                // Return the user data to the view
                return RedirectToAction("Index", "Articles");
            }
            else
            {
                // The request was not successful, so return an error
                return BadRequest();
            }
        }
    }
}
