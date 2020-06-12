using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RouletteApi.Services;
using RouletteApi.Mappers;

namespace RouletteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CloseRouletteController : ControllerBase
    {
        private readonly RouletteService _rouletteService; 
        public CloseRouletteController(RouletteService rouletteService)
        {
            _rouletteService = rouletteService;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ClouseRoulette(int id)
        {
            var request = await _rouletteService.CloseRoulette(id);

            return Ok(ResponseMapper.MapClose(request));
        }
        
    }
}