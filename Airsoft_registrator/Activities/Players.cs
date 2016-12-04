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
    [Activity(Label = "Список гравців", Theme = "@style/MyTheme.Main")]
    public class Players : ListActivity
    {
        public List<String> requested_players;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            requested_players = MainActivity.players;
            ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, requested_players);

        }
        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            string requested_player = requested_players[position];
            var NewActivity = new Intent(this, typeof(User_Profile));
            NewActivity.PutExtra("Requested Player", requested_player);
            StartActivity(NewActivity);
        }
    }
}