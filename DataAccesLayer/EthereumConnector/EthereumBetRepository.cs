using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccesLayer.EthereumConnector
{
    public class EthereumBetRepository : EthereumRepository , IEthereumBetRepository , IEthereumSlidingPuzzleBetRepository
    {
        public EthereumBetRepository() : base()
        {

        }

        public bool SetWin(string addressUser, string addressContract, double timeToComplete)
        {
            throw new NotImplementedException();
        }

        public bool UserJoinedBet(string addressUser, string addressBetContract)
        {
            throw new NotImplementedException();
        }
    }
}
