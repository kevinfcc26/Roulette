using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RouletteApi.Models;
using RouletteApi.Repositories;
using RouletteApi.Mappers;

namespace RouletteApi.Services
{
    public class RouletteService {
        private readonly RedisRepository _redisRepository;
        public RouletteService(RedisRepository redisRepository)
        {
            _redisRepository =  redisRepository;
        }
        public async Task<RouletteModel> CreateNewRoulette(){
               var roulettes = await _redisRepository.Read("Roulettes");
               if(roulettes == null){
                    roulettes = emptyRoulettes();
               }else {
                    int countRoulettes =roulettes.Count() +1;
                    RouletteModel roulette = new RouletteModel{
                        id = countRoulettes,
                        open = false
                    };
                    roulettes.Add(roulette);
               }
                await _redisRepository.Add("Roulettes", roulettes );
                
                return roulettes.FirstOrDefault(x => x.id == roulettes.Count());
        }   
        public async Task<RouletteModel> OpenRoulette(int id){
            var roulettes = await _redisRepository.Read("Roulettes");
            RouletteModel roulette = roulettes.FirstOrDefault(x => x.id == id);
            if(roulette == null){
                return new RouletteModel{
                    id= 0,
                    open = false
                };
            } else {
            roulette.open = true;
            await _redisRepository.Add("Roulettes",roulettes);
            
            return roulettes.Find(x => x.id == id);
            }
        }
        public async Task<BetsModel> NewBet(BetApiModel betApi){
            bool winOperation = false;
            var roulettes = await _redisRepository.Read("Roulettes");
            RouletteModel roulette = roulettes.FirstOrDefault(x => x.id == betApi.idRoulette);
            if(!betValidation(betApi)){
                return new BetsModel(){id = 0};
            }
            if (roulette == null){
                return new BetsModel {id = 0};
            }  
            if(roulette.bets == null){
                roulette.bets = new List<BetsModel>();
                winOperation = operation(betApi.number,betApi.color);
                roulette.bets.Add(BetMapper.Map(betApi, 1, winOperation));
                // await _redisRepository.Add("Roulette",roulettes);
                // return roulette.bets.Find(x => x.id == betApi.idRoulette);
            } else {
                winOperation = operation(betApi.number,betApi.color);
                roulette.bets.Add(BetMapper.Map(betApi, roulette.bets.Count()+1, winOperation));
            }
            await _redisRepository.Add("Roulettes",roulettes);
            return roulette.bets.Find(bet => bet.id == roulette.bets.Count());
        }   
        public async Task<RouletteModel> CloseRoulette(int id){
            var roulettes = await _redisRepository.Read("Roulettes");
            RouletteModel roulette = roulettes.FirstOrDefault(x => x.id == id);
            if(roulette == null){
                return new RouletteModel{
                    id= 0,
                    open = false
                };
            } else {
            roulette.open = false;
            await _redisRepository.Add("Roulettes",roulettes);
            
            return roulettes.Find(x => x.id == id);
            }
        }
        public async Task<List<RouletteModel>> GetAll(){
            var roulettes = await _redisRepository.Read("Roulettes");
            return roulettes;
        }
        private bool operation(int number, string color){
            if(number > 0 && number <= 36){
                if(new Random().Next(36) == number){
                        return true;
                } else {
                    return false;
                }
            } else {
                if(color == randomColor()){
                        return true;
                } else {
                    return false;
                }
            }
        }
        private string randomColor(){
            string color;
            if (new Random().Next(1) == 1){
                color = "negro";
                }
            else {
                color = "rojo";
                }
            return color;
        }
        private List<RouletteModel> emptyRoulettes(){
            return new List<RouletteModel>{
                new RouletteModel{
                    id = 1,
                    open = false
                }
            };
        }
        private bool betValidation(BetApiModel betApi){
            if(betApi.money >= 10000){
                return false;
            }
            if(betApi.number > 0 && betApi.number <= 36 ){
                return true;
            } else if(betApi.color.ToLower() == "negro" || betApi.color.ToLower() == "rojo" ){
                return true;
            } else {
                return false;
            }
        }
    }
}
