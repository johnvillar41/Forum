﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Forum.Data.Models
{
    public class ForumModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public string ImageUrl { get; set; }
        public IEnumerable<PostModel> Posts { get; set; }
        public UserModel User { get; set; }
    }
}
