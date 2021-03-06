namespace Forum.DataModels
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string ImageUrl { get; set; }
        public UserType UserType { get; set; }
    }
}
