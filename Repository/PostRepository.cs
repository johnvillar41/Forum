using Forum.DataModels;
using Forum.Interface;
using Forum.ViewModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Forum.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IReplyRepository _replyRepository;
        public PostRepository(IConfiguration configuration,IReplyRepository replyRepository)
        {
            _replyRepository = replyRepository;
            _configuration = configuration;
        }
        public async Task<int> CreateNewPost(PostCreateViewModel newPost)
        {
            using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ForumDBConnection"));
            await connection.OpenAsync();
            var queryString = "INSERT INTO PostTable(Title,PostContent,DateCreated,PostType)VALUES(@title,@postContent,@date,@postType);" +
                " SELECT PostId AS LastID FROM PostTable WHERE PostId = @@Identity;";
            using SqlCommand command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@title", newPost.Post.Title);
            command.Parameters.AddWithValue("@postContent", newPost.Post.Content);
            command.Parameters.AddWithValue("@date", DateTime.Now);
            command.Parameters.AddWithValue("@postType", newPost.Post.PostType.ToString());
            using SqlDataReader reader = await command.ExecuteReaderAsync();
            if(await reader.ReadAsync())
            {
                return int.Parse(reader["LastID"].ToString());
            }
            return -1;
        }
        public async Task DeletePost(int postId)
        {
            using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ForumDBConnection"));
            await connection.OpenAsync();
            var queryString = "DELETE FROM PostTable WHERE PostId = @postId";
            using SqlCommand command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@postId", postId);
            await command.ExecuteNonQueryAsync();
        }
        public async Task<IEnumerable<PostViewModel>> FetchAllPostsInForum(int forumId)
        {
            List<PostViewModel> posts = new List<PostViewModel>();
            using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ForumDBConnection"));
            await connection.OpenAsync();
            var queryString = "SELECT UserTable.Fullname,UserTable.Username,UserTable.UserType,PostTable.PostId,PostTable.Title,PostTable.PostContent,PostTable.DateCreated FROM UserTable INNER JOIN ForumPosts ON UserTable.UserId = ForumPosts.UserId INNER JOIN PostTable ON PostTable.PostId = ForumPosts.PostId WHERE ForumPosts.ForumId = @forumID";
            using SqlCommand command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@forumID", forumId);
            using SqlDataReader reader = await command.ExecuteReaderAsync();            
            while (await reader.ReadAsync())
            {
                var post = new PostViewModel
                {
                    Username = reader["Username"].ToString(),
                    Fullname = reader["Fullname"].ToString(),
                    Post = new PostModel
                    {
                        Id = int.Parse(reader["PostId"].ToString()),
                        Title = reader["Title"].ToString(),
                        Content = reader["PostContent"].ToString(),
                        DateCreated = DateTime.Parse(reader["DateCreated"].ToString()),
                        PostReplies = await _replyRepository.FetchAllRepliesInAPost(int.Parse(reader["PostId"].ToString()))
                    },                    
                };
                if (reader["UserType"].ToString().Equals(nameof(UserType.Admin)))
                    post.UserType = UserType.Admin;
                if (reader["UserType"].ToString().Equals(nameof(UserType.User)))
                    post.UserType = UserType.User;                
                posts.Add(post);
            }
            return posts;
        }
        public async Task ModifyPost(PostModel post, bool isPostOwnedByUserLoggedIn)
        {
            using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ForumDBConnection"));
            await connection.OpenAsync();
            var queryString = "UPDATE PostTable SET Title=@title, PostContent = @content WHERE PostTable.PostId = @postID";
            using SqlCommand command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@title", post.Title);
            command.Parameters.AddWithValue("@content", post.Content);
            command.Parameters.AddWithValue("@postID", post.Id);
            await command.ExecuteNonQueryAsync();
        }        
    }
}
