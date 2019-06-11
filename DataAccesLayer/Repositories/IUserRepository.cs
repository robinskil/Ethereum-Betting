using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccesLayer.Repositories
{
    /// <summary>
    /// This layer only makes changes to the Database or other data entity, No checking or functions that do not alter or retrieve data.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Creates a user 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        bool CreateUser(User user);
        User GetUser(string address);
        IList<User> GetUserSuggestion(string user);
        IList<User> GetFriends(string address);
        bool DeleteUser(string address);
        bool ChangePassword(string address, string newPassword);
        bool CheckIfNameExist(string name);
        bool CheckIfAddressExists(string address);
    }
}
