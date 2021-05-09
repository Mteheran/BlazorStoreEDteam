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
    public class NewsController : ControllerBase
    {
        private StoreContext context;
        public NewsController(StoreContext context)
        {
            this.context = context;
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<News>> GetTModels()
        {
            return context.News;
        }

        [HttpPost("")]
        public ActionResult<News> PostUserProfile(News model)
        {
            context.News.Add(model);

            context.SaveChanges();

            return model;
        }
    }
}