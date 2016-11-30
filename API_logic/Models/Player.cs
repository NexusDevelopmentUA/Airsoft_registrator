using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_logic.Models
{
    public class Player
    {
        public int id { get; set; }
        public string callsign { get; set; }
        public string password { get; set; }
        public string team { get; set; }
        public string camo { get; set; }
        public double rate { get; set; }
    }
}