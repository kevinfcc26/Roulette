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
        public async Task<RouletteModel> OpenRoulette(int id){
            var roulettes = await _redisRepository.Read("Roulette");
            RouletteModel roulette = roulettes.FirstOrDefault(x => x.id == id);
            if(roulette == null){
                return new RouletteModel{
                    id= 0,
                    open = false
                };
            } else {
            roulette.open = true;
            await _redisRepository.Add("Roulette",roulettes);
            
            return roulettes.Find(x => x.id == id);
            }
        }
        public async Task<BetsModel> NewBet(BetApiModel betApi){
            bool winOperation = false;
            var roulettes = await _redisRepository.Read("Roulette");
            if(betApi.money >= 10000){
                return new BetsModel{
                    id = 0
                };
            }
            else if(betApi.number >= 0 && betApi.number <= 36 ){
                winOperation = operation(betApi.number);
            } else if(betApi.color.ToLower() == "negro" || betApi.color.ToLower() == "rojo" ){
                winOperation = operation(betApi.color);
            }
            RouletteModel roulette = roulettes.FirstOrDefault(x => x.id == betApi.idRoulette);
            if (roulette == null){
                return new BetsModel {
                    id = 0 //TODO
                };
            }  
            if(roulette.bets == null){
                roulette.bets = new List<BetsModel>();
                roulette.bets.Add(BetMapper.Map(betApi, 1, winOperation));
                await _redisRepository.Add("Roulette",roulettes);
                return roulette.bets.Find(x => x.id == betApi.idRoulette);
            } else {
                roulette.bets.Add(BetMapper.Map(betApi, roulette.bets.Count()+1, winOperation));
                await _redisRepository.Add("Roulette",roulettes);
            }
            return roulette.bets.Find(bet => bet.id == roulette.bets.Count());
        }   
        public async Task<RouletteModel> CloseRoulette(int id){
            var roulettes = await _redisRepository.Read("Roulette");
            RouletteModel roulette = roulettes.FirstOrDefault(x => x.id == id);
            if(roulette == null){
                return new RouletteModel{
                    id= 0,
                    open = false
                };
            } else {
            roulette.open = false;
            await _redisRepository.Add("Roulette",roulettes);
            
            return roulettes.Find(x => x.id == id);
            }
        }
        private bool operation(int number){
            if(new Random().Next(36) == number){
                    return true;
            } else {
                return false;
            }
        }
        private bool operation(string color){
            if(color == randomColor()){
                    return true;
            } else {
                return false;
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
    }
}
