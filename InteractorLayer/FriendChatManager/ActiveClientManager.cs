using InteractorLayer.AuthenticationService;
using InteractorLayer.FriendInteractor;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractorLayer.FriendChatManager
{
    public class ActiveClientManager : IClientManager
    {
        ConcurrentDictionary<string,UserOnlineModel> Clients { get; }
        public IReadOnlyDictionary<string, UserOnlineModel> ActiveClients => Clients;
        IFriendInteractor FriendInteractor { get; }
        public ActiveClientManager(IFriendInteractor friendInteractor)
        {
            FriendInteractor = friendInteractor;
        }
        public async Task AddFriend(string address , string usernameFriend)
        {
            throw new NotImplementedException();
            await FriendInteractor.AddFriendAsync(null, null);
        }

        public async Task ChangeStatus(string address , UserStatus status)
        {
            await Task.Run(() => {
                if (Clients.ContainsKey(address))
                {
                    UserOnlineModel user = Clients[address];
                    user.UserStatus = status;
                }
                else throw new Exception("User doesnt exist on our server");
            });
        }

        public async Task RemoveFriend(string address, string usernameFriend)
        {
            throw new NotImplementedException();
            await FriendInteractor.RemoveFriendAsync(null,null);
        }

        public bool Connect(UserOnlineModel onlineModel)
        {
            return Clients.TryAdd(onlineModel.Address,onlineModel);
            //throw new NotImplementedException();
        }

        public bool Disconnect(string address)
        {
            return Clients.TryRemove(address,out var disposableObject);
        }

        public string GetClientName(string address)
        {
            return Clients[address].Name;
        }

        public IEnumerable<FriendModel> GetFriends(string address)
        {
            throw new NotImplementedException();
        }

        public bool isFriend(string connectionId)
        {
            return Clients[connectionId].Friends.Contains(connectionId);
        }
    }
}
