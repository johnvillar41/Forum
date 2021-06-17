using Forum.DataModels;
using Forum.Interface;
using Forum.ViewModels;
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
        private readonly IForum _forumRepository;
        private readonly IPost _postRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ForumController(IForum forumRepository, IPost postRepository, IWebHostEnvironment webHostEnvironment)
        {
            _forumRepository = forumRepository;
            _postRepository = postRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            var forums = await _forumRepository.FetchAllForums();
            return View(forums);
        }
        public async Task<IActionResult> Posts(int id)
        {
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
            return View();
        }
        public async Task<IActionResult> SubmitForum(ForumModel newForum)
        {
            if (newForum != null)
            {
                newForum.DateCreated = DateTime.Now;
                newForum.ImageUrl = $"images/{newForum.FileImage.FileName}";
                SaveImage(newForum.FileImage);
                await _forumRepository.CreateForum(newForum);
                return RedirectToAction("Index");
            }
            return View();
        }
        private async void SaveImage(IFormFile file)
        {
            var fileExtension = Path.GetExtension(file.FileName);
            if (fileExtension.Equals(".JPG") || fileExtension.Equals(".PNG") || fileExtension.Equals(".png") || fileExtension.Equals(".jpg"))
            {
                var saveImage = Path.Combine(_webHostEnvironment.WebRootPath, "images", file.FileName);
                var stream = new FileStream(saveImage, FileMode.Create);
                await file.CopyToAsync(stream);
            }
        }
    }
}
