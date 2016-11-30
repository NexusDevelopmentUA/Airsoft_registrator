using API_logic.MySQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API_logic.Models;

namespace API_logic.Controllers
{
    public class PlayersController : ApiController
    {
        Player player = new Player();

        public void GetAllPlayers()
        {
            MySQL_repository.MySQLcon();
        }
        //[HttpGet]
        //public IEnumerable<Player> GetPlayerByID(int id)
        //{
        //}
    }
}
