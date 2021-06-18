using Forum.DataModels;
using Forum.Interface;
using Forum.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Forum.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPost _postRepository;
        private readonly IForumPost _forumPostRepository;
        private readonly ILogin _loginRepository;
        public PostsController(IPost postRepository, IForumPost forumPostRepository, ILogin loginRepository)
        {
            _postRepository = postRepository;
            _forumPostRepository = forumPostRepository;
            _loginRepository = loginRepository;
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
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
