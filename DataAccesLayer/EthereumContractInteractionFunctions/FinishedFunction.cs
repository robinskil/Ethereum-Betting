using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccesLayer.EthereumContractInteractionFunctions
{
    [Function("finished", "bool")]
    public class FinishedFunction : FunctionMessage
    {

    }
}
