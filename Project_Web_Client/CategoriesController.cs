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

        [HttpGet]
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

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (category == null)
            {
                return NotFound("category name is null");
            }

            var newcate = new Category
            {
                CategoryName = category.CategoryName,
            };
            var content = new StringContent(JsonSerializer.Serialize(newcate));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var uri = CateApiUrl + "CreateCate";

            var response = await client.PostAsync(uri, content);

            if (response.IsSuccessStatusCode)
            {

                // Return the user data to the view
                return RedirectToAction("Index", "Categories");
            }
            else
            {
                // The request was not successful, so return an error
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int CategoryId)
        {
            if (CategoryId == null)
            {
                return NotFound("CategoryId is null");
            }
            var uri = CateApiUrl + "GetCategoryById/Id?id=" + CategoryId;
            var response = await client.GetAsync(uri);

            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            Category cate = JsonSerializer.Deserialize<Category>(strData, options);
            return View(cate);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Category category)
        {
            if (category == null)
            {
                return NotFound("category is null");
            }

            var newcate = new Category
            {
                CategoryName = category.CategoryName,
            };
            var content = new StringContent(JsonSerializer.Serialize(newcate));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var uri = CateApiUrl + "EditCate?cateid=" + category.CategoryId;

            var response = await client.PutAsync(uri, content);

            if (response.IsSuccessStatusCode)
            {
                // Return the user data to the view
                return RedirectToAction("Index", "Categories");
            }
            else
            {
                // The request was not successful, so return an error
                return BadRequest();
            }
        }


        public async Task<IActionResult> Delete(int CategoryId)
        {
            if (CategoryId == null)
            {
                return NotFound("userid is null");
            }
            var uri = CateApiUrl + "DeleteCate/id?id=" + CategoryId;
            var response = await client.DeleteAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Categories");
            }
            else
            {
                // The request was not successful, so return an error
                return BadRequest();
            }
        }



    }
}
