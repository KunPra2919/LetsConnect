using LetsConnect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LetsConnect.Service.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
        User GetUserByUserId(int id);
         void SaveUserDetails(User objUser);
         void UpdateUserDetails(User objUser);
         void DeleteUserDetails(int id);
        User ValidateUser(string email,string password);
    }
}