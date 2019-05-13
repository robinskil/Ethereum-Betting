using DomainLayer.Models;
using InteractorLayer.FriendChatManager;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InteractorLayer.AuthenticationService
{
    public interface IFriendService
    {
        Task<IEnumerable<FriendModel>> GetOnlineFriends(string address);
        Task ChangeStatus(string address , UserStatus status);
        Task<bool> IsFriend(string address , string addressFriend);
    }
}
