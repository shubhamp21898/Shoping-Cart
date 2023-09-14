using Microsoft.AspNetCore.Mvc;
using ProductCart.Models;
using ProductCart.Services;
using System.Net.Http.Headers;
using System.Net.Http;

namespace ProductCart.Controllers
{
    public class UserController : Controller
    {
        private readonly IUser_Service _user_service;
        private readonly HttpClient _httpClient;
        public UserController(IUser_Service user_service, HttpClient httpClient)
        {
            _user_service = user_service;
            _httpClient = httpClient;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult<string>> Login(Login loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            string token = await _user_service.UserLogin(loginDto);


            if (!string.IsNullOrEmpty(token))
            {
                // Include the token in subsequent requests
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                //return Ok(new { Token = token, Message = "Login successful." });
                return RedirectToAction("Cart", "ProductUI");
            }
            else
            {
                return Unauthorized(new { Message = "Invalid username or password....!" });
            }
            //if (token == null)
            //{
            //    return Unauthorized(new { Message = "Invalid username or password." });
            //}

            //return Ok(new { Token = token, Message = "Login successful." });

          
        }

    }
}
