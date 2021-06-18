using Forum.DataModels;
using Forum.Interface;
using Forum.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Forum.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPost _postRepository;
        private readonly IForumPost _forumPostRepository;
        private readonly ILogin _loginRepository;
        private readonly IReply _replyRepository;
        public PostsController(IPost postRepository, IForumPost forumPostRepository, ILogin loginRepository, IReply replyRepository)
        {
            _postRepository = postRepository;
            _forumPostRepository = forumPostRepository;
            _loginRepository = loginRepository;
            _replyRepository = replyRepository;
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
                var usernameLoggedIn = Request.Cookies["username"];
                var userLoggedIn = await _loginRepository.FetchLoggedInUser(usernameLoggedIn);
                var forumPost = new ForumPostModel
                {
                    PostId = postId,
                    ForumId = newPost.ForumId,
                    UserId = userLoggedIn.Id
                };
                await _forumPostRepository.AddNewForumPost(forumPost);
                return RedirectToAction("Index","Forum");
            }
            return View();
        }
        public async Task<IActionResult> SubmitComment(ReplyViewModel replyViewModel)
        {
            replyViewModel.Reply.DateCreated = DateTime.Now;
            await _replyRepository.CreateReply(replyViewModel);
            return RedirectToAction("Index","Forum");
        }
    }
}
