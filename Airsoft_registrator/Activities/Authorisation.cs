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
using Airsoft_registrator.Realm_;

namespace Airsoft_registrator.Activities
{
    [Activity(Label = "Authorisation", MainLauncher = true)]
    public class Authorisation : Activity
    {
        private Button mButtonSignUp, mButtonSignIn;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Authorisation);
            MySQL.MySQL_repository.MySQLcon();
            mButtonSignIn = FindViewById<Button>(Resource.Id.btn_sign_in);
            mButtonSignUp = FindViewById<Button>(Resource.Id.btn_sign_up);

            mButtonSignIn.Click += MButtonSignIn_Click;
            mButtonSignUp.Click += (object sender, EventArgs args) =>
            {
                //pull up dialog
                    FragmentTransaction transaction = FragmentManager.BeginTransaction();
                    DialogSignUp signupDialog = new DialogSignUp();
                    signupDialog.Show(transaction, "dialog fragment");

                    signupDialog.mOnSignUpComplete += SignupDialog_mOnSignUpComplete;
            };
        }

        private void MButtonSignIn_Click(object sender, EventArgs e)
        {
            //Знаю, страшний костиль, але нічого краще я не придумав
            var realm = Realm.GetInstance();
            var CurrentUser = realm.All<Realm_user>().Where(d=>d.Status=="LogIn");
            foreach(var val in CurrentUser)
            {
                
            }
            if (CurrentUser.Count()!=1)
            {
                FragmentTransaction transaction = FragmentManager.BeginTransaction();
                DialogSignIn signinDialog = new DialogSignIn();
                signinDialog.Show(transaction, "dialog fragment");
            }
            else StartActivity(typeof(MainActivity));
        }

        private void SignupDialog_mOnSignUpComplete(object sender, OnSignUpEventArgs e)
        {
            string query = "INSERT INTO airsoft_rush.players(name,team,camo) VALUES('" + e.Callsign + "','" + e.Team + "','" + e.Team + "')";
            MySQL.MySQL_repository.MySQLquery(query);
        }
    }
}