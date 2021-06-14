using Forum.DataModels;
using Forum.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogin _loginRepository;
        public LoginController(ILogin loginRepository)
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
            if (loginUser == null) return View();
            else
            {
                var isLoginValid = await _loginRepository.CheckIfLoggedInUserExist(loginUser);
                if (isLoginValid)
                {
                    return View("Home");
                }
            }
            return View();
        }
    }
}
