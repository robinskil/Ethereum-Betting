using DataAccesLayer.EthereumConnector;
using InteractorLayer.RequestModels;
using InteractorLayer.SlidingPuzzleBet;
using System;
using System.Collections.Generic;
using System.Text;

namespace InteractorLayer.EthereumInteractor
{
    public class EthereumBetInteractor : IEthereumBetInteractor
    {
        protected IEthereumBetRepository BetRepository { get; }
        public EthereumBetInteractor()
        {
            BetRepository = new EthereumBetRepository();
        }

        public bool JoinedBet(string addressUser, string addressBetContract)
        {
            throw new NotImplementedException();
        }
    }
}
