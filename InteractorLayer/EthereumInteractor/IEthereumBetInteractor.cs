using System;
using System.Collections.Generic;
using System.Text;

namespace InteractorLayer.EthereumInteractor
{
    public interface IEthereumBetInteractor
    {
        bool JoinedBet(string addressUser, string addressBetContract);
    }
}
