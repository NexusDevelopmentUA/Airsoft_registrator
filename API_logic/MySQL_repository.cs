using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;

namespace API_logic.MySQL
{
    class MySQL_repository
    {

        protected const string constring_db4free = "Server=db4free.net; Port=3306; Database=airsoft_rush; Uid=bigroot; Pwd=bigroot";
        protected const string constring_localhost = "Server=localhost; Port=3306; Database=airsoft_db; Uid=root; Pwd=root";

        public static string MySQLcon()
        {
           
            string output = "";
            MySqlConnection con = new MySqlConnection(constring_localhost);
            try
               
            {
                con.Open();
                output = "Success!";
                Console.WriteLine(output);
            }
            catch (Exception e)
            {
                output = e.Message;
                Console.WriteLine(e.Message);
            }
            return (output);
        }

        public static string MySQLquery(string query_in)
        {

            MySqlConnection con = new MySqlConnection(constring_db4free);
            string output = "";
            string query = "input params and other stuff...";
            query = query_in;
            int[] arr = new int[4] { 1, 2, 3, 4 };
            try
            {
                con.Open();
                MySqlCommand insert = new MySqlCommand(query, con);
                MySqlDataReader reader = insert.ExecuteReader();
                Console.WriteLine(output = "Query successfully done!");

            }
            catch (Exception e)
            {
                output = Convert.ToString(e);
                Console.WriteLine(e.Message);
            }
            con.Close();
            return (output);
        }

        public static List<String> MySQLselect(string query_in)
        {
            MySqlConnection con = new MySqlConnection(constring_db4free);
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            List<string> tmp = new List<string>();
            string query = "input params and other stuff...";
            query = query_in;
              
            try
            {
                
                MySqlCommand select = new MySqlCommand(query, con);
                con.Open();
                DataSet dset = new DataSet();
                adapter.SelectCommand = select;

                adapter.Fill(dset,"Main");
                foreach (DataRow row in dset.Tables["Main"].Rows)
                {
                    tmp.Add(row[0].ToString());
                }

                Console.WriteLine("Query successfully done!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            con.Close();
            return (tmp);
        }

        public static string MySQLselect_string(string query_in)
        {
            MySqlConnection con = new MySqlConnection(constring_db4free);
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            string result;
            string query = "input params and other stuff...";
            query = query_in;

            try
            {
                MySqlCommand select = new MySqlCommand(query, con);
                con.Open();
                result = select.ExecuteScalar().ToString();
                Console.WriteLine("Query successfully done!");
            }
            catch (Exception e)
            {
                result = e.Message;
                Console.WriteLine(e.Message);
            }
            con.Close();
            return (result);
        }
        public static IEnumerable<Game> MySQL_select_game()
        {
            string query = "Select * FROM games";
            MySqlConnection con = new MySqlConnection(constring_db4free);
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
/*        public static List<Game> MySQLselect_games(string query_in)
        {
            MySqlConnection con = new MySqlConnection(constring_db4free);
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            List<Game> games_info = new List<Game>();
            string query = "input params and other stuff...";
            query = query_in;

            try
            {

                MySqlCommand select = new MySqlCommand(query, con);
                con.Open();
                DataSet dset = new DataSet();
                adapter.SelectCommand = select;
                string id = "", location = "", date = "",  game_name = "", org = "";
                int players = 1;
                adapter.Fill(dset, "Main");
                foreach (DataRow row in dset.Tables["Main"].Rows)
                {
                    foreach(DataColumn column in dset.Tables["Main"].Columns)
                    {
                        switch(column.ColumnName)
                        {
                            case "idgames":
                                {
                                    id = row[column].ToString();
                                    break;
                                }
                            case "location":
                                {
                                    location = row[column].ToString();
                                    break;
                                }
                            case "_date":
                                {
                                    date = row[column].ToString();
                                    break;
                                }
                            case "players":
                                {
                                    players = Int32.Parse(row[column].ToString());
                                    break;
                                }
                            case "game_name":
                                {
                                    game_name = row[column].ToString();
                                    break;
                                }
                            case "organisator":
                                {
                                    org = row[column].ToString();
                                    break;
                                }
                        }
                    }
                    games_info.Add(new Game() { id = id, location = location, date = date, count_players = players, game_name = game_name, org = org });
                }
                Console.WriteLine("Query successfully done!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            con.Close();         
            return (games_info);
        }
        */
        public static void MySQL_add_registr(int count, string player, string game)
        {
            MySqlConnection con = new MySqlConnection(constring_db4free);
            MySqlCommand stored = new MySqlCommand("adding_player", con);
            count++;
            try
            {
                stored.CommandType = CommandType.StoredProcedure;
                stored.Parameters.Add(new MySqlParameter("game", game));
                stored.Parameters.Add(new MySqlParameter("player", player));
                stored.Parameters.Add(new MySqlParameter("count_players", count));

                stored.Connection.Open();
                stored.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                stored.Connection.Close();
            }
        }
        public static void MySQL_add_game(string name, string location, DateTime date, int players, string organisator)
        {
            MySqlConnection con = new MySqlConnection(constring_db4free);
            MySqlCommand stored = new MySqlCommand("adding_new_game", con);
            try
            {
                stored.CommandType = CommandType.StoredProcedure;
                stored.Parameters.Add(new MySqlParameter("_name", name));
                stored.Parameters.Add(new MySqlParameter("location", location));
                stored.Parameters.Add(new MySqlParameter("_date", date));
                stored.Parameters.Add(new MySqlParameter("players", players));
                stored.Parameters.Add(new MySqlParameter("org", organisator));

                stored.Connection.Open();
                stored.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                stored.Connection.Close();
            }
        }
    }
}