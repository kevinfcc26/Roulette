using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouletteApi.Models
{
    public class RouletteModel
    {
        public int id { get; set; }
        public bool open { get; set;}
        public virtual List<BetsModel> bets { get; set;}
    }
}