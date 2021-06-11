using Forum.DataModels;
using Forum.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Repository
{
    public class ForumRepository : IForum
    {
        public Task CreateForm(ForumModel newForum)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteForum(int forumId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<ForumModel>> FetchAllForums()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<ForumModel>> FetchForumsByUser()
        {
            throw new System.NotImplementedException();
        }
    }
}
