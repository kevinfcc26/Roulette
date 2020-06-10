using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RouletteApi.Models;
using RouletteApi.Services;

namespace RouletteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BetsController : ControllerBase
    {

        [HttpPost]
        public IActionResult CreateBet([FromBody]BetsModel bet)
        {
            var model = bet;

            return Ok(model);
        }
    }
}