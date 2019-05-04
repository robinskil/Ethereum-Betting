﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ethereum_Betting.Chatting
{
    [Authorize]
    public class FriendChat : Hub
    {
        private static IList<string> Id = new List<string>();
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
