using System.Collections.Generic;
using InteractorLayer.RequestModels;

namespace InteractorLayer.SlidingPuzzleBet
{
    public class PuzzleBet
    {
        public bool BetFinished { get; set; }
        private Dictionary<string, SlidingPuzzle> ParticipatorsPuzzles { get; }
        public bool DoMove(string userAddress, SlidingPuzzleMoveModel DoMove)
        {
            if (!ParticipatorsPuzzles.ContainsKey(userAddress))
            {
                ParticipatorsPuzzles.Add(userAddress, new SlidingPuzzle());
            }
            if (!ParticipatorsPuzzles[userAddress].Finished)
            {
                return ParticipatorsPuzzles[userAddress].DoMove(DoMove);
            }
            //else set time
            else return false;
        }

        public List<string> GetFastest()
        {
            List<string> winners = new List<string>();
            long fastest = long.MaxValue;
            foreach (var item in ParticipatorsPuzzles)
            {
                if (item.Value.Time.ElapsedMilliseconds <= fastest)
                {
                    if (item.Value.Time.ElapsedMilliseconds == fastest) winners.Add(item.Key);
                    else
                    {
                        winners = new List<string>() { item.Key };
                        fastest = item.Value.Time.ElapsedMilliseconds;
                    }
                }
            }
            return winners;
        }

        public int[,] GetPuzzleLayout(string userAddress)
        {
            if (!ParticipatorsPuzzles.ContainsKey(userAddress))
            {
                ParticipatorsPuzzles.Add(userAddress, new SlidingPuzzle());
            }
            return ParticipatorsPuzzles[userAddress].Puzzle;
        }
    }
}