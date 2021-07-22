using AluraFlix.API.Application.Videos.Queries.GetVideos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AluraFlix.API.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideosController : ApiControllerBase
    {
        [HttpGet("/videos")]
        public async Task<ActionResult<VideosVm>> Get()
        {
            return await Mediator.Send(new GetVideosQuery());
        }
    }
}
