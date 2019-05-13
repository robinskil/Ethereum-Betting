using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccesLayer.EthereumContractInteractionFunctions
{
    [Function("userAlreadyJoined","bool")]
    public class UserAlreadyJoinedFunction : FunctionMessage
    {
        [Parameter("address","userAddress")]
        public string Address { get; set; }
    }
}
