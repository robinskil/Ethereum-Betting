using DataAccesLayer.EF;
using InteractorLayer.AuthenticationService;
using InteractorLayer.FriendChatManager;
using InteractorLayer.FriendInteractor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Ethereum_Betting.Chatting
{
    public interface IFriendChat
    {
        Task ChangeStatus(UserStatus status);
        Task SendMessage(string message, string addressFriend);
        Task AddFriend(string address, string usernameFriend);
        Task DeleteFriend(string address, string usernameFriend);
    }

    [Authorize]
    public class FriendChat : Hub, IFriendChat
    {
        IClientManager ClientManager { get; }
        public FriendChat(EthereumBettingContext context)
        {
            //ClientManager = new ActiveClientManager(new FriendInteractor(context));
        }
        public override Task OnConnectedAsync()
        {
            if (ClientManager.Connect(ClaimsToModel(Context.User.Claims)))
            {
                return base.OnConnectedAsync();
            }
            throw new Exception("Cannot connect");
        }
        public override Task OnDisconnectedAsync(Exception exception)
        {
            ClientManager.Disconnect(Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }

        public async Task ChangeStatus(UserStatus status)
        {
            await ClientManager.ChangeStatus(Context.ConnectionId, status);
            IEnumerable<FriendModel> friends = ClientManager.GetFriends(Context.ConnectionId);
            await Clients.Clients(friends.Select(f => f.Address).ToList()).SendAsync("StatusChange", Context.ConnectionId);
        }

        public async Task GetFriends()
        {
            IEnumerable<FriendModel> friends = ClientManager.GetFriends(Context.ConnectionId);
            await Clients.User(Context.ConnectionId).SendAsync("ReceiveFriendStatuses", friends);
        }

        public async Task SendMessage(string message, string addressFriend)
        {
            if (ClientManager.isFriend(Context.ConnectionId)) ;
            await Clients.Client(addressFriend).SendAsync("ReceiveMessage", message, ClientManager.GetClientName(Context.ConnectionId));
        }

        public async Task AddFriend(string address, string usernameFriend)
        {
            await ClientManager.AddFriend(address, usernameFriend);
        }

        public async Task DeleteFriend(string address, string usernameFriend)
        {
            await ClientManager.RemoveFriend(address, usernameFriend);
        }

        /// <summary>
        /// When you log on you will always have the status online
        /// </summary>
        /// <param name="claims"></param>
        /// <returns></returns>
        private UserOnlineModel ClaimsToModel(IEnumerable<Claim> claims)
        {
            UserOnlineModel model = new UserOnlineModel();
            foreach (Claim claim in claims)
            {
                if (claim.Type == ClaimTypes.Sid) model.Address = claim.Value;
                else if (claim.Type == "Nickname") model.Name = claim.Value;
            }
            model.UserStatus = UserStatus.Online;
            return model;
        }
    }
}
