using DataAccesLayer.EthereumContractInteractionFunctions;
using Nethereum.Web3;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.EthereumConnector
{
    public class EthereumBetRepository : EthereumRepository, IEthereumBetRepository
    {
        public EthereumBetRepository() : base()
        {

        }
        public async Task<bool> UserJoinedBet(string addressUser, string addressBetContract)
        {
            var joinedFunction = new UserAlreadyJoinedFunction()
            {
                Address = addressUser
            };
            var joinedHandler = Web3.Eth.GetContractQueryHandler<UserAlreadyJoinedFunction>();
            bool joined = await joinedHandler.QueryAsync<bool>(addressBetContract, joinedFunction);
            return joined;
        }
        public async Task<bool> BetFinished(string addressBetContract)
        {
            var finishedFunction = new FinishedFunction();
            var finishedHandler = Web3.Eth.GetContractQueryHandler<FinishedFunction>();
            bool finished = await finishedHandler.QueryAsync<bool>(addressBetContract, finishedFunction);
            return finished;
        }
    }
}
