using Forum.Data.Models;
using Forum.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Interface
{
    public interface IPost
    {
        Task<IEnumerable<PostViewModel>> FetchAllPostsInForum(int forumId);
        Task DeletePost(int postId);
        Task ModifyPost(int postId, bool isPostOwnedByUserLoggedIn);
        Task CreateNewPostInForum(PostModel newPost, int forumId);
    }
}
