using System.Collections.Generic;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Widget;
using Android.Support.V4.App;
using Android.Views;
using System;
using Airsoft_registrator.Activities;

namespace Airsoft_registrator
{
    public class Drawer : Activity
    {

        DrawerLayout mDrawerLayout;
        List<string> mLeftItems;
        ListView mLeftDrawer;
        ArrayAdapter mLeftAdapter;
        ActionBarDrawerToggle mDrawerToggle;
        string CurrentViewName;

        public void drawer(DrawerLayout drawerlayout, string pCurrentViewName, ListView drawler, Context context, Activity activity)
        {
            SetContentView(Resource.Layout.Main);
            DrawerLayout mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.testDrawer);
            List<string> mLeftItems = new List<string>();
            ListView mLeftDrawer = drawler;
            ActionBarDrawerToggle mDrawerToggle;
            CurrentViewName = pCurrentViewName;
            mLeftDrawer = new ListView(context);
            string[] set =
            {
                "Список ігор",
                "Додати гру",
                "Фото",
                "Профіль користувача"
            };
            mLeftItems.AddRange(set);
            mLeftAdapter = new ArrayAdapter(context, Android.Resource.Layout.SimpleListItem1, mLeftItems);
            mLeftDrawer.Adapter = mLeftAdapter;
            mLeftDrawer.ItemClick += MLeftDrawer_ItemClick;
            mDrawerToggle = new MyActionBarDrawerToggle(activity, mDrawerLayout, Resource.Drawable.ic_navigation_drawer, Resource.String.open_drawer, Resource.String.close_drawer);
            mDrawerLayout.SetDrawerListener(mDrawerToggle);
            activity.ActionBar.SetDisplayHomeAsUpEnabled(true);
            activity.ActionBar.SetHomeButtonEnabled(true);
            activity.ActionBar.SetDisplayShowTitleEnabled(true);
        }

        private void MLeftDrawer_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            if(mLeftItems[e.Position]!=CurrentViewName)
            switch(mLeftItems[e.Position])
            {
                    case "Список ігор":
                    {
                            StartActivity(typeof(MainActivity));
                        break;
                    }
                    case "Додати гру":
                        {
                            StartActivity(typeof(Create_Game));
                            break;
                        }
                    case "Фото":
                        {
                            StartActivity(typeof(Photos_Menu));
                            break;
                        }
                    case "Профіль користувача":
                        {
                            StartActivity(typeof(User_Profile));
                            break;
                        }
                }
        }

        protected override void OnPostCreate(Bundle savedInstanceState)
        {
            base.OnPostCreate(savedInstanceState);
            mDrawerToggle.SyncState();
        }

        public override void OnConfigurationChanged(Android.Content.Res.Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);
            mDrawerToggle.OnConfigurationChanged(newConfig);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.action_bar, menu);
            return base.OnCreateOptionsMenu(menu);
        }

    }

    abstract class State
    {
        public abstract void Handle();
    }
}