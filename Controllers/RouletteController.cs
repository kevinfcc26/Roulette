using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RouletteApi.Models;
using RouletteApi.Services;
using StackExchange.Redis.Extensions.Core.Abstractions;

namespace RouletteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouletteController : ControllerBase
    { 
        private readonly RouletteService _rouletteService;
        private IRedisCacheClient _redisCacheClient;

        public RouletteController(RouletteService rouletteService, IRedisCacheClient redisCacheClient)
        {
            _rouletteService = rouletteService;
            _redisCacheClient = redisCacheClient;
        }
        [HttpPost]
        public async Task<IActionResult> CreateRoulette()
        {
            var model = _rouletteService.CreateNewRoulette();
            bool  isAdd = await _redisCacheClient.Db0.AddAsync("Roulette", model, DateTimeOffset.Now.AddMinutes(10));
            return Ok(model);
        }

        [HttpPut]
        public IActionResult OpenRulette( int id){
            var status = true;
            return Ok(status);
        }

    }
}