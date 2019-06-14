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
        public void TestSlidingPuzzle()
        {
            SlidingPuzzle result = new SlidingPuzzle();
            Assert.NotNull(result);
        }

        /// <summary>
        /// Test if 
        /// </summary>
        [Fact]
        public void TestDoMove()
        {
            SlidingPuzzle s = new SlidingPuzzle();
            SlidingPuzzleMoveModel moveModel = new SlidingPuzzleMoveModel() { X = 5, Y = 5 };
            var result = s.DoMove(moveModel);
        }
    }
}
