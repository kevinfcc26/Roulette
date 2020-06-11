using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RouletteApi.Models;
using RouletteApi.Repositories;

namespace RouletteApi.Services
{
    public class RouletteService {
        private readonly RedisRepository _redisRepository;
        public RouletteService(RedisRepository redisRepository)
        {
            _redisRepository =  redisRepository;
        }
        public async Task<RouletteModel> CreateNewRoulette(){
               var roulettes = await _redisRepository.Read("Roulette");
               if(roulettes == null){
                   roulettes = new List<RouletteModel>{
                       new RouletteModel{
                           id = 1,
                           open = false
                       }
                   };
                   await _redisRepository.Add("Roulette", roulettes );
                   return roulettes.FirstOrDefault(x => x.id == 1);
               }else {
                    int countRoulettes =roulettes.Count();
                    RouletteModel roulette = new RouletteModel{
                    id = countRoulettes+1,
                    open = false
                    };
                    roulettes.Add(roulette);
                    await _redisRepository.Add("Roulette", roulettes );
                    return roulette;
               }
        }        
    }
}
