using System;
using System.Collections.Generic;
using System.Text;
using DataAccesLayer.EF;
using DomainLayer.Models;
using System.Linq;

namespace DataAccesLayer.Repositories
{
    public sealed class UserRepository : Repository, IUserRepository
    {
        public UserRepository(EthereumBettingContext context) : base(context)
        {
        }

        public bool ChangePassword(string userId, string newPassword)
        {
            
        }

        public bool CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUser(string userId)
        {
            throw new NotImplementedException();
        }

        public IList<User> GetFriends(string userId)
        {
            throw new NotImplementedException();
        }

        public User GetUser(string address)
        {
            return Context.Users.FirstOrDefault(u => u.Address == address);
        }

        public IList<User> GetUserSuggestion(string user)
        {
            throw new NotImplementedException();
            return null;
        }
    }
}
