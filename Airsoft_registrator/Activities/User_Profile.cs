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
using Airsoft_registrator.MySQL;

namespace Airsoft_registrator.Activities
{
    [Activity(Label = "User_Profile")]
    public class User_Profile : Activity
    {
        TextView Callsign, Team, Camo;
        RatingBar Rate;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.UserProfile);

            Callsign = FindViewById<TextView>(Resource.Id.txtUserCallsign);
            Team = FindViewById<TextView>(Resource.Id.txtUserTeam);
            Camo = FindViewById<TextView>(Resource.Id.txtUserCamo);
            Rate = FindViewById<RatingBar>(Resource.Id.UserRate);
            DisplayCurrentUserProfile();
            Toast.MakeText(this, " ", ToastLength.Short);
        }

        public void DisplayCurrentUserProfile()
        {
            var realm = Realm.GetInstance();
            var User = realm.All<Realm_.Realm_user>();
            foreach (var val in User)//і знову костиль з використанням Realm. Серйозно, це була фігова ідея. Хоча навряд з SQLite було б краще.
            {
                Callsign.Text = val.Callsign;
                Team.Text = MySQL_repository.MySQLselect_string("SELECT team FROM players WHERE name = '" + val.Callsign + "'");
                Camo.Text = MySQL_repository.MySQLselect_string("SELECT camo FROM players WHERE name = '" + val.Callsign + "'");
                string temp= (MySQL_repository.MySQLselect_string("SELECT rate FROM players WHERE name = '" + val.Callsign + "'"));
                Rate.Rating = float.Parse(temp);
            }//Мені це капець як НЕ ПОДОБАЄТЬСЯ
            //...але воно працює
        }
        /*public void DisplayRequestedUserProfile()
        {
            Callsign.Text = val.Callsign;
            Team.Text = MySQL_repository.MySQLselect_string("SELECT team FROM players WHERE name = '" + val.Callsign + "'");
            Camo.Text = MySQL_repository.MySQLselect_string("SELECT camo FROM players WHERE name = '" + val.Callsign + "'");
            string temp = (MySQL_repository.MySQLselect_string("SELECT rate FROM players WHERE name = '" + val.Callsign + "'"));
            Rate.Rating = float.Parse(temp);
        }*/
    }
}