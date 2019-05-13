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
        /// Test Joined Bet is false
        /// </summary>
        [Fact]
        public async void TestNotJoined()
        {
            var result = await BetInteractor.JoinedBet("0x96f6a741a2119B871700e935A5ad2Eb0F30AC333", "");
            Assert.False(result);
        }
        /// <summary>
        /// Test joined bet is true
        /// </summary>
        [Fact]
        public async void TestJoined()
        {
            var result = await BetInteractor.JoinedBet("", "");
            Assert.True(result);
        }
    }
}
