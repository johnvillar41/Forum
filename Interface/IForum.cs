using Forum.Data.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Interface
{
    public interface IForum
    {
        Task<IEnumerable<ForumModel>> FetchAllForums();
        Task<IEnumerable<ForumModel>> FetchForumsByUser();        
    }
}
