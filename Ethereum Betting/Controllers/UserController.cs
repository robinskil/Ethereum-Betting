using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccesLayer.EF;
using InteractorLayer;
using InteractorLayer.RequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ethereum_Betting.Controllers
{
    [Route("api/[controller]")]
    //Added for development purposes, TO BE REMOVED WHEN RELEASING
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserInteractor UserInteractor { get; }
        public UserController(EthereumBettingContext context)
        {
            UserInteractor = new UserInteractor(context);
        }

        /// <summary>
        /// Logs an user onto our server
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        public IActionResult Login(LoginRequestModel loginModel)
        {
            if(TryValidateModel(loginModel) && UserInteractor.Login(loginModel))
            {
                return Ok();
            }
            return Forbid();
        }
    }
}