using Forum.DataModels;
using System.Collections.Generic;

namespace Forum.ViewModels
{
    public class PostCreateViewModel
    {
        public int ForumId { get; set; }
        public PostModel Post { get; set; }     
        public UserModel User { get; set; }
    }
}
