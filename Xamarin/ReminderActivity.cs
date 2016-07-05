using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Provider;
using Uri = Android.Net.Uri;

namespace Xamarin
{
    [Activity(Label = "ReminderActivity")]
    public class ReminderActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Reminder);
            var createappointment = FindViewById(Resource.Id.SaveButton);
            var editText = FindViewById(Resource.Id.editText);
            var textView = FindViewById(Resource.Id.textView);
            createappointment.Click += Createappointment_Click;
        }
        //editText.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {
        //       textView.Text = e.Text.ToString ();
        //};
    private void Createappointment_Click(object sender, EventArgs e)
        {
            Intent myIntent = new Intent(Intent.ActionInsert, Uri.Parse("content://com.android.calendar/events"));
            myIntent.PutExtra(CalendarContract.Events.InterfaceConsts.Title, "Je fiets optrommelen.");
            myIntent.PutExtra(CalendarContract.Events.InterfaceConsts.EventLocation, "Wijnhaven 107");
            myIntent.PutExtra(CalendarContract.Events.InterfaceConsts.Description, "Calendar Intent To Insert an new event.");
            myIntent.PutExtra(CalendarContract.Events.InterfaceConsts.AllDay, "0");
            myIntent.PutExtra(CalendarContract.Events.InterfaceConsts.HasAlarm, "1");
            myIntent.PutExtra(CalendarContract.Events.InterfaceConsts.Dtstart, DateTime.Now.ToString());
            myIntent.PutExtra(CalendarContract.Events.InterfaceConsts.Dtend, DateTime.Now.ToString());
            StartActivity(myIntent);
        }
    }
}