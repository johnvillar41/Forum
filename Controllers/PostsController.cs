using Forum.DataModels;
using Forum.Interface;
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
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreatePost(PostModel newPost, int forumId)
        {
            if (newPost != null)
            {
                var postId = await _postRepository.CreateNewPost(newPost);
                var forumPost = new ForumPostModel
                {
                    PostId = postId,
                    ForumId = 1,//TODO HARD CODED ID
                    UserId = 1 //TODO HARD CODED ID
                };
                await _forumPostRepository.AddNewForumPost(forumPost);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
