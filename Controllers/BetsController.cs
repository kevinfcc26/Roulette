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
        private readonly RouletteService _rouletteService;
        public BetsController(RouletteService rouletteService)
        {
            _rouletteService = rouletteService;
        }

        [HttpPost]
        public IActionResult CreateBet([FromBody]BetsModel bet)
        {
            var model = bet;

            return Ok(model);
        }
    }
}