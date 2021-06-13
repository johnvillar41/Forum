using Forum.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Forum.Controllers
{
    public class ForumController : Controller
    {
        private readonly IForum _repository;
        public ForumController(IForum repository)
        {
            _repository = repository;
        }
        public async Task<IActionResult> Index()
        {
            var forums = await _repository.FetchAllForums();           
            return View(forums);
        }
    }
}
