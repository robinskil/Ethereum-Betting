using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccesLayer.EthereumConnector
{
    public class EthereumSlidingPuzzleBetRepository : EthereumBetRepository , IEthereumSlidingPuzzleBetRepository
    {
        public EthereumSlidingPuzzleBetRepository() : base()
        {

        }

        public bool SetWin(string addressUser, string addressContract, double timeToComplete)
        {
            throw new NotImplementedException();
        }
    }
}
