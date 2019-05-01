using System;
using System.Collections.Generic;
using System.Text;
using InteractorLayer.RequestModels;
using InteractorLayer.SlidingPuzzleBet;

namespace InteractorLayer.EthereumInteractor
{
    public class EthereumSlidingPuzzleBet : EthereumBetInteractor, IEthereumSlidingPuzzleBet
    {
        public SlidingPuzzle GetPuzzle()
        {
            throw new NotImplementedException();
        }

        public SlidingPuzzleMoveResponse MoveDown(SlidingPuzzleMoveModel moveModel)
        {
            throw new NotImplementedException();
        }

        public SlidingPuzzleMoveResponse MoveLeft(SlidingPuzzleMoveModel moveModel)
        {
            throw new NotImplementedException();
        }

        public SlidingPuzzleMoveResponse MoveRight(SlidingPuzzleMoveModel moveModel)
        {
            throw new NotImplementedException();
        }

        public SlidingPuzzleMoveResponse MoveUp(SlidingPuzzleMoveModel moveModel)
        {
            throw new NotImplementedException();
        }
    }
}
