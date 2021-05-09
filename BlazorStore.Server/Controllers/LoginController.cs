using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorStore.Server.Context;
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
        private StoreContext context;
        public LoginController(TokenHelper tokeHelper, StoreContext context)
        {
            this.tokeHelper = tokeHelper;
            this.context= context;
        }
        
        [AllowAnonymous]
        [HttpPost]
        public ActionResult<string> LoginUser([FromBody]UserLogin user)
        {
            if(user.User == "user" && user.Password == "user")
            {
                return tokeHelper.GenerateToken("user", Guid.NewGuid().ToString());
            }
            else
            {
               var userProfile =  context.UserProfiles.FirstOrDefault(p=> p.UserName == user.User && p.Password == p.Password);

               if(userProfile !=null )
               {
                   return tokeHelper.GenerateToken(userProfile.UserName, userProfile.UserProfileId.ToString());
               }
            }

            return Unauthorized();
        }       
    }
}