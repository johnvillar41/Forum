using Forum.DataModels;

namespace Forum.ViewModels
{
    public class PostViewModel
    {
        public string Username { get; set; }
        public string Fullname { get; set; }
        public int ForumId { get; set; }
        public UserType UserType { get; set; }
        public PostModel Post { get; set; }
    }
}
