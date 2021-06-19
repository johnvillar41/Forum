﻿using Forum.DataModels;
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
                newForum.ImageUrl = $"/images/{newForum.FileImage.FileName}";
                SaveImage(newForum.FileImage);
                await _forumRepository.CreateForum(newForum);
                return RedirectToAction("Index");
            }
            return View();
        }        
        public async Task<IActionResult> RemoveForum(int id)
        {
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
    }
}
