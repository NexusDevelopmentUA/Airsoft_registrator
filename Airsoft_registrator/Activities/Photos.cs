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
using Android.Webkit;
using static Airsoft_registrator.Resource;

namespace Airsoft_registrator.Activities
{
    [Activity(Label = "Скачати фото")]
    public class Photos : ListActivity
    {

        TextView tv;
        Button btn;
        View view;
        TableRow tr;
        TableLayout tl;
        List<string> photos;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            photos = MySQL.MySQL_repository.MySQLselect("SELECT name FROM photos");
            ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, photos);
        }
        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            string query = "SELECT link FROM photos WHERE name = '" + photos[position] + "';";
            string link = MySQL.MySQL_repository.MySQLselect_string(query);
            if (!link.StartsWith("http"))
            {
                link = "http://" + link;
            }

            Android.Net.Uri uri = Android.Net.Uri.Parse(link);
            Intent intent = new Intent(Intent.ActionView);
            intent.SetData(uri);

            Intent chooser = Intent.CreateChooser(intent, "Open with");

            this.StartActivity(chooser);
        }
    }
}