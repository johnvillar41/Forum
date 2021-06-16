using Forum.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Interface
{
    public interface IForumPost
    {
        Task AddNewForumPost(ForumPostModel forumPost);
    }
}
