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
    public class RouletteController : ControllerBase
    { 
        private readonly RouletteService _rouletteService; ActionContext _context;
        public RouletteController(RouletteService rouletteService, ActionContext context)
        {
            _rouletteService = rouletteService;
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> CreateRoulette()
        {
            var roulette = await _rouletteService.CreateNewRoulette();

            return Ok(roulette.id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> OpenRulette( int id){
            var status = await _rouletteService.OpenRoulette(id);
           
            return Ok(status.open);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBet([FromBody]BetApiModel bet)
        {
            var header = _context.HttpContext.Request?.Headers["id"];
            var newbet = await _rouletteService.NewBet(bet);

            return Ok(newbet);
        }
    } 
}
