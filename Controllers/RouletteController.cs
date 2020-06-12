using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RouletteApi.Services;
using RouletteApi.Mappers;

namespace RouletteController
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouletteController : ControllerBase
    {
        private readonly RouletteService _rouletteService;
        public RouletteController( RouletteService rouletteService ){
            _rouletteService = rouletteService;
        }
        [HttpGet]
        public async Task<IActionResult> CreateRoulette()
        {
            var roulette = await _rouletteService.CreateNewRoulette();

            return Ok(ResponseMapper.Map(roulette));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> OpenRulette( int id){
            var roulette = await _rouletteService.OpenRoulette(id);
           
            return Ok(ResponseMapper.MapOp(roulette));
        }
        
    }
}