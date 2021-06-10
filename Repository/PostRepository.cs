using Forum.Data.Models;
using Forum.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Repository
{
    public class PostRepository : IPost
    {
        public Task CreateNewPostInForum(PostModel newPost, int forumId)
        {
            throw new System.NotImplementedException();
        }

        public Task DeletePost(int postId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<PostModel>> FetchAllPostsInForum(int forumId)
        {
            throw new System.NotImplementedException();
        }

        public Task ModifyPost(int postId, bool isPostOwnedByUserLoggedIn)
        {
            throw new System.NotImplementedException();
        }
    }
}
