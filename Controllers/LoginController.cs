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
                    //var isAdmin = await _loginRepository.CheckIfUserIdAdmin(loginUser.Username);                    
                    SetCookie("username", loginUser.Username);                   
                    return RedirectToAction("Index","Forum");
                }
            }
            return RedirectToAction("Index");
        }
        public IActionResult Logout(string username)
        {
            RemoveCookie(username);
            return RedirectToAction("Login");
        }
        private void SetCookie(string key,string value)
        {
            CookieOptions option = new CookieOptions();           
            Response.Cookies.Append(key, value, option);
        }
        private void RemoveCookie(string key)
        {
            Response.Cookies.Delete(key);
        }
    }
}
