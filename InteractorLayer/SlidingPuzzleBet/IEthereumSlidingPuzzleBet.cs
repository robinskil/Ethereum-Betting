using InteractorLayer.RequestModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace InteractorLayer.SlidingPuzzleBet
{
    public interface IEthereumSlidingPuzzleBet
    {
        SlidingPuzzleMoveResponse MoveRight(SlidingPuzzleMoveModel moveModel);
        SlidingPuzzleMoveResponse MoveLeft(SlidingPuzzleMoveModel moveModel);
        SlidingPuzzleMoveResponse MoveUp(SlidingPuzzleMoveModel moveModel);
        SlidingPuzzleMoveResponse MoveDown(SlidingPuzzleMoveModel moveModel);
        SlidingPuzzle GetPuzzle();
    }
}
