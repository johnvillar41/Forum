﻿using Forum.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Interface
{
    public interface IUser
    {
        Task<IEnumerable<UserModel>> FetchAllUsers();
        Task ModifyUser(int userId, UserModel updatedUser);
        Task RegisterUser(UserModel newUser);
    }
}