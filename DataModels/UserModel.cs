﻿namespace Forum.Data.Models
{
    public class UserModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string ImageUrl { get; set; }
        public UserType MyProperty { get; set; }
    }
}
