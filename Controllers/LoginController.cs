using Forum.DataModels;
using Forum.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginRepository _loginRepository;
        public LoginController(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserModel loginUser)
        {
            if (string.IsNullOrWhiteSpace(loginUser.Username) || string.IsNullOrWhiteSpace(loginUser.Password)) return RedirectToAction("Index");
            else
            {
                var isLoginValid = await _loginRepository.CheckIfLoggedInUserExist(loginUser);
                if (isLoginValid)
                {
                    var isAdmin = await _loginRepository.CheckIfUserIdAdmin(loginUser.Username);
                    if (isAdmin.Equals(UserType.Admin))
                    {                       
                        AppendCookies("UserInfo", nameof(UserType.Admin));
                        AppendCookies("Username", loginUser.Username);
                    }                        
                    if (isAdmin.Equals(UserType.User))
                    {
                        AppendCookies("UserInfo", nameof(UserType.User));
                        AppendCookies("Username", loginUser.Username);
                    }                      

                    return RedirectToAction("Index", "Forum");
                }
            }
            return RedirectToAction("Index");
        }
        public IActionResult Logout(string username)
        {
            HttpContext.Response.Cookies.Delete(username);
            return RedirectToAction("Login");
        }
        private void AppendCookies(string key,string value)
        {
            CookieOptions options = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(6)
            };
            Response.Cookies.Append(key, value, options);
        }
    }
}
