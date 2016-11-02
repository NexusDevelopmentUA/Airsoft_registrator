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
    class DialogSignUp:DialogFragment
    {
        private EditText mTextCallSign, mTextTeam;
        private Button mSignUp;

        public event EventHandler<OnSignUpEventArgs> mOnSignUpComplete;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.DialogSignUp, container, false);

            mTextCallSign = view.FindViewById<EditText>(Resource.Id.txtFirstName);
            mTextTeam = view.FindViewById<EditText>(Resource.Id.txtEmail);
            mSignUp = view.FindViewById<Button>(Resource.Id.btnDialogEmail);

            mSignUp.Click += MSignUp_Click;
            return view;
        }

        private void MSignUp_Click(object sender, EventArgs e)
        {
            mOnSignUpComplete.Invoke(this, new OnSignUpEventArgs(mTextCallSign.Text, mTextTeam.Text));
            this.Dismiss();
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnActivityCreated(savedInstanceState);
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation;
        }
    }
    public class OnSignUpEventArgs:EventArgs
    {
        private string mCallsign;
        private string mTeam;

        public string Callsign
        {
            get { return mCallsign; }
            set { mCallsign = value; }
        }

        public string Team
        {
            get { return mTeam; }
            set { mTeam = value; }
        }

        public OnSignUpEventArgs(string callsign, string team):base()
        {
            Callsign = callsign;
            Team = team;
        }
    }
}