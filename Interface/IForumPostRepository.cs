using Forum.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Interface
{
    public interface IForumPostRepository
    {
        Task AddNewForumPost(ForumPostModel forumPost);
    }
}
