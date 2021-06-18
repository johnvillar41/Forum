using Forum.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Interface
{
    public interface ILoginRepository
    {
        Task<bool> CheckIfLoggedInUserExist(UserModel user);
        Task<UserType?> CheckIfUserIdAdmin(string username);
        Task<UserModel> FetchLoggedInUser(string username);
    }
}
