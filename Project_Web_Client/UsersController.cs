using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project_API.Models;

namespace Project_Web_Client
{
    public class UsersController : Controller
    {
        private readonly HttpClient client = null;
        private string UserApiUrl = "";

        public UsersController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            UserApiUrl = "http://localhost:5071/api/User/GetUserById";
        }

        // GET: Users
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string username, string password)
        {

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }


    }
}
