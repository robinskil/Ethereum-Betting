using DataAccesLayer.EthereumConnector;
using InteractorLayer.RequestModels;
using InteractorLayer.SlidingPuzzleBet;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InteractorLayer.EthereumInteractor
{
    public class EthereumBetInteractor : IEthereumBetInteractor
    {
        protected IEthereumBetRepository BetRepository { get; }
        public EthereumBetInteractor()
        {
            BetRepository = new EthereumBetRepository();
        }

        public async Task<bool> JoinedBet(string addressUser, string addressBetContract)
        {
            return await BetRepository.UserJoinedBet(addressUser, addressBetContract);
        }
    }
}
