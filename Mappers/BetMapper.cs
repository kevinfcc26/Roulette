using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RouletteApi.Models;

namespace RouletteApi.Mappers
{
    public class BetMapper
    {
        public static BetsModel Map(BetApiModel betApi, int id, bool winOp)
        {
            return new BetsModel()
            {
                id = id,
                number = betApi.number,
                color = betApi.color,
                money = betApi.money,
                winOperation = winOp
            };
        }
         public static BetsModel Map(BetsModel bet)
         {
             return new BetsModel(){
                 id = bet.id,
                 number = bet.number,
                 color = bet.color,
                 money = bet.money,
                 winOperation = bet.winOperation
             };

         }
    }
}