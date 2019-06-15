using InteractorLayer.RequestModels;
using InteractorLayer.SlidingPuzzleBet;
using System;
using System.Collections.Generic;
using System.Text;

namespace InteractorLayer.EthereumInteractor
{
    public interface IEthereumSlidingBetInteractor : IEthereumBetInteractor
    {
        int[,] GetPuzzle(string addressUser, string betAddress);
        string GetWinners(string betAddress);
        SlidingPuzzleMoveResponse Move(string addressUser, string betAddress, SlidingPuzzleMoveModel moveModel);
    }
}
