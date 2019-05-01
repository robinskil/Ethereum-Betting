using DataAccesLayer.EthereumConnector;
using System;
using System.Collections.Generic;
using System.Text;

namespace InteractorLayer.EthereumInteractor
{
    public class EthereumBetInteractor
    {
        IEthereumBetRepository BetRepository { get; }
        public EthereumBetInteractor()
        {
            BetRepository = new EthereumBetRepository();
        }
    }
}
