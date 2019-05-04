using DataAccesLayer.EF;
using InteractorLayer;
using InteractorLayer.AuthenticationService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ethereum_Betting.Chatting
{
    public interface IFriendChat
    {
        Task SendFriendMessage(string friendAddress , string message);
        Task<IEnumerable<FriendModel>> GetFriends();
    }

    [Authorize]
    public class ChatHub : Hub, IFriendChat
    {
        IFriendService FriendService { get; }
        //DI context to define friendship
        public ChatHub() : base()
        {
            FriendService = new FriendService(new UserManager());
        }
        public async Task SendFriendMessage(string friendAddress, string message)
        {
            if (await FriendService.IsFriend(Context.UserIdentifier, friendAddress))
            {
                await Clients.User(friendAddress).SendAsync("ReceiveMessage", Context.UserIdentifier, message);
            }
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<FriendModel>> GetFriends()
        {
            return await FriendService.GetOnlineFriends(Context.UserIdentifier);
        }
        public async Task ChangeStatus(UserStatus status)
        {
            var friends = await FriendService.GetOnlineFriends(Context.UserIdentifier);
            await Clients.Clients(friends.Select(p => p.Address).ToList()).SendAsync("ChangeStatus", new { Address = Context.UserIdentifier, Status = status});
        }
    }
}
