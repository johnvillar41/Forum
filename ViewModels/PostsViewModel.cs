using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.ViewModels
{
    public class PostsViewModel
    {
        public IEnumerable<PostViewModel> Posts { get; set; }
        public int ForumId { get; set; }
    }
}
