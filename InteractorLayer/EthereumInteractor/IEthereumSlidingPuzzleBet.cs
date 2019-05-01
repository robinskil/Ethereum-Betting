﻿using InteractorLayer.RequestModels;
using InteractorLayer.SlidingPuzzleBet;
using System;
using System.Collections.Generic;
using System.Text;

namespace InteractorLayer.EthereumInteractor
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
