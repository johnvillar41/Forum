using Forum.DataModels;
using Forum.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Repository
{
    public class ForumPostRepository : IForumPostRepository
    {
        private readonly IConfiguration _configuration;
        public ForumPostRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task AddNewForumPost(ForumPostModel forumPost)
        {
            using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ForumDBConnection"));
            await connection.OpenAsync();
            var queryString = "INSERT INTO ForumPosts(ForumId,PostId,UserId)VALUES(@forumId,@postId,@userId)";
            using SqlCommand command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@forumId", forumPost.ForumId);
            command.Parameters.AddWithValue("@postId", forumPost.PostId);
            command.Parameters.AddWithValue("@userId", forumPost.UserId);
            await command.ExecuteNonQueryAsync();
        }
    }
}
