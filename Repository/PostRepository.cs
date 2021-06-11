using Forum.Data.Models;
using Forum.Interface;
using Forum.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Forum.Repository
{
    public class PostRepository : IPost
    {
        public async Task CreateNewPostInForum(PostModel newPost, int forumId)
        {
            using SqlConnection connection = new SqlConnection(ConnectionString.CONNECTION_STRING);
            await connection.OpenAsync();
            var queryString = "INSERT INTO ForumTable(Title,PostContent,DateCreated,PostType)" +
                "VALUES(@title,@postContent,@date,@postType)";
            using SqlCommand command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@title", newPost.Title);
            command.Parameters.AddWithValue("@postContent", newPost.Content);
            command.Parameters.AddWithValue("@date", newPost.DateCreated);
            command.Parameters.AddWithValue("@postType", newPost.PostType.ToString());
            await command.ExecuteNonQueryAsync();
        }
        public async Task DeletePost(int postId)
        {
            using SqlConnection connection = new SqlConnection(ConnectionString.CONNECTION_STRING);
            await connection.OpenAsync();
            var queryString = "DELETE FROM PostTable WHERE PostId = @postId";
            using SqlCommand command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@postId", postId);
            await command.ExecuteNonQueryAsync();
        }

        public async Task<IEnumerable<PostViewModel>> FetchAllPostsInForum(int forumId)
        {
            List<PostViewModel> posts = new List<PostViewModel>();
            using SqlConnection connection = new SqlConnection(ConnectionString.CONNECTION_STRING);
            await connection.OpenAsync();
            var queryString = "SELECT UserTable.Fullname,UserTable.Username,UserTable.UserType,PostTable.PostId,PostTable.Title,PostTable.PostContent,PostTable.DateCreated FROM UserTable INNER JOIN ForumPosts ON UserTable.UserId = ForumPosts.UserId INNER JOIN PostTable ON PostTable.PostId = ForumPosts.PostId WHERE ForumPosts.ForumId = @forumID";
            using SqlCommand command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@forumID", forumId);
            using SqlDataReader reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                var post = new PostViewModel
                {
                    Username = reader["UserTable.Username"].ToString(),
                    Fullname = reader["UserTable.Fullname"].ToString(),
                    Post = new PostModel
                    {
                        Id = int.Parse(reader["PostTable.PostId"].ToString()),
                        Title = reader["PostTable.Title"].ToString(),
                        Content = reader["PostTable.PostContent"].ToString(),
                        DateCreated = DateTime.Parse(reader["PostTable.DateCreated"].ToString())
                    }
                };
                if (reader["UserTable.UserType"].ToString().Equals(nameof(UserType.Administrator)))
                    post.UserType = UserType.Administrator;
                if (reader["UserTable.UserType"].ToString().Equals(nameof(UserType.User)))
                    post.UserType = UserType.User;
                posts.Add(post);
            }
            return posts;
        }
        public Task ModifyPost(int postId, bool isPostOwnedByUserLoggedIn)
        {
            throw new System.NotImplementedException();
        }
    }
}
