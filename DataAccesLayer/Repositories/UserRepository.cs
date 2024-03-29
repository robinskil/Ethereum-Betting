﻿using System;
using System.Collections.Generic;
using System.Text;
using DataAccesLayer.EF;
using DomainLayer.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccesLayer.Repositories
{
    public sealed class UserRepository : Repository, IUserRepository
    {
        public UserRepository(EthereumBettingContext context) : base(context)
        {
        }

        public bool ChangePassword(User user)
        {
            Context.Users.Update(user);
            Context.SaveChanges();
            return true;
        }

        public bool CheckIfNameExist(string name)
        {
            return Context.Users.Any(u => u.GeneratedName == name);
        }

        public bool CheckIfAddressExists(string address) 
        {
            return Context.Users.Any(u => u.UserAddress == address);
        }

        public string GetPassword(string address) 
        {
            User user = GetUser(address);
            return user.Password;
        }

        public bool CreateUser(User user)
        {
            // throw new NotImplementedException();
            Context.Add(user);
            Context.SaveChanges();
            return true;
        }

        public bool DeleteUser(User user)
        {
            Context.Users.Remove(user);
            Context.SaveChanges();
            return true;
        }

        public IList<User> GetFriends(string address)
        {
            throw new NotImplementedException();
        }

        public User GetUser(string address)
        {
            return Context.Users.FirstOrDefault(u => u.UserAddress == address);
        }

        public IList<User> GetUserSuggestion(string user)
        {
            throw new NotImplementedException();
        }
    }
}
