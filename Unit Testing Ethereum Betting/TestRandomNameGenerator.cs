using InteractorLayer.NameGenerator;
using InteractorLayer.SlidingPuzzleBet;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Unit_Testing_Ethereum_Betting
{
    public class TestRandomNameGenerator
    {
        /// <summary>
        /// Test if it creates a 3 word name.
        /// </summary>
        [Fact]
        public void TestNameGeneration()
        {
            var result = RandomNameGenerator.GenerateName((s) => false);
            Assert.NotNull(result);
        }
    }
}
