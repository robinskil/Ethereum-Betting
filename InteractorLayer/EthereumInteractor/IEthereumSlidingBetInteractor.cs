using InteractorLayer.RequestModels;
using InteractorLayer.SlidingPuzzleBet;
using System;
using System.Collections.Generic;
using System.Text;

namespace InteractorLayer.EthereumInteractor
{
    public interface IEthereumSlidingBetInteractor : IEthereumBetInteractor
    {
        SlidingPuzzle StartPuzzleBet(string addressUser);
        SlidingPuzzle GetPuzzle(string addressUser);
        SlidingPuzzleMoveResponse Move(SlidingPuzzleMoveModel moveModel);
    }
}
