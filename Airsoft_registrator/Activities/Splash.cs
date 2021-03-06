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
using Android.Support.V7.App;
using Android.Util;
using System.Threading.Tasks;
using Airsoft_registrator.Activities;
using Realms;
namespace Airsoft_registrator
{
    [Activity(Theme = "@style/MyTheme.Splash",  NoHistory = true)]
    public class SplashActivity : AppCompatActivity
    {
        static readonly string TAG = "X:" + typeof(SplashActivity).Name;

        public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
        {
            base.OnCreate(savedInstanceState, persistentState);
            
            Log.Debug(TAG, "SplashActivity.OnCreate");
        }

        protected override void OnResume()
        {
            base.OnResume();
            MySQL.MySQL_repository.MySQLcon();
            Task startupWork = new Task(() => {
                Log.Debug(TAG, "Performing some startup work that takes a bit of time.");
                Task.Delay(5000);  // Simulate a bit of startup work.
                Log.Debug(TAG, "Working in the background - important stuff.");
            });

            startupWork.ContinueWith(t => {
                Log.Debug(TAG, "Work is finished - start Activity1.");
                //StartActivity(new Intent(Application.Context, typeof(MainActivity)));
                //MySQL.MySQL_repository.MySQLcon();
                
                StartActivity(typeof(Authorisation));
            }, TaskScheduler.FromCurrentSynchronizationContext());

            var realm = Realm.GetInstance();
            realm.Write(() =>
            {
                realm.RemoveAll();
            });
            
            startupWork.Start();
        }
    }
}