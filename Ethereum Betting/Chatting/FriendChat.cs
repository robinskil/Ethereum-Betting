using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ethereum_Betting.Chatting
{

    public class FriendChat : Hub
    {
        private static readonly IList<string> Id = new List<string>();
        public override Task OnConnectedAsync()
        {
            Id.Add(Context.ConnectionId);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}
