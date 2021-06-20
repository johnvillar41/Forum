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
        private readonly IPostRepository _postRepository;
        private readonly IForumPostRepository _forumPostRepository;
        private readonly ILoginRepository _loginRepository;
        private readonly IReplyRepository _replyRepository;
        public PostsController(IPostRepository postRepository, IForumPostRepository forumPostRepository, ILoginRepository loginRepository, IReplyRepository replyRepository)
        {
            _postRepository = postRepository;
            _forumPostRepository = forumPostRepository;
            _loginRepository = loginRepository;
            _replyRepository = replyRepository;
        }
        public IActionResult Index(int id)
        {
            var isCookieValidated = ValidateCookie();
            if (!isCookieValidated)
            {
                return RedirectToAction("Index", "Login");
            }
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
            var isCookieValidated = ValidateCookie();
            if (!isCookieValidated)
            {
                return RedirectToAction("Index", "Login");
            }
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
        public async Task<IActionResult> Comment(int id)
        {
            var isCookieValidated = ValidateCookie();
            if (!isCookieValidated)
            {
                return RedirectToAction("Index", "Login");
            }
            var username = Request.Cookies["username"];
            var user = await _loginRepository.FetchLoggedInUser(username);
            var replyViewModel = new ReplyViewModel
            {
                PostId = id,
                User = user
            };
            return View(replyViewModel);
        }
        public async Task<IActionResult> SubmitComment(ReplyViewModel replyViewModel)
        {
            var isCookieValidated = ValidateCookie();
            if (!isCookieValidated)
            {
                return RedirectToAction("Index", "Login");
            }
            replyViewModel.Reply.DateCreated = DateTime.Now;
            await _replyRepository.CreateReply(replyViewModel);
            return RedirectToAction("Index","Forum");
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
