using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RouletteApi.Models;

namespace RouletteApi.Repositories
{
    public class RouletteRepository {

        public RouletteModel Create(){
            var Model =  new RouletteModel() {
                id = 1,
                name = "hola",
                open = false
            };
            return Model;
        }
    }
}