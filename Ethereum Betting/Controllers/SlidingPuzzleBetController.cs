using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InteractorLayer.EthereumInteractor;
using InteractorLayer.RequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ethereum_Betting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlidingPuzzleBetController : ControllerBase
    {
        IEthereumSlidingBetInteractor SlidingBetInteractor { get; set; }
        public SlidingPuzzleBetController()
        {
            SlidingBetInteractor = new EthereumSlidingBetInteractor();
        }
        public async Task<IActionResult> GetPuzzle()
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> MakeMove(SlidingPuzzleMoveModel moveModel)
        {
            throw new NotImplementedException();
        }
    }
}