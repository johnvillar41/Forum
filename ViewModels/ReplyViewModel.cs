using Forum.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.ViewModels
{
    public class ReplyViewModel
    {
        public ReplyModel Reply { get; set; }
        public int PostId { get; set; }
        public UserModel User{ get; set; }
    }
}
