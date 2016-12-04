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
using Realms;

namespace Airsoft_registrator.Activities
{
    [Activity(Label = "Додати гру", Theme = "@style/MyTheme.Main")]
    public class Create_Game : Activity
    {
        Button add;
        TextView location, name, date;
        string tmp = "";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.CreateGame);

            add = FindViewById<Button>(Resource.Id.btn_GameInsert);
            name = FindViewById<TextView>(Resource.Id.txt_name);
            location = FindViewById<TextView>(Resource.Id.txt_location);
            date = FindViewById<TextView>(Resource.Id.txt_date);
            
            var realm = Realm.GetInstance();
            var CurrentUser = realm.All<Realm_.Realm_user>().Where(d => d.Status == "LogIn");
            foreach (var val in CurrentUser)
            {
                tmp = val.Callsign;
            }
            add.Click += Add_Click;
        }

        private void Add_Click(object sender, EventArgs e)
        {
            
            MySQL.MySQL_repository.MySQL_add_game(1, location.Text, name.Text, date.Text, tmp);
        }
    }
}