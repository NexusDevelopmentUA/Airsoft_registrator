using System;

using Android.App;
using Android.OS;
using Android.Widget;
using Android.Support.V4.Widget;

namespace Airsoft_registrator.Activities
{
    [Activity(Label = "Create_Game")]
    public class Create_Game : Activity
    {
        Button add;
        TextView location, name, date;
        DrawerLayout mDrawerLayout;
        ListView mLeftDrawer;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            string activity_name = "Додати гру";

            SetContentView(Resource.Layout.CreateGame);

            mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.myDrawerCG);
            mLeftDrawer = FindViewById<ListView>(Resource.Id.leftListViewCG);
            Drawer menu = new Drawer();
            menu.drawer(mDrawerLayout, activity_name, mLeftDrawer, this, this);

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