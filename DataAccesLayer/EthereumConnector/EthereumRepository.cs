using Nethereum.Web3;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccesLayer.EthereumConnector
{
    public class EthereumRepository
    {
        protected Web3 Web3 { get; }
        public EthereumRepository()
        {
            Web3 = new Web3("http://127.0.0.1:7545");
        }
    }
}
