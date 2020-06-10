using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RouletteApi.Models;

namespace RouletteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouletteController : ControllerBase
    { 
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            return Ok(new RouletteModel ( ){
                id = 1,
                name = "nueva",
                open = false
            });
        }
    }
}