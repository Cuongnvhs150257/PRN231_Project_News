using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
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
                string strData = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };

                User exuser = JsonSerializer.Deserialize<User>(strData, options);

                HttpContext.Session.SetInt32("UserId", exuser.UserId);
                HttpContext.Session.SetString("Username", exuser.Username);
                HttpContext.Session.SetString("Role", exuser.Role);

                // Return the user data to the view
                return RedirectToAction("Index", "Articles");
            }
            else
            {
                // The request was not successful, so return an error
                return BadRequest();
            }

            
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

                // Return the user data to the view
                return RedirectToAction("Index", "Users");
            }
            else
            {
                // The request was not successful, so return an error
                return BadRequest();
            }

            
        }

        [HttpGet]
        public async Task<IActionResult> Details()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return NotFound("userid is null");
            }
            var uri = UserApiUrl + "GetUserById/" + userId;
            var response = await client.GetAsync(uri);

            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            User user = JsonSerializer.Deserialize<User>(strData, options);

            return View(user);
        }

        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Remove("UserId");
            HttpContext.Session.Remove("Username");
            HttpContext.Session.Remove("Role");
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return NotFound("userid is null");
            }
            var uri = UserApiUrl + "GetUserById/" + userId;
            var response = await client.GetAsync(uri);

            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            User user = JsonSerializer.Deserialize<User>(strData, options);

            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(User user)
        {
            if (user == null)
            {
                return NotFound("username, password or email is null");
            }

            var userId = HttpContext.Session.GetInt32("UserId");

            var newuser = new User
            {
                Username = user.Username,
                Password = user.Password,
                Email = user.Email,
                Description = user.Description,
                Img = user.Img,
                Role = "User",
            };
            var content = new StringContent(JsonSerializer.Serialize(newuser));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var uri = UserApiUrl + userId;

            var response = await client.PutAsync(uri, content);

            if (response.IsSuccessStatusCode)
            {

                // Return the user data to the view
                return RedirectToAction("Details", "Users");
            }
            else
            {
                // The request was not successful, so return an error
                return BadRequest();
            }
        }
        public async Task<IActionResult> Delete()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return NotFound("userid is null");
            }
            var uri = UserApiUrl + userId;
            var response = await client.DeleteAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                HttpContext.Session.Remove("UserId");
                HttpContext.Session.Remove("Username");
                HttpContext.Session.Remove("Role");
                // Return the user data to the view
                return RedirectToAction("Index", "Users");
            }
            else
            {
                // The request was not successful, so return an error
                return BadRequest();
            }
        }
    }
}
