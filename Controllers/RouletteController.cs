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
        public IActionResult Post()
        {
            var model = _rouletteService.CreateRoulette(1);

            return Ok(model);
        }
    }
}