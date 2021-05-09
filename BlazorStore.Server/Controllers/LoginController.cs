using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorStore.Server.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using shared;
//using BlazorStore.Server.Models;

namespace BlazorStore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly TokenHelper tokeHelper;
        public LoginController(TokenHelper tokeHelper)
        {
            this.tokeHelper = tokeHelper;
        }
        
        [AllowAnonymous]
        [HttpPost]
        public ActionResult<string> LoginUser([FromBody]UserLogin user)
        {
            if(user.User == "user" && user.Password == "user")
            {
                return tokeHelper.GenerateToken();
            }

            return Unauthorized();
        }       
    }
}