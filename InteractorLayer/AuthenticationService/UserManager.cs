using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InteractorLayer.AuthenticationService
{
    public class UserManager : IActiveClients
    {
        private static readonly Dictionary<string, UserOnlineModel> Online = new Dictionary<string, UserOnlineModel>();
        public IReadOnlyDictionary<string, UserOnlineModel> OnlineUsers => Online;

        public bool ChangeStatus(string address,UserStatus status)
        {
            if (!Online.ContainsKey(address)) return false;
            Online[address].UserStatus = status;
            return true;
        }

        protected bool AddUserToOnline(User u)
        {
            if (!Online.ContainsKey(u.UserAddress))
            {
                throw new NotImplementedException("Friends is still null");
                Online.Add(u.UserAddress,
                new UserOnlineModel() { Address = u.UserAddress, Name = u.GeneratedName, Friends = null, UserStatus = UserStatus.Online });
                return true;
            }
            return false;
        }

        protected bool RemoveUserFromOnline(string address)
        {
            if (!Online.ContainsKey(address)) return false;
            Online.Remove(address);
            return true;
        }
    }
}
