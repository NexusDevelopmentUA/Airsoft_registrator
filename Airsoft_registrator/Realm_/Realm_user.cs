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
using Realms;
namespace Airsoft_registrator.Realm_
{
    class Realm_user:RealmObject
    {
        public string Callsign { get; set; }
        public string Password { get; set; }
    }
}