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
    [Activity(Label = "Photos")]
    public class Photos : Activity
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

            SetContentView(Resource.Layout.Photos);

            photos = MySQL.MySQL_repository.MySQLselect("SELECT name FROM photos");
            tl = FindViewById<TableLayout>(Resource.Id.table_l);
            foreach (var item in photos)
            {
                TableLayout.LayoutParams lparams = new TableLayout.LayoutParams(ViewGroup.LayoutParams.FillParent, TableLayout.LayoutParams.WrapContent);
                TableRow.LayoutParams rparams = new TableRow.LayoutParams(ViewGroup.LayoutParams.FillParent, TableLayout.LayoutParams.WrapContent);
                tr = new TableRow(this);
                tr.LayoutParameters = rparams;

                view = new View(this);
                view.LayoutParameters = new TableRow.LayoutParams(ViewGroup.LayoutParams.MatchParent, 2);
                view.SetBackgroundColor(Android.Graphics.Color.Black);

                tv = new TextView(this);
                tv.LayoutParameters = new TableRow.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent);
                tv.Text = item;
                tr.AddView(tv);

                btn = new Button(this);
                btn.LayoutParameters = new TableRow.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent);
                btn.Text = "Download";
                tr.AddView(btn);

                tl.AddView(tr, lparams);
                tl.AddView(view);
            }

            btn.Click += Btn_Click;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Console.WriteLine("HELLO");
            Toast.MakeText(this, "HELLO", ToastLength.Short);
            string query = "SELECT link FROM photos WHERE name = '"+tv.Text+"';";
            string link = MySQL.MySQL_repository.MySQLselect_string(query);
            var uri = Android.Net.Uri.Parse(link);
            var intent = new Intent(Intent.ActionView, uri);
            WebView wview = new WebView(this);

            wview.Settings.JavaScriptEnabled = true;
            wview.LoadUrl(link);

        }
    }
}