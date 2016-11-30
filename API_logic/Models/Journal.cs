using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_logic.Models
{
    public class Journal
    {
        public int idjournal { get; set; }
        public string games { get; set; }
        public string players { get; set; }
        public string photos { get; set; }
    }
}