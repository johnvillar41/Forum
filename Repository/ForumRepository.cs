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
        public Task CreateForm(ForumModel newForum)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteForum(int forumId)
        {
            throw new System.NotImplementedException();
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

        public Task<IEnumerable<ForumModel>> FetchForumsByUser()
        {
            throw new System.NotImplementedException();
        }
    }
}
