using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RouletteApi.Models;
using RouletteApi.Repositories;

namespace RouletteApi.Services
{
    public class RouletteService {
        private readonly RouletteRepository _rouletteRepository;
        public RouletteService(RouletteRepository rouletteRepository)
        {
            _rouletteRepository = rouletteRepository;
        }
        public RouletteModel CreateRoulette(int id){
            var model = _rouletteRepository.Create(id);
            
            return model;

        }

    }
}