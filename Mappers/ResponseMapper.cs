using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RouletteApi.Models;
using RouletteApi.Models.ResponsesModels;

namespace RouletteApi.Mappers
{
    public class ResponseMapper
    {
        public static CreateRouletteModel Map(RouletteModel roulette){
            return new CreateRouletteModel(){
                id = roulette.id
            };
            
        }
        public static OpenRouletteModel MapOp(RouletteModel roulette){
            return new OpenRouletteModel(){
                status = roulette.open
            };
        }
        public static OpenBetModel MapBet(BetsModel bets){
            if(bets.id > 0 ){
            return new OpenBetModel(){
                success = true
            };
            } else {
                return new OpenBetModel(){
                    success = false
                };
            }
        }
        public static CloseRouletteModel MapClose(RouletteModel roulette){
            return new CloseRouletteModel(){
                id = roulette.id,
                open = roulette.open
            };
        }
    }
}