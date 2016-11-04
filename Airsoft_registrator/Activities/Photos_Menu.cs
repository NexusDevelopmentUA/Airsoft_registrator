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
    [Activity(Label = "Photos_Menu")]
    public class Photos_Menu : Activity
    {
        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //Button upload = FindViewById<Button>(Resource.Id.btn_upload);
            //Button download = FindViewById<Button>(Resource.Id.btn_download);

            //upload.Click += Upload_Click;
            //download.Click += Download_Click;
        }

        private void Download_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(Photos));
        }

        private void Upload_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(Photos_upload));
        }
    }
}