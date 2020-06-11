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
        private readonly RouletteService _rouletteService;
        public RouletteController(RouletteService rouletteService)
        {
            _rouletteService = rouletteService;
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
    }
}