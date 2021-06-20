using Forum.DataModels;
using Forum.Interface;
using Forum.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Forum.Controllers
{
    public class ForumController : Controller
    {
        private readonly IForumRepository _forumRepository;
        private readonly IPostRepository _postRepository;

        private readonly ILoginRepository _loginRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ForumController(IForumRepository forumRepository, IPostRepository postRepository, IWebHostEnvironment webHostEnvironment, ILoginRepository loginRepository)
        {
            _forumRepository = forumRepository;
            _postRepository = postRepository;
            _webHostEnvironment = webHostEnvironment;
            _loginRepository = loginRepository;
        }
        public async Task<IActionResult> Index()
        {
            var isCookieValidated = ValidateCookie();
            if (!isCookieValidated)
            {
                return RedirectToAction("Index", "Login");
            }
            var forums = await _forumRepository.FetchAllForums();
            return View(forums);
        }
        public async Task<IActionResult> Posts(int id)
        {
            var isCookieValidated = ValidateCookie();
            if (!isCookieValidated)
            {
                return RedirectToAction("Index", "Login");
            }
            var posts = await _postRepository.FetchAllPostsInForum(id);
            var forum = await _forumRepository.FetchForum(id);
            PostsViewModel postsViewModel = new PostsViewModel
            {
                Posts = posts,
                ForumId = id,
                Forum = forum
            };
            return View(postsViewModel);
        }
        public IActionResult CreateForum()
        {
            var isCookieValidated = ValidateCookie();
            if (!isCookieValidated)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
        public async Task<IActionResult> SubmitForum(ForumModel newForum)
        {
            var isCookieValidated = ValidateCookie();
            if (!isCookieValidated)
            {
                return RedirectToAction("Index", "Login");
            }
            if (newForum != null)
            {
                newForum.DateCreated = DateTime.Now;
                newForum.ImageUrl = $"/images/{newForum.FileImage.FileName}";
                SaveImage(newForum.FileImage);
                await _forumRepository.CreateForum(newForum);
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> RemoveForum(int id)
        {
            var isCookieValidated = ValidateCookie();
            if (!isCookieValidated)
            {
                return RedirectToAction("Index", "Login");
            }
            await _forumRepository.DeleteForum(id);
            return RedirectToAction("Index");
        }
        private async void SaveImage(IFormFile file)
        {
            var fileExtension = Path.GetExtension(file.FileName);
            if (fileExtension.Equals(".JPG", StringComparison.CurrentCultureIgnoreCase) || fileExtension.Equals(".PNG", StringComparison.CurrentCultureIgnoreCase))
            {
                var saveImage = Path.Combine(_webHostEnvironment.WebRootPath, "images", file.FileName);
                var stream = new FileStream(saveImage, FileMode.Create);
                await file.CopyToAsync(stream);
            }
        }
        private bool ValidateCookie()
        {
            var cookieUsername = HttpContext.Request.Cookies["Username"];
            var cookieUserType = HttpContext.Request.Cookies["UserInfo"];
            if (cookieUsername == null || cookieUserType == null ||
                HttpContext.Request.Cookies.ContainsKey(cookieUsername) ||
                HttpContext.Request.Cookies.ContainsKey(cookieUserType))
            {
                return false;               
            }
            return true;
        }
    }
}
