using InteractorLayer.RequestModels;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xunit;
using InteractorLayer.SlidingPuzzleBet;

namespace Unit_Testing_Ethereum_Betting
{
    public class TestGenerateRandomPuzzle
    {

        /// <summary>
        /// Test if it creates a Random generated puzzle.
        /// </summary>
        [Fact]
        public void TestGenerateSlidingPuzzle()
        {
            SlidingPuzzle result = new SlidingPuzzle();
            Assert.False(result.TryFinish());
        }

        /// <summary>
        /// Test if it creates a 4X4 puzzle.
        /// </summary>
        [Fact]
        public void TestPuzzleSize()
        {
            SlidingPuzzle s = new SlidingPuzzle();
            int result = s.Puzzle.GetLength(0);
            int result2 = s.Puzzle.GetLength(1);
            int result3 = 0;
            if (s.Puzzle.Rank > 1) {
                for (int d = 0; d < s.Puzzle.Rank; d++)
                {
                    result3++;
                }
            }

            Assert.True(result == 4 && result2 == 4 && result3 == 2);
        }

        /// <summary>
        /// Test if DoMove() returns false when a wrong moveModel is inserted: X = Puzzle.GetLength(0) + 1, Y= Puzzle.GetLength(1) + 1
        /// </summary>
        [Fact]
        public void TestDoMove()
        {
            SlidingPuzzle s = new SlidingPuzzle();
            SlidingPuzzleMoveModel moveModel = new SlidingPuzzleMoveModel() { X = s.Puzzle.GetLength(0) + 1, Y = s.Puzzle.GetLength(1) + 1 };
            bool result = s.DoMove(moveModel);
            Assert.False(result);
        }


    }
}
