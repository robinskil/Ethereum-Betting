using InteractorLayer.AuthenticationService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InteractorLayer.FriendChatManager
{
    public interface IClientManager
    {
        IReadOnlyDictionary<string, UserOnlineModel> ActiveClients { get; }
        Task ChangeStatus(string address , UserStatus status);
        Task AddFriend(string address , string usernameFriend);
        Task RemoveFriend(string address , string usernameFriend);
        bool Connect(UserOnlineModel onlineModel);
        bool Disconnect(string address);
        string GetClientName(string address);
        IEnumerable<FriendModel> GetFriends(string address);
        bool isFriend(string connectionId);
    }
}
