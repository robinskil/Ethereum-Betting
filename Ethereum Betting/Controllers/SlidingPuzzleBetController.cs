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

        [HttpGet]
        public async Task<string> GetWinners(string addressPuzzleBet)
        {
            return "0x341b9290f9083D7f08882b0d311006564D2a35E7@0x01C4AD590009b3c54b3FCe3770D98DB04bBBcD8b";
        }
        [HttpGet]
        [Route("GetWinners")]
        public async Task<string> GetWinners()
        {
            return "0x341b9290f9083D7f08882b0d311006564D2a35E7@0x01C4AD590009b3c54b3FCe3770D98DB04bBBcD8b";
        }
    }
}