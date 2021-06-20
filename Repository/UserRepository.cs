using Forum.DataModels;
using Forum.Interface;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Forum.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;
        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Task<IEnumerable<UserModel>> FetchAllUsers()
        {
            throw new System.NotImplementedException();
        }

        public async Task<UserModel> FetchUserInGivenPost(int postId)
        {
            UserModel user = null;
            using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ForumDBConnection"));
            await connection.OpenAsync();
            var queryString = "SELECT Username,Fullname,UserType, UserTable.UserId,ImageUrl FROM UserTable INNER JOIN ForumPosts ON UserTable.UserId = ForumPosts.UserId INNER JOIN PostTable ON PostTable.PostId = ForumPosts.PostId WHERE ForumPosts.PostId = @postId";
            using SqlCommand command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@postId", postId);
            using SqlDataReader reader = await command.ExecuteReaderAsync();
            while(await reader.ReadAsync())
            {
                user = new UserModel
                {
                    Id = int.Parse(reader["UserId"].ToString()),
                    Username = reader["Username"].ToString(),
                    Fullname = reader["Fullname"].ToString(),
                    ImageUrl = reader["ImageUrl"].ToString()
                };
                var userType = reader["UserType"].ToString();
                if (userType.Equals(nameof(UserType.Admin)))                
                    user.UserType = UserType.Admin;
                if (userType.Equals(nameof(UserType.User)))
                    user.UserType = UserType.User;
            }
            return user;
        }

        public Task ModifyUser(int userId, UserModel updatedUser)
        {
            throw new System.NotImplementedException();
        }

        public Task RegisterUser(UserModel newUser)
        {
            throw new System.NotImplementedException();
        }
    }
}
