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
    [Activity(Label = "Authorisation")]
    public class Authorisation : Activity
    {
        private Button mButtonSignUp, mButtonSignIn;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Authorisation);

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
            MySQL.MySQL_repository.MySQLcon();
            StartActivity(typeof(Photos));
        }

        private void SignupDialog_mOnSignUpComplete(object sender, OnSignUpEventArgs e)
        {
            string query = "INSERT INTO airsoft_rush.players(name,team,camo) VALUES('" + e.Callsign + "','" + e.Team + "','" + e.Team + "')";
            MySQL.MySQL_repository.MySQLquery(query);
        }
    }
}