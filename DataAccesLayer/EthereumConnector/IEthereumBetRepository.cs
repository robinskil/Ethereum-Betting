using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.EthereumConnector
{
    public interface IEthereumBetRepository
    {
        Task<bool> UserJoinedBet(string addressUser, string addressBetContract);
        Task<bool> BetFinished(string addressBetContract);
    }
}
