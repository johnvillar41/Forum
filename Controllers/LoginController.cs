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
                    if (isAdmin.Equals(nameof(UserType.Administrator)))
                        Cookie.SingleInstance.AppendCookie(loginUser.Username, nameof(UserType.Administrator));
                    if (isAdmin.Equals(nameof(UserType.User)))
                        Cookie.SingleInstance.AppendCookie(loginUser.Username, nameof(UserType.User));

                    return RedirectToAction("Index", "Forum");
                }
            }
            return RedirectToAction("Index");
        }
        public IActionResult Logout(string username)
        {
            Cookie.SingleInstance.RemoveCookie(username);
            return RedirectToAction("Login");
        }
    }
}
