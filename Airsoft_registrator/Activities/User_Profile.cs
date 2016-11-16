using System.Collections.Generic;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Widget;
using Realms;
using Airsoft_registrator.MySQL;
using Android.Support.V4.App;
using Android.Views;

namespace Airsoft_registrator.Activities
{
    [Activity(Label = "User_Profile")]
    public class User_Profile : Activity
    {
        TextView Callsign, Team, Camo;
        RatingBar Rate;
        string requested_user;

        DrawerLayout mDrawerLayout;
        List<string> mLeftItems = new List<string>();
        ArrayAdapter mLeftAdapter;
        ListView mLeftDrawer;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.UserProfile);
            mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.myDrawer);
            mLeftDrawer = FindViewById<ListView>(Resource.Id.leftListView);

            requested_user = Intent.GetStringExtra("Requested Player");

            var activity = typeof(User_Profile);
            Drawer menu = new Drawer();
            menu.drawer(mDrawerLayout, mLeftItems, mLeftDrawer, this, this);

            Callsign = FindViewById<TextView>(Resource.Id.txtUserCallsign);
            Team = FindViewById<TextView>(Resource.Id.txtUserTeam);
            Camo = FindViewById<TextView>(Resource.Id.txtUserCamo);
            Rate = FindViewById<RatingBar>(Resource.Id.UserRate);
            var realm = Realm.GetInstance();
            var User = realm.All<Realm_.Realm_user>();
            string tmp_callsign = "";
            foreach (var val in User)//і знову костиль з використанням Realm. Серйозно, це була фігова ідея. Хоча навряд з SQLite було б краще.
            {
                tmp_callsign = val.Callsign;
            }//Мені це капець як НЕ ПОДОБАЄТЬСЯ
            //...але воно працює

            if (tmp_callsign == requested_user || tmp_callsign == "me")
            {
                Callsign.Text = tmp_callsign;
                Team.Text = MySQL_repository.MySQLselect_string("SELECT team FROM players WHERE name = '" + tmp_callsign + "'");
                Camo.Text = MySQL_repository.MySQLselect_string("SELECT camo FROM players WHERE name = '" + tmp_callsign + "'");
                string temp = (MySQL_repository.MySQLselect_string("SELECT rate FROM players WHERE name = '" + tmp_callsign + "'"));
                Rate.Rating = float.Parse(temp);
            }
            else
            {
                Callsign.Text = requested_user;
                Team.Text = MySQL_repository.MySQLselect_string("SELECT team FROM players WHERE name = '" + requested_user + "'");
                Camo.Text = MySQL_repository.MySQLselect_string("SELECT camo FROM players WHERE name = '" + requested_user + "'");
                string temp = (MySQL_repository.MySQLselect_string("SELECT rate FROM players WHERE name = '" + requested_user + "'"));
                Rate.Rating = float.Parse(temp);
            }
        }

        
    }


}