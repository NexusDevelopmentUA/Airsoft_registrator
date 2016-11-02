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
            View view = new View(this);
            view.LayoutParameters = new TableRow.LayoutParams(ViewGroup.LayoutParams.MatchParent, 2);
            view.SetBackgroundColor(Color.Black);
            TableRow tr = new TableRow(this);
            TextView txtview = new TextView(this);
            Button reg_btn = new Button(this);

            List<String> id = MySQL_repository.MySQLselect("SELECT idgames FROM games");
            List<String> locations = MySQL.MySQL_repository.MySQLselect("SELECT location, time FROM games");
            List<String> dates = MySQL_repository.MySQLselect("SELECT time FROM games");
            TableLayout tablelayout = FindViewById<TableLayout>(Resource.Id.tableLayout1);
            tablelayout.RemoveAllViews();
            tr.RemoveAllViews();
            for (int i = id.Count-1; i>=0; i--)
                {
                //        
                //{
                    
                //    //((ViewGroup)tr.Parent).RemoveView(tr);
                //    //((ViewGroup)tablelayout.Parent).RemoveView(view);
                //}
                       


                        tr.LayoutParameters = new TableLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
                        txtview.LayoutParameters = new TableRow.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
                        reg_btn.LayoutParameters = new TableRow.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent);

                        txtview.Text += "" + locations[i];
                        txtview.TextSize = 24;

                        txtview.Text += "  " + dates[i]+"        ";
                        txtview.TextSize = 24;

                        reg_btn.Text = "Зареєструватись";

                        tr.AddView(txtview);
                        tr.AddView(reg_btn);
                        tablelayout.AddView(tr);
                        tablelayout.AddView(view);
                        
                }
            //reg_btn.Click += Reg_btn_Click;
        }

        private void Reg_btn_Click(object sender, EventArgs e)
        {
            //string query = "INSERT INTO games(players) VALUES('"
            //int count = Int32.Parse(MySQL_repository.Players_count("SELECT count FROM games WHERE idgames= '"+FindViewById<Button>.sender"));
            Toast.MakeText(this, "Успішно зареєстровано", ToastLength.Short);
        }
    }
}

