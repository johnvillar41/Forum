using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.DataModels
{
    public class ReplyModel
    {
        public int ReplyID { get; set; }
        public DateTime DateCreated { get; set; }
        public string ReplyContent { get; set; }
        public UserModel User { get; set; }
    }
}
