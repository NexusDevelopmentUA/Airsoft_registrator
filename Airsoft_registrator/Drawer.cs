using System.Collections.Generic;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Widget;
using Android.Support.V4.App;
using Android.Views;

namespace Airsoft_registrator
{
    public class Drawer : Activity
    {

        DrawerLayout mDrawerLayout;
        List<string> mLeftItems;
        ListView mLeftDrawer;
        ArrayAdapter mLeftAdapter;
        ActionBarDrawerToggle mDrawerToggle;

        public void drawer(DrawerLayout drawerlayout, List<string> items, ListView drawler, Context context, Activity activity)
        {
            DrawerLayout mDrawerLayout = drawerlayout;
            List<string> mLeftItems = items;
            ListView mLeftDrawer = drawler;
            ActionBarDrawerToggle mDrawerToggle;

            mDrawerToggle = new MyActionBarDrawerToggle(activity, mDrawerLayout, Resource.Drawable.ic_navigation_drawer, Resource.String.open_drawer, Resource.String.close_drawer);

            mLeftAdapter = new ArrayAdapter(context, Android.Resource.Layout.SimpleListItem1, mLeftItems);
            mLeftDrawer.Adapter = mLeftAdapter;

            mDrawerLayout.SetDrawerListener(mDrawerToggle);
            activity.ActionBar.SetDisplayHomeAsUpEnabled(true);
            activity.ActionBar.SetHomeButtonEnabled(true);
            activity.ActionBar.SetDisplayShowTitleEnabled(true);
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
}