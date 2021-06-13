using Forum.DataModels;
using Forum.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Forum.Repository
{
    public class ForumRepository : IForum
    {
        private readonly IConfiguration _configuration;
        public ForumRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task CreateForm(ForumModel newForum)
        {
            using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ForumDBConnection"));
            await connection.OpenAsync();
            var queryString = "INSERT INTO ForumTable(Title,Description,DateCreated,ImageUrl) VALUES(@title,@description,@date,@imageUrl)";
            using SqlCommand command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@title", newForum.Title);
            command.Parameters.AddWithValue("@description", newForum.Description);
            command.Parameters.AddWithValue("@date", newForum.DateCreated);
            command.Parameters.AddWithValue("@imageUrl", newForum.ImageUrl);
            await command.ExecuteNonQueryAsync();
        }
        public async Task DeleteForum(int forumId)
        {
            using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ForumDBConnection"));
            await connection.OpenAsync();
            var queryString = "DELETE FROM ForumTable WHERE ForumID = @forumID";
            using SqlCommand command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@forumID", forumId);
            await command.ExecuteNonQueryAsync();
        }
        public async Task<IEnumerable<ForumModel>> FetchAllForums()
        {
            List<ForumModel> forums = new List<ForumModel>();
            using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ForumDBConnection"));
            await connection.OpenAsync();
            string queryString = "SELECT * FROM ForumTable";
            using SqlCommand command = new SqlCommand(queryString, connection);
            using SqlDataReader reader = await command.ExecuteReaderAsync();
            while(await reader.ReadAsync())
            {
                forums.Add(new ForumModel
                {
                    Id = int.Parse(reader["ForumID"].ToString()),
                    Title = reader["Title"].ToString(),
                    Description = reader["Description"].ToString(),
                    DateCreated = DateTime.Parse(reader["DateCreated"].ToString()),
                    ImageUrl = reader["ImageUrl"].ToString()
                });
            }
            return forums;
        }        
    }
}
