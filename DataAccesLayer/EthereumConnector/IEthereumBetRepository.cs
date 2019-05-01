using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccesLayer.EthereumConnector
{
    public interface IEthereumBetRepository
    {
        bool UserJoinedBet(string addressUser, string addressBetContract);
    }
}
