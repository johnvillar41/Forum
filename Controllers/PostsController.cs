using Forum.DataModels;
using Forum.Interface;
using Forum.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPost _postRepository;
        private readonly IForumPost _forumPostRepository;
        public PostsController(IPost postRepository, IForumPost forumPostRepository)
        {
            _postRepository = postRepository;
            _forumPostRepository = forumPostRepository;
        }
        public IActionResult Index(int id)
        {                       
            var postCreateViewModel = new PostCreateViewModel
            {
                ForumId = id,
                User = null                
            };
            return View(postCreateViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePost(PostCreateViewModel newPost)
        {
            if (newPost != null)
            {
                var postId = await _postRepository.CreateNewPost(newPost);
                var forumPost = new ForumPostModel
                {
                    PostId = postId,
                    ForumId = newPost.ForumId,
                    UserId = newPost.User.Id
                };
                await _forumPostRepository.AddNewForumPost(forumPost);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
