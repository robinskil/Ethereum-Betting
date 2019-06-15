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
        static Dictionary<string, PuzzleBet> BetsWithPuzzles { get; } = new Dictionary<string, PuzzleBet>();

        /// <summary>
        /// Gets or creates a bet from our in memory cached BetsWithPuzzles
        /// </summary>
        /// <param name="addressUser"></param>
        /// <returns></returns>
        public int[,] GetPuzzle(string addressUser, string betAddress)
        {
            //Check if p
            if (!BetsWithPuzzles.ContainsKey(betAddress))
            {
                //Check if bet exists in eth network
                //check if it started
                //check if bet finished
                //check if user joined bet
                if (true)
                {
                    //create new bet
                    BetsWithPuzzles.TryAdd(betAddress, new PuzzleBet());
                }
            }
            //throw new NotImplementedException();
            return BetsWithPuzzles[betAddress].GetPuzzleLayout(addressUser);
        }

        public string GetWinners(string betAddress)
        {
            if (BetsWithPuzzles.ContainsKey(betAddress) && BetsWithPuzzles[betAddress].BetFinished)
            {
                return string.Join("@", BetsWithPuzzles[betAddress].GetFastest());
            }
            throw new Exception("Bet doesnt exist or hasnt finished yet");
        }

        public SlidingPuzzleMoveResponse Move(string addressUser, string betAddress, SlidingPuzzleMoveModel moveModel)
        {
            throw new NotImplementedException();
        }
    }
}
