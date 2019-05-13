using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccesLayer.Repositories;
using DomainLayer.Models;
using InteractorLayer.FriendChatManager;

namespace InteractorLayer.AuthenticationService
{
    public class FriendService : IFriendService
    {
        //public IActiveClients ActiveClients { get; }

        //public FriendService(IActiveClients activeClients)
        //{
        //    ActiveClients = activeClients;
        //}

        //public async Task<IEnumerable<FriendModel>> GetOnlineFriends(string address)
        //{
        //    return await Task.Run(() =>
        //    {
        //        List<FriendModel> friends = new List<FriendModel>();
        //        IList<string> addressesFriends = ActiveClients.OnlineUsers[address].Friends;
        //        foreach (string addressFriend in addressesFriends)
        //        {
        //            UserOnlineModel friend = ActiveClients.OnlineUsers.GetValueOrDefault(addressFriend);
        //            if (friend != null) friends.Add(new FriendModel() { Address = friend.Address, Name = friend.Name });
        //        }
        //        return friends;
        //    });
        //}

        //public async Task<bool> IsFriend(string address, string addressFriend)
        //{
        //    return ActiveClients.OnlineUsers[address].Friends.Contains(addressFriend);
        //}

        //public async Task ChangeStatus(string address,UserStatus status)
        //{
        //    ActiveClients.ChangeStatus(address, status);
        //}
        public Task ChangeStatus(string address, UserStatus status)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<FriendModel>> GetOnlineFriends(string address)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsFriend(string address, string addressFriend)
        {
            throw new NotImplementedException();
        }
    }
}
