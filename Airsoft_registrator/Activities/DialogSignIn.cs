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
    public class DialogSignIn : DialogFragment
    {

        private EditText mTextCallSign, mPass;
        private Button mSignIn;

        public event EventHandler<OnSignInEventArgs> mOnSignInComplete;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.DialogSignIn, container, false);

            mTextCallSign = view.FindViewById<EditText>(Resource.Id.txt—allsignIn);
            mPass = view.FindViewById<EditText>(Resource.Id.txtPasswordIn);
            mSignIn = view.FindViewById<Button>(Resource.Id.btnDialogSignIn);

            mSignIn.Click += MSignIn_Click;
            return view;
        }

        private void MSignIn_Click(object sender, EventArgs e)
        {
            mOnSignInComplete.Invoke(this, new OnSignInEventArgs(mTextCallSign.Text, mPass.Text));
            this.Dismiss();
            //var intent = new Intent(Activity, typeof(Menu));
            //StartActivity(intent);
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnActivityCreated(savedInstanceState);
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation;
        }
    }

    public class OnSignInEventArgs:EventArgs
    {
        private string mCallsign;
        private string mPass;

        public string Callsign
        {
            get { return mCallsign; }
            set { mCallsign = value; }
        }

        public string Pass
        {
            get { return mPass; }
            set { mPass = value; }
        }

        public OnSignInEventArgs(string callsign, string pass):base()
        {
            Callsign = callsign;
            Pass = pass;
        }

    }
}