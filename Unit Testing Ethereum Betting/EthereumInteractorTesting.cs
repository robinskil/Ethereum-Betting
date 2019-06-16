using InteractorLayer.EthereumInteractor;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Unit_Testing_Ethereum_Betting
{
    public class EthereumInteractorTesting
    {
        IEthereumBetInteractor BetInteractor { get; } = new EthereumBetInteractor();
        /// <summary>
        /// Test Joined Bet is true
        /// </summary>
        [Fact]
        public async void TestJoined()
        {
            var result = await BetInteractor.JoinedBet("0x341b9290f9083D7f08882b0d311006564D2a35E7", "0x9A55c321FAfe8904Ebc52Ab7f33dfF1F426ab361");
            Assert.True(result);
        }
        /// <summary>
        /// Test bet finished is false
        /// </summary>
        [Fact]
        public async void TestFinished()
        {
            var result = await BetInteractor.BetFinished("0x9A55c321FAfe8904Ebc52Ab7f33dfF1F426ab361");
            Assert.False(result);
        }
    }
}
