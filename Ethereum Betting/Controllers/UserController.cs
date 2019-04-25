using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DataAccesLayer.EF;
using InteractorLayer;
using InteractorLayer.RequestModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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
        /// Creates an user account.
        /// TODO: Create async request to database.
        /// </summary>
        /// <param name="createModel"></param>
        /// <returns></returns>
        public async Task<IActionResult> CreateUser(CreateUserRequestModel createModel)
        {
            if (ModelState.IsValid && UserInteractor.CreateUser(createModel))
            {
                return Ok();
            }
            return Forbid();
        }

        /// <summary>
        /// Logs an user onto our server
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        public async Task<IActionResult> Login(LoginRequestModel loginModel)
        {
            if(ModelState.IsValid && UserInteractor.Login(loginModel, out ClaimsIdentity claimsID))
            {
                AuthenticationProperties authenticationProperties = new AuthenticationProperties()
                {
                    AllowRefresh = true,
                    IssuedUtc = DateTime.Now,
                    ExpiresUtc = DateTime.Now.AddHours(1)
                };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsID), authenticationProperties);
                return Ok();
            }
            return Forbid();
        }

        /// <summary>
        /// Logs an user out of our server
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok();
        }
    }
}