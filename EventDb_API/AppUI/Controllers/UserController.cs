using AppUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;

namespace AppUI.Controllers
{
    [Route("UserInfo")]
    public class UserInfoController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UserInfoController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [NonAction]
        private HttpClient GetClient()
        {
            return _httpClientFactory.CreateClient("EventDb_API");
        }

       
        [Route("LoginPage", Name = "LoginPage")]
        public IActionResult LoginPage()
        {
            return View("~/Views/UserInfo/LoginPage.cshtml");
        }

        [HttpPost]
        [Route("ValidateUser", Name = "ValidateUser")]
        public async Task<IActionResult> LoginPage(LoginDTO loginDto)
        {
            var client = GetClient();
            var response = await client.PostAsJsonAsync("api/v1.0/Auth/Login", loginDto);

            if (response.IsSuccessStatusCode)
            {
                var loginResult = await response.Content.ReadFromJsonAsync<LoginResponse>();
                HttpContext.Session.SetString("jwttoken", loginResult.Token);
                HttpContext.Session.SetString("userRole", loginResult.Role);
                HttpContext.Session.SetString("userEmail", loginResult.EmailId);
                HttpContext.Session.SetString("userName", loginResult.UserName);

                return RedirectToRoute("EventList");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid email or password");
                return View(loginDto);
            }
        }
    }
}
