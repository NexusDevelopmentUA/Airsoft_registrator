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
using Realms;
using Android.Graphics;
using MySql.Data.MySqlClient;
using Airsoft_registrator.Realm_;
using Airsoft_registrator.Activities;

namespace Airsoft_registrator
{
    [Activity(Label = "Ігри", Icon = "@drawable/icon", Theme = "@style/MyTheme.Main")]
    public class MainActivity : Activity
    {
        ListView list;
        List<Game> games_info;
        public static List<string> players;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            list = FindViewById<ListView>(Resource.Id.List);
            //GetAllRecords();
            games_info = MySQL_repository.MySQLselect_games("SELECT * FROM games");
            CustomListViewAdapter adapter = new CustomListViewAdapter(this, games_info);
            list.Adapter = adapter;
            list.ItemClick += List_ItemClick;
        }

        private void GetAllRecords()
        {
            games_info = MySQL_repository.MySQLselect_games("SELECT * FROM games");
            CustomListViewAdapter adapter = new CustomListViewAdapter(this, games_info);
            list.Adapter = adapter;
            list.ItemClick += List_ItemClick;
        }

        private void List_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Console.WriteLine("anything");
            players = MySQL_repository.MySQLselect("SELECT players FROM journal WHERE games = '" + games_info[e.Position].game_name + "'");
            StartActivity(typeof(Players));
        }
    }

    class CustomListViewAdapter : BaseAdapter<Game>
    {
        private List<Game> items;
        private Context context;

        public CustomListViewAdapter(Context pcontext, List<Game> pitems)
        {
            items = pitems;
            context = pcontext;
        }

        public override int Count
        {
            get
            {
                return items.Count();
            }
        }

        public override Game this[int position]
        {
            get
            {
                return items[position];
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(context).Inflate(Resource.Layout.CustomView, null, false);
            }

            TextView game_name = row.FindViewById<TextView>(Resource.Id.txtGameName);
            TextView count_players = row.FindViewById<TextView>(Resource.Id.txtCount);
            TextView org = row.FindViewById<TextView>(Resource.Id.txtOrg);
            Button registrate = row.FindViewById<Button>(Resource.Id.btnRegistrate);

            game_name.Text = items[position].game_name;
            count_players.Text = items[position].count_players.ToString();
            org.Text = items[position].org;

            registrate.Text = "Зареєструватись";
            registrate.Focusable = false;
            registrate.FocusableInTouchMode = false;
            registrate.Clickable = true;
            registrate.Click += (object sender, EventArgs args) =>
            {
                string tmp = "";
                var realm = Realm.GetInstance();
                var CurrentUser = realm.All<Realm_user>().Where(d => d.Status == "LogIn");
                foreach (var val in CurrentUser)
                {
                    tmp = val.Callsign;
                }
                MySQL_repository.MySQL_add_registr(items[position].count_players, tmp, items[position].game_name);
                
            };
            return row;
        }
    }
}


