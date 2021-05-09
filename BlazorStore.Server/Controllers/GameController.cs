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
    public class GameController : ControllerBase
    {
        private StoreContext context;
        public GameController(StoreContext context)
        {
            this.context = context;
            this.context.Database.EnsureCreated();
        }
        
        [HttpGet("")]
        public ActionResult<IEnumerable<Game>> GetTModels()
        {
            return context.Games;
        }  

        [HttpPost("")]
        public ActionResult<Game> PostTModel(Game model)
        {
            context.Games.Add(model);

            context.SaveChanges();

            return model;
        }      
    }
}