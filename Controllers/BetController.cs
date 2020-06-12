using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RouletteApi.Models;
using RouletteApi.Services;
using RouletteApi.Mappers;

namespace RouletteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BetController : ControllerBase
    {
        private readonly RouletteService _rouletteService;
        public BetController( RouletteService rouletteService ){
            _rouletteService = rouletteService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateBet([FromBody]BetApiModel bet)
        {
            // var header = _context.HttpContext.Request?.Headers["id"];
            var newbet = await _rouletteService.NewBet(bet);

            return Ok(ResponseMapper.MapBet(newbet));
        }
    }
}