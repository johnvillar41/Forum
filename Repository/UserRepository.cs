using Forum.DataModels;
using Forum.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Repository
{
    public class UserRepository : IUser
    {
        public Task<IEnumerable<UserModel>> FetchAllUsers()
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
