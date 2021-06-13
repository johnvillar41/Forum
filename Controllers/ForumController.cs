using Forum.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Forum.Controllers
{
    public class ForumController : Controller
    {
        private readonly IForum _forumRepository;
        private readonly IPost _postRepository;
        public ForumController(IForum forumRepository, IPost postRepository)
        {
            _forumRepository = forumRepository;
            _postRepository = postRepository;
        }
        public async Task<IActionResult> Index()
        {
            var forums = await _forumRepository.FetchAllForums();           
            return View(forums);
        }
        public async Task<IActionResult> Forum(int id)
        {
            var posts = await _postRepository.FetchAllPostsInForum(id);
            return View("Posts",posts);
        }
    }
}
