using System;
using System.Collections.Generic;
using System.Text;

namespace InteractorLayer.SlidingPuzzleBet
{
    public class SlidingPuzzle
    {
        public readonly int[,] Puzzle;
        public SlidingPuzzle()
        {
            Puzzle = new int[4,4];
            GenerateRandomPuzzle();
        }

        /// <summary>
        /// This method fills in the puzzle
        /// </summary>
        private void GenerateRandomPuzzle()
        {
            for (int i = 0; i < Puzzle.GetLength(0); i++)
            {
                for (int j = 0; j < Puzzle.GetLength(1); j++)
                {

                }
            }
        }
    }
}
