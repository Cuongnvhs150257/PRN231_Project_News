using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project_API.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Project_Web_Client
{
    public class CategoriesController : Controller
    {
        private readonly PRN_ProjectContext _context;
        private readonly HttpClient client = null;
        private string CateApiUrl = "";

        public CategoriesController()
        {
            client = new HttpClient();
            //_context = context;

            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            CateApiUrl = "http://localhost:5071/api/Category/";
        }
        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await client.GetAsync(CateApiUrl+ "GetAllCategory");
            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            List<Category> listCate = JsonSerializer.Deserialize<List<Category>>(strData, options);
            return View(listCate);
        }



        // GET: Articles/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArticleId,Title,Content,CreateDate,EditDate,View,Summary,UserId")] Article article)
        {
            if (ModelState.IsValid)
            {
                _context.Add(article);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email", article.UserId);
            return View(article);
        }
    }
}
