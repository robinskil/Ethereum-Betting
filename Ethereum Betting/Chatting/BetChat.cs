using DataAccesLayer.EthereumConnector;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ethereum_Betting.Chatting
{
    public interface IBetChat
    {
        Task JoinBetChat(string addressUser, string betAddress);
        Task LeaveBetChat(string addressUser, string betAddress);
        Task SendMessage(string addressUser, string betAddress, string message);
    }
    public class BetChat : Hub, IBetChat
    {
        IEthereumBetRepository BetRepository { get; }
        static ConcurrentDictionary<string, IList<string>> BetChats { get; } = new ConcurrentDictionary<string, IList<string>>();
        public BetChat() : base()
        {
            BetRepository = null;
        }
        public async Task JoinBetChat(string addressUser, string betAddress)
        {
            //ToDo: Check if bet exists
            if (true)
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, betAddress);
            }
            //throw new NotImplementedException();
        }

        public async Task LeaveBetChat(string addressUser ,string betAddress)
        {
            //ToDo: Check if bet exists
            if (true)
            {
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, betAddress);
            }
            //throw new NotImplementedException();
        }

        public async Task SendMessage(string addressUser, string betAddress, string message)
        {
            if(string.IsNullOrEmpty(addressUser) || string.IsNullOrEmpty(betAddress) || string.IsNullOrEmpty(message))
            {
                throw new ArgumentException();
            }
            if (true)
            {
                await Clients.GroupExcept(betAddress,Context.ConnectionId).SendAsync("ReceiveMessage", message);
            }
        }
    }
}
