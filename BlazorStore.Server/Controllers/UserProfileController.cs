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
        public ActionResult<UserProfile> GetUserProfileById(string id)
        {
            return context.UserProfiles.FirstOrDefault(p=> p.UserProfileId == Guid.Parse(id));
        }

        [HttpPost("")]
        public ActionResult<UserProfile> PostUserProfile(UserProfile model)
        {
            context.UserProfiles.Add(model);

            context.SaveChanges();

            return model;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserProfile(string id, UserProfile model)
        {
            var user = context.UserProfiles.FirstOrDefault(p=> p.UserProfileId == Guid.Parse(id));

            if(user!=null)
            {
                user.Name = model.Name;
                user.LastName = model.LastName;
                user.Country = model.Country;
                user.Email = model.Email;

                await context.SaveChangesAsync();

                return Ok();
            }
            else
            {
                return NotFound();
            }

        }

        [HttpDelete("{id}")]
        public ActionResult<UserProfile> DeleteUserProfileById(int id)
        {
            return null;
        }
    }
}