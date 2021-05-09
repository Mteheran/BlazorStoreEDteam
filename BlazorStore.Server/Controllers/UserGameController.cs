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
    public class UserGameController : ControllerBase
    {

        private StoreContext context;
        public UserGameController(StoreContext context)
        {
            this.context = context;
            this.context.Database.EnsureCreated();
        }


        [HttpGet("GetGames/{id}")]
        public ActionResult<IEnumerable<Game>> GetGamesByUser(string id)
        {
            var gameList = context.UserGames.Where(p=> p.UserProfileId == Guid.Parse(id)).Select(p=> p.GameId).ToList();

            return context.Games.Where(p=> gameList.Contains(p.GameId)).ToList();
        }

        [HttpPost("")]
        public ActionResult<UserGame> PostTModel(UserGame model)
        {
            context.UserGames.Add(model);

            context.SaveChanges();

            return model;
        }
    }
}