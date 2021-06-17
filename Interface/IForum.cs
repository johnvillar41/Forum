using Forum.DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Interface
{
    public interface IForum
    {
        Task<IEnumerable<ForumModel>> FetchAllForums();       
        Task CreateForum(ForumModel newForum);
        Task DeleteForum(int forumId);
        Task<ForumModel> FetchForum(int forumId);
    }
}
