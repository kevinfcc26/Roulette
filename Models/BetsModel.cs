using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouletteApi.Models
{
    public class BetsModel
    {
        public int id { get; set; }
        public int? number { get; set; }
        public string? color { get; set; }
        public int money { get; set; }
        public bool winOperation { get; set;}
    }
}
