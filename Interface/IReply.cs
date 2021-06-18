using Forum.DataModels;
using Forum.ViewModels;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Interface
{
    public interface IReply
    {
        Task CreateReply(ReplyViewModel newReply);
        Task DeleteReply(int replyID);
        Task<IEnumerable<ReplyModel>> FetchAllRepliesInAPost(int postID);
    }
}
