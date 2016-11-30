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
using Android.Support.V4.Widget;
using Android.Support.V4.App;

namespace Airsoft_registrator.Activities
{
    [Activity(Label = "Menu")]
    public class Menu : Activity
    {
        DrawerLayout mDrawerLayout;
        List<string> mLeftItems = new List<string>();
        ArrayAdapter mLeftAdapter;
        ListView mLeftDrawer;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Menu);
            mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.myDrawer);
            mLeftDrawer = FindViewById<ListView>(Resource.Id.leftListView);

            var activity = typeof(User_Profile);
            Drawer menu = new Drawer();
            //gv = FindViewById<GridView>(Resource.Id.gridview);

        }
    }
}