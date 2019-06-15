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
            if (!BetsWithPuzzles.ContainsKey(betAddress.ToLower()))
            {
                //Check if bet exists in eth network
                //check if bet finished
                //check if user joined bet
                if (BetRepository.UserJoinedBet(addressUser, betAddress).GetAwaiter().GetResult() && BetRepository.BetFinished(betAddress).GetAwaiter().GetResult())
                {
                    //create new bet
                    BetsWithPuzzles.TryAdd(betAddress.ToLower(), new PuzzleBet());
                }
            }
            //throw new NotImplementedException();
            return BetsWithPuzzles[betAddress.ToLower()].GetPuzzleLayout(addressUser);
        }

        public string GetWinners(string betAddress)
        {
            betAddress = betAddress.ToLower();
            if (BetsWithPuzzles.ContainsKey(betAddress) && BetsWithPuzzles[betAddress].BetFinished)
            {
                return string.Join("@", BetsWithPuzzles[betAddress].GetFastest());
            }
            throw new Exception("Bet doesnt exist or hasnt finished yet");
        }

        public bool Move(string addressUser, string betAddress, SlidingPuzzleMoveModel moveModel)
        {
            if (BetsWithPuzzles.ContainsKey(betAddress.ToLower()))
            {
                return BetsWithPuzzles[betAddress.ToLower()].DoMove(addressUser, moveModel);
            }
            else return false;
        }
    }
}
