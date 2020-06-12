using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RouletteApi.Services;

namespace RouletteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetAllRouletteController : ControllerBase
    {
        private readonly RouletteService _rouletteService; 
        public GetAllRouletteController(RouletteService rouletteService)
        {
            _rouletteService = rouletteService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var request = await _rouletteService.GetAll();
            return Ok(request);
        }
    }
}