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
    [Activity(Label = "Photos_Menu", Theme = "@style/customTheme")]
    public class Photos_Menu : Activity
    {
        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //Button upload = FindViewById<Button>(Resource.Id.btn_upload);
            //Button download = FindViewById<Button>(Resource.Id.btn_download);

            //upload.Click += Upload_Click;
            //download.Click += Download_Click;
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

            public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)

            {
                base.OnCreateView(inflater, container, savedInstanceState);

                var view = inflater.Inflate(Resource.Layout.Photos, container, false);

                return view;
            }

        }

    }
}