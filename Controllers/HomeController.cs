using Forum.DataModels;
using Forum.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace Forum.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var post = new PostModel
            {
                Id = 1,
                Content = "Contents",
                DateCreated = DateTime.Now,
                PostType = PostType.Post,
                Title = "Title"
            };
            return View(post);
        }

        public IActionResult Privacy()
        {
            return View();
        }       
    }
}
