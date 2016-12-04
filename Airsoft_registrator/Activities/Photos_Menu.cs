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
using Airsoft_registrator;

namespace Airsoft_registrator.Activities
{
    [Activity(Label = "Фото меню", MainLauncher = true, Theme = "@style/MyTheme.Main")]
    public class Photos_Menu : Activity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.PhotosMenu);

            this.ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
            AddTab("Додати фото", Resource.Drawable.upload_icon, new PhotosUpload());

            AddTab("Завантажити фото", Resource.Drawable.download_icon, new PhotosDownload());

            if (savedInstanceState != null)

                this.ActionBar.SelectTab(this.ActionBar.GetTabAt(savedInstanceState.GetInt("tab")));
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            outState.PutInt("tab", this.ActionBar.SelectedNavigationIndex);

            base.OnSaveInstanceState(outState);
        }

        void AddTab(string tabText, int iconResourceId, Fragment view)
        {
            var tab = this.ActionBar.NewTab();
            tab.SetText(tabText);
            tab.SetIcon(iconResourceId);
            
            // must set event handler before adding tab
            tab.TabSelected += delegate (object sender, ActionBar.TabEventArgs e)
            {
                var fragment = this.FragmentManager.FindFragmentById(Resource.Id.fragmentContainer);

                if (fragment != null)
                    e.FragmentTransaction.Remove(fragment);
                e.FragmentTransaction.Add(Resource.Id.fragmentContainer, view);
            };

            tab.TabUnselected += delegate (object sender, ActionBar.TabEventArgs e) {
                e.FragmentTransaction.Remove(view);
            };
            this.ActionBar.AddTab(tab);
        }

        class PhotosUpload : Fragment
        {
            public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
            {
                base.OnCreateView(inflater, container, savedInstanceState);
                var view = inflater.Inflate(Resource.Layout.PhotosUpload, container, false);

                return view;
            }
        }

        class PhotosDownload : Fragment
        {
            ListView list;
            List<string> photos;

            public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
            {
                base.OnCreateView(inflater, container, savedInstanceState);
                photos = MySQL.MySQL_repository.MySQLselect("SELECT name FROM photos");

                var view = inflater.Inflate(Resource.Layout.Photos, container, false);
                list = view.FindViewById<ListView>(Resource.Id.listViewPhotos);
                PhotosListViewAdapter Adapter = new PhotosListViewAdapter(this, photos);
                list.Adapter = Adapter;
                return view;
            }
        }
    }
    class PhotosListViewAdapter:BaseAdapter<string>
    {
        private List<string> items;
        private Context context;

        public PhotosListViewAdapter(Fragment pcontext, List<string>photos)
        {
            items = photos;
            context = pcontext.Activity;
        }

        public override int Count
        {
            get
            {
                return items.Count();
            }
        }

        public override string this[int position]
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

            if(row==null)
            {
                row = LayoutInflater.From(context).Inflate(Resource.Layout.CustomViewPhotos, null, false);
            }

            TextView photos = row.FindViewById<TextView>(Resource.Id.photos_name);

            photos.Text = items[position];

            return row;
        }
    }
}