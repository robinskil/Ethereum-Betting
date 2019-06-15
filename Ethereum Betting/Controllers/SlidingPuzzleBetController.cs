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
        [HttpGet]
        [Route("GetPuzzle")]
        public async Task<IActionResult> GetPuzzle(string addressUser, string addressBet)
        {
            return Ok(SlidingBetInteractor.GetPuzzle(addressUser, addressBet));
        }
        [HttpGet]
        [Route("MakeMove")]
        public async Task<IActionResult> MakeMove(string addressUser, string addressBet, SlidingPuzzleMoveModel moveModel)
        {
            if (SlidingBetInteractor.Move(addressUser, addressBet, moveModel))
            {
                return Ok();
            }
            return BadRequest("Couldnt do move");
        }

        // [HttpGet]
        // [Route("GetWinners")]
        // public async Task<string> GetWinners(string addressPuzzleBet)
        // {
        //     return SlidingBetInteractor.GetWinners(addressPuzzleBet);
        // }
        [HttpGet]
        [Route("GetWinners")]
        public async Task<string> GetWinners(string addressPuzzleBet)
        {
            return "0x341b9290f9083D7f08882b0d311006564D2a35E7@0x01C4AD590009b3c54b3FCe3770D98DB04bBBcD8b";
        }
    }
}