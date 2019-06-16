using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InteractorLayer.EthereumInteractor
{
    public interface IEthereumBetInteractor
    {
        Task<bool> JoinedBet(string addressUser, string addressBetContract);
        Task<bool> BetFinished(string addressBetContract);
    }
}
