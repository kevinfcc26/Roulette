using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouletteApi.Models
{
    public class BetsModel
    {
        public int id { get; set; }
        public int? number {get; set;}
        public string money {get; set;}
    }
}