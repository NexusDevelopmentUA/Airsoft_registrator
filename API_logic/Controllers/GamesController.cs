using API_logic.MySQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySql.Data.MySqlClient;

namespace API_logic.Controllers
{
    public class GamesController : ApiController
    {
        [HttpGet]
        public List<Game> GetAllGames()
        {
            string query = "Select * FROM games";
            MySqlConnection con = new MySqlConnection("Server=localhost; Port=3306; Database=airsoft_db; Uid=root; Pwd=root");
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            List<Game> list = new List<Game>();
            try
            {
                MySqlCommand select = new MySqlCommand(query, con);
                con.Open();
                select = con.CreateCommand();
                con.Open();

                using (MySqlDataReader reader = select.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string game_name = (string)reader["game_name"];
                        string location = (string)reader["location"];
                        string date = (string)reader["_date"];
                        string organisator = (string)reader["organisator"];
                        int players = (int)reader["players"];
                        var file = new Game { game_name = game_name, location = location, date = date, org = organisator, count_players = players };

                        list.Add(file);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return list;
        }
        [HttpGet]
        public string GetGame(string game_name)
        {
            string query = ("SELECT * WHERE game_name = '"+game_name+"'");
            return (MySQL_repository.MySQLselect_string(query));
        }
        [HttpPost]
        public string AddGame(string in_name, string in_location, DateTime in_date, int in_players, string in_organisator)
        {
            try
            {
                MySQL_repository.MySQL_add_game(in_name, in_location, in_date, in_players, in_organisator);
                return "Success";
            }
            catch(Exception e)
            {
                return e.Message;
            }
        }
    }
}
