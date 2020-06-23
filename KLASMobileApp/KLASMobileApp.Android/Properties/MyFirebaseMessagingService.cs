using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Support.V4.App;
using Android.Util;
using Firebase.Messaging;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace KLASMobileApp.Droid.Properties
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class MyFirebaseMessagingService : FirebaseMessagingService
    {
        const string TAG = "MyFirebaseMsgService";
        public override void OnMessageReceived(RemoteMessage message)
        {
            Log.Debug(TAG, "From: " + message.From);
            Log.Debug(TAG, "Notification Message Body: " + message.GetNotification().Body);

            var body = message.GetNotification().Body;
            var title = message.GetNotification().Title;
            SendNotification(title ,body, message.Data);

            string alarm = Preferences.Get(Constants.Constants.Pref_Key_Alarm, "");
            if (alarm.Length > 0)
            {
                var list = JsonConvert.DeserializeObject<List<Data.AlarmData>>(alarm);
                var data = new Data.AlarmData();
                data.title = title;
                data.body = body;
                data.time = DateTime.Now.ToString("MM/dd hh:mm");
                list.Add(data);

                var str = JsonConvert.SerializeObject(list);

                Preferences.Set(Constants.Constants.Pref_Key_Alarm, str);
            }
            else
            {
                List<Data.AlarmData> list = new List<Data.AlarmData>();
                var data = new Data.AlarmData();
                data.title = title;
                data.body = body;
                data.time = DateTime.Now.ToString("MM/dd hh:mm");
                list.Add(data);

                var str = JsonConvert.SerializeObject(list);

                Preferences.Set(Constants.Constants.Pref_Key_Alarm, str);
            }
        }



        void SendNotification(string title ,string messageBody, IDictionary<string, string> data)
        {
            var intent = new Intent(this, typeof(MainActivity));
            intent.AddFlags(ActivityFlags.ClearTop);
            foreach (var key in data.Keys)
            {
                intent.PutExtra(key, data[key]);
            }

            var pendingIntent = PendingIntent.GetActivity(this,
                                                          MainActivity.NOTIFICATION_ID,
                                                          intent,
                                                          PendingIntentFlags.OneShot);

            var notificationBuilder = new NotificationCompat.Builder(this, MainActivity.CHANNEL_ID)
                                      .SetSmallIcon(Resource.Drawable.notification_icon_background)
                                      .SetContentTitle(title)
                                      .SetContentText(messageBody)
                                      .SetAutoCancel(true)
                                      .SetContentIntent(pendingIntent);

            var notificationManager = NotificationManagerCompat.From(this);
            notificationManager.Notify(MainActivity.NOTIFICATION_ID, notificationBuilder.Build());
        }
    }
}
