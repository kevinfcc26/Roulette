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
        [HttpPost]
        public async Task<IActionResult> CreateRoulette()
        {
            var roulette = await _rouletteService.CreateNewRoulette();

            return Ok(roulette.id);
        }

        [HttpPut]
        public IActionResult OpenRulette( int id){
            var status = true;
            return Ok(status);
        }

    }
}