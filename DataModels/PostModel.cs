using System;
using System.Collections;
using System.Collections.Generic;

namespace Forum.Data.Models
{
    public class PostModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public PostType PostType { get; set; }       
    }
}
