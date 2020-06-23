using System;
using Android.App;
using Android.Util;
using Firebase.Iid;
using Xamarin.Essentials;

namespace KLASMobileApp.Droid.Properties
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.INSTANCE_ID_EVENT" })]
    public class MyFirebaseIIDService : FirebaseInstanceIdService
    {
        const string TAG = "MyFirebaseIIDService";

        [Obsolete]
        public override void OnTokenRefresh()
        {
            var refreshedToken = FirebaseInstanceId.Instance.Token;
            Log.Debug(TAG, "Refreshed token: " + refreshedToken);
            SendRegistrationToServer(refreshedToken);
        }
        void SendRegistrationToServer(string token)
        {
            Preferences.Set(Constants.Constants.Pref_Key_FcmToken, token);
        }
    }
}
