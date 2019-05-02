using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccesLayer.EthereumConnector
{
    public class EthereumBetRepository : EthereumRepository , IEthereumBetRepository
    {
        public EthereumBetRepository() : base()
        {

        }
        public bool UserJoinedBet(string addressUser, string addressBetContract)
        {
            throw new NotImplementedException();
        }
    }
}
