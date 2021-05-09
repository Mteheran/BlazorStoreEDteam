using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorStore.Server.Context;
using Microsoft.AspNetCore.Mvc;
using shared;
//using BlazorStore.Server.Models;

namespace BlazorStore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private StoreContext context;
        public UserProfileController(StoreContext context)
        {
            this.context = context;
            this.context.Database.EnsureCreated();
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<UserProfile>> GetUserProfiles()
        {
            return context.UserProfiles;
        }

        [HttpGet("{id}")]
        public ActionResult<UserProfile> GetUserProfileById(int id)
        {
            return null;
        }

        [HttpPost("")]
        public ActionResult<UserProfile> PostUserProfile(UserProfile model)
        {
            return null;
        }

        [HttpPut("{id}")]
        public IActionResult PutUserProfile(int id, UserProfile model)
        {
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<UserProfile> DeleteUserProfileById(int id)
        {
            return null;
        }
    }
}