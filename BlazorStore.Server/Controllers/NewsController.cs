using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorStore.Server.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using shared;
//using BlazorStore.Server.Models;

namespace BlazorStore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private ILogger<News> logger;
        private StoreContext context;
        public NewsController(StoreContext context, ILogger<News> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<News>> GetTModels()
        {
            logger.LogInformation("Returning News...");
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