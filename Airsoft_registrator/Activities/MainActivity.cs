using System;
using System.Data;
using System.Collections;
using System.Linq;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Airsoft_registrator.MySQL;
using System.Collections.Generic;
using Android.Graphics;
using MySql.Data.MySqlClient;

namespace Airsoft_registrator
{
    [Activity(Label = "Ігри", Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        
        TableLayout tl;
        //List<String> locations;
        //List<String> dates;
        //List<String> id;
        List<Structure> games_info;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            MySQL.MySQL_repository.MySQLcon();
            GetAllRecords();
            
        }

        private void GetAllRecords()
        {
            games_info = MySQL_repository.MySQLselect_games("SELECT * FROM games");
            Console.WriteLine(games_info.Count);
            var tmp = games_info[0].id;
            tmp = games_info[1].id;
            tl = FindViewById<TableLayout>(Resource.Id.tableLayout1);
            
            foreach(var game in games_info)
            {
                Button reg_btn = new Button(this);
                TextView tv = new TextView(this);
                View view = new View(this);
                TableRow tr = new TableRow(this);

                tr.LayoutParameters = new TableLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
                tv.LayoutParameters = new TableRow.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
                reg_btn.LayoutParameters = new TableRow.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent);

                tv.Text += "" + game.location + "           " + game.date + "         " + game.count_players;
                tv.TextSize = 12;

                reg_btn.Text = "Зареєструватись";
                reg_btn.Click +=(sender, e)=> Reg_btn_Click(sender, e, game.id.ToString());

                tr.AddView(tv);
                tr.AddView(reg_btn);
                tl.AddView(tr);
            }
        }

        private void Reg_btn_Click(object sender, EventArgs e, string id)
        {
            string count_str = MySQL_repository.MySQLselect_string("SELECT players FROM games WHERE idgames= '" + id + "'");
            Console.WriteLine(count_str);
            int count = Int32.Parse(count_str);
            count++;
            string query = "UDPATE games set players='"+count+"' WHERE idgames='"+id+"'";

            Toast.MakeText(this, "Успішно зареєстровано", ToastLength.Short);
        }
        
    }
}

