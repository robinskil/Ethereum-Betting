using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccesLayer.EthereumConnector
{
    public interface IEthereumSlidingPuzzleBetRepository : IEthereumBetRepository
    {
        bool SetWin(string addressUser , string addressContract , double timeToComplete);
    }
}
