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
    public partial class UserController : ControllerBase
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
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginRequestModel loginModel)
        {
            if(!UserInteractor.CheckIfAddressExists(loginModel.Address))
            {
                return BadRequest( new {success = false, msg = "Address does not exists!" });
            }
            if(ModelState.IsValid && UserInteractor.Login(loginModel, out ClaimsIdentity claimsID))
            {
                AuthenticationProperties authenticationProperties = new AuthenticationProperties()
                {
                    AllowRefresh = true,
                    IssuedUtc = DateTime.Now,
                    ExpiresUtc = DateTime.Now.AddHours(1)
                };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsID), authenticationProperties);
                return Ok(new {success = true, msg = "User is logged in!" });
            } else {
                return BadRequest( new {succes = false, msg = "Address/password is wrong!"});
            }
        }
        [HttpPost]
        [Route("delete")]
        public async Task<IActionResult> DeleteUser(DeleteUserRequestModel deleteModel)
        {
            if(!UserInteractor.CheckIfAddressExists(deleteModel.Address))
            {
                return BadRequest( new {success = false, msg = "Address does not exists!" });
            }
            if(ModelState.IsValid && UserInteractor.DeleteUser(deleteModel))
            {
                return Ok(new {success = true, msg = "User succesfuly deleted!" });
            } else {
                return BadRequest( new {succes = false, msg = "User could not be deleted!"});
            }
        }

        [HttpPost]
        [Route("changepassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordRequestModel changePasswordModel)
        {
            if(!UserInteractor.CheckIfAddressExists(changePasswordModel.Address))
            {
                return BadRequest( new {success = false, msg = "Address does not exists!" });
            }
            if(ModelState.IsValid && UserInteractor.ChangePassword(changePasswordModel))
            {
                return Ok(new {success = true, msg = "Password succesfully changed" });
            } else {
                return BadRequest( new {succes = false, msg = "Could not change password!"});
            }
        }


        [HttpGet]
        [Route("isAuthenticated")]
        public async Task<IActionResult> isAuthenticated(){
            if(HttpContext.User.Identity.IsAuthenticated)
            {
                return Ok(new {success = true, msg = "User has now logged in!" });
            }

            return BadRequest(new {success = false, msg = "User is not logged in!" });
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

    /// <summary>
    /// Useractions
    /// </summary>
    public partial class UserController
    {
        /// <summary>
        /// Creates an user account.
        /// TODO: Create async request to database.
        /// </summary>
        /// <param name="createModel"></param>
        /// <returns></returns>

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> CreateUser(CreateUserRequestModel createModel)
        {
                if(UserInteractor.CheckIfAddressExists(createModel.Address))
                {
                    return BadRequest( new {success = false, msg = "Address already exists!" });
                }
                else if(UserInteractor.CheckIfNameExists(createModel.Username))
                {
                    return BadRequest( new {success = false, msg = "Username already exists!"});
                }
                else if (ModelState.IsValid && UserInteractor.CreateUser(createModel))
                {
                    return Ok( new {success = true, msg = "User succesfully created!"});
                }
                return Forbid();

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="addresses"></param>
        /// <returns></returns>
        public async Task<IActionResult> AddressesToName(IEnumerable<string> addresses)
        {
            return Ok(await UserInteractor.AddressesToName(addresses));
        }
    }
}