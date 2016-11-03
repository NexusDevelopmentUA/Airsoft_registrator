using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Airsoft_registrator.Activities
{
    [Activity(Label = "Create_Game")]
    public class Create_Game : Activity
    {
        Button add;
        TextView location, name, date;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.CreateGame);

            add = FindViewById<Button>(Resource.Id.btn_GameInsert);
            name = FindViewById<TextView>(Resource.Id.txt_name);
            location = FindViewById<TextView>(Resource.Id.txt_location);
            date = FindViewById<TextView>(Resource.Id.txt_date);

            add.Click += Add_Click;
        }

        private void Add_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO games(name,location,date) VALUES ('" + name.Text + "','" + location.Text + "','" + date.Text + "')";
            MySQL.MySQL_repository.MySQLquery(query);
        }
    }
}