using System;
using System.Collections.Generic;
using System.Text;
using InteractorLayer.RequestModels;
using InteractorLayer.SlidingPuzzleBet;

namespace InteractorLayer.EthereumInteractor
{
    public class EthereumSlidingBetInteractor : EthereumBetInteractor, IEthereumSlidingBetInteractor
    {
        //In memory cached bets with each a cache of user addresses with their respective puzzle.
        static Dictionary<string, Dictionary<string, SlidingPuzzle>> BetsWithPuzzles { get; }
        public SlidingPuzzle GetPuzzle(string addressUser)
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

        public SlidingPuzzle StartPuzzleBet(string addressUser)
        {
            throw new NotImplementedException();
        }
    }
}
