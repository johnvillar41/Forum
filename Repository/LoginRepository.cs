using Forum.DataModels;
using Forum.Interface;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Forum.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly IConfiguration _configuration;
        public LoginRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<bool> CheckIfLoggedInUserExist(UserModel user)
        {
            using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ForumDBConnection"));
            await connection.OpenAsync();
            var queryString = "SELECT * FROM UserTable WHERE Username=@username AND Password=@password";
            using SqlCommand command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@username", user.Username);
            command.Parameters.AddWithValue("@password", user.Password);
            using SqlDataReader reader = await command.ExecuteReaderAsync();
            if(await reader.ReadAsync())
            {
                return true;
            }
            return false;
        }       
        public async Task<UserType?> CheckIfUserIdAdmin(string username)
        {
            using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ForumDBConnection"));
            await connection.OpenAsync();
            var queryString = "SELECT UserType FROM UserTable WHERE Username=@username ";
            using SqlCommand command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@username", username);
            using SqlDataReader reader = await command.ExecuteReaderAsync();
            if(await reader.ReadAsync())
            {
                var userType = reader["UserType"].ToString();
                userType.Replace(" ", string.Empty);
                switch (userType)
                {
                    case nameof(UserType.Admin):
                        return UserType.Admin;
                    case nameof(UserType.User):
                        return UserType.User;
                }                
            }
            return null;
        }
        public async Task<UserModel> FetchLoggedInUser(string username)
        {
            using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ForumDBConnection"));
            await connection.OpenAsync();
            var queryString = "SELECT * FROM UserTable WHERE Username=@username";
            using SqlCommand command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@username", username);
            using SqlDataReader reader = await command.ExecuteReaderAsync();
            if(await reader.ReadAsync())
            {
                return new UserModel
                {
                    Id = int.Parse(reader["UserId"].ToString()),
                    Username = reader["Username"].ToString(),
                    Fullname = reader["Fullname"].ToString(),
                    ImageUrl = reader["ImageUrl"].ToString()
                };
            }
            return null;
        }
    }
}
