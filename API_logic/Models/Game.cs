using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_logic.Models
{
    public class Game
    {
        public string game_name { get; set; }
        public string location { get; set; }
        public DateTime _date { get; set; }
        public string organisator { get; set; }
        public int players { get; set; }
    }
}