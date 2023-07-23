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
    public class UsersController : Controller
    {
        private readonly HttpClient client = null;
        private string UserApiUrl = "";

        public UsersController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            UserApiUrl = "http://localhost:5071/api/User/";
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

            if (username == null || password == null)
            {
                return NotFound("username or password is null");
            }

            var uri = UserApiUrl + "GetUserById/" + username + "/" + password;
            var response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                // The request was successful, so get the user data from the response
                var user = await response.Content.ReadAsStringAsync();

                // Return the user data to the view
                return RedirectToAction("Index", "Articles");
            }
            else
            {
                // The request was not successful, so return an error
                return BadRequest();
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            if (user == null)
            {
                return NotFound("username, password or email is null");
            }

            var newuser = new User
            {
                Username = user.Username,
                Password = user.Password,
                Email = user.Email,
                Role = "User",
            };
            var content = new StringContent(JsonSerializer.Serialize(newuser));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var uri = UserApiUrl + "CreateUser";

            var response = await client.PostAsync(uri, content);
            
            if (response.IsSuccessStatusCode)
            {
                // The request was successful, so get the user data from the response
                var usersu = await response.Content.ReadAsStringAsync();

                // Return the user data to the view
                return RedirectToAction("Index", "Users");
            }
            else
            {
                // The request was not successful, so return an error
                return BadRequest();
            }

            return View();
        }
    }
}
