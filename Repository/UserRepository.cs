using Forum.DataModels;
using Forum.Interface;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Repository
{
    public class UserRepository : IUser
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
            throw new System.NotImplementedException();
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
