using Forum.DataModels;
using Forum.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Forum.Repository
{
    public class ReplyRepository : IReply
    {
        private readonly IConfiguration _configuration;
        private readonly IUser _userRepository;
        public ReplyRepository(IConfiguration configuration,IUser userRepository)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }
        public async Task CreateReply(ReplyModel newReply)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteReply(int replyID)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ReplyModel>> FetchAllRepliesInAPost(int postID)
        {
            List<ReplyModel> replies = new List<ReplyModel>();
            using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ForumDBConnection"));
            var queryString = "SELECT * FROM ReplyTable WHERE PostID = @postID";
            using SqlCommand command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@postID", postID);
            using SqlDataReader reader = await command.ExecuteReaderAsync();
            while(await reader.ReadAsync())
            {
                replies.Add(
                        new ReplyModel
                        {
                            ReplyID = int.Parse(reader["ReplyID"].ToString()),
                            DateCreated = DateTime.Parse(reader["DateCreated"].ToString()),
                            ReplyContent = reader["ReplyContent"].ToString(),
                            User = await _userRepository.FetchUserInGivenPost(postID)
                        }
                    );
            }
            return replies;
        }
    }
}
