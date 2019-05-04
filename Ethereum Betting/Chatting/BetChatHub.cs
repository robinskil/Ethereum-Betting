using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ethereum_Betting.Chatting
{
    public interface IBetChat
    {
        Task JoinBetChat(string betAddress);
        Task LeaveBetChat(string betAddress);
        Task SendMessage(string betAddress, string message);
    }
    public class BetChatHub : Hub<IBetChat>, IBetChat
    {
        public Task JoinBetChat(string betAddress)
        {
            throw new NotImplementedException();
        }

        public Task LeaveBetChat(string betAddress)
        {
            throw new NotImplementedException();
        }

        public Task SendMessage(string betAddress, string message)
        {
            throw new NotImplementedException();
        }
    }
}
