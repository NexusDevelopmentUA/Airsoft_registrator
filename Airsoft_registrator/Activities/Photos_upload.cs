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
    [Activity(Label = "Photos_upload")]
    public class Photos_upload : Activity
    {
        Button upload;
        EditText name, link;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.PhotosUpload);

            upload = FindViewById<Button>(Resource.Id.btn_PhotosUpload);
            upload.Click += Upload_Click;
            name = FindViewById<EditText>(Resource.Id.txt_name);
            link = FindViewById<EditText>(Resource.Id.txt_link);

        }

        private void Upload_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO photos(name,link) VALUES ('"+name.Text+"','"+link.Text+"')";
            MySQL.MySQL_repository.MySQLquery(query);
        }
    }
}