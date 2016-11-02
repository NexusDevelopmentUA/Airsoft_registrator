using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Airsoft_registrator.MySQL
{
    class MySQL_repository
    {
        protected const string constring_db4free = "Server=db4free.net; Port=3306; Database=airsoft_rush; Uid=bigroot; Pwd=bigroot";
        protected const string constring_localhost = "Server=localhost; Port=3306; Database=airsoft7; Uid=root; Pwd=root;";

        public static string MySQLcon()
        {
            string output = "";
            string constr = "server=db4free.net;user id=bigroot;database=airsoft_rush;port=3306;password=bigroot";
            MySqlConnection con = new MySqlConnection(constring_db4free);
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

            string constr = "server=localhost;user id=root;database=airsoft;port=3306;password=root";
            MySqlConnection con = new MySqlConnection(constring_db4free);
            string output = "";
            string query = "input params and other stuff...";
            query = query_in;

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
            string constr = "server=localhost;user id=root;database=airsoft;password=root";
            MySqlConnection con = new MySqlConnection(constring_db4free);
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            List<String> tmp = new List<string>();
            string output = "";
            string query = "input params and other stuff...";
            query = query_in;

            try
            {
                MySqlCommand select = new MySqlCommand(query, con);
                con.Open();
                DataSet dset = new DataSet();
                adapter.SelectCommand = select;

                adapter.Fill(dset,"Main");
                foreach(DataRow row in dset.Tables["Main"].Rows)
                {
                    tmp.Add(row[0].ToString());
                }
                Console.WriteLine(output = "Query successfully done!");
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
            string constr = "server=db4free.net;user id=bigroot;database=airsoft_rush;port=3306;password=bigroot";
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
    }
}