using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Provider;
using Uri = Android.Net.Uri;
using Android.Widget;

namespace Xamarin
{
    [Activity(Label = "ReminderActivity")]
    public class ReminderActivity : AbstractActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Reminder);
            var createappointment = FindViewById(Resource.Id.SaveButton);
 
            createappointment.Click += Createappointment_Click;
        }
        private void Createappointment_Click(object sender, EventArgs e)
        {
            var titelText = FindViewById<EditText>(Resource.Id.editText);
            var eventLocationText = FindViewById<EditText>(Resource.Id.EventLocationText);
            var descriptionText = FindViewById<EditText>(Resource.Id.DescriptionText);

            Intent myIntent = new Intent(Intent.ActionInsert, Uri.Parse("content://com.android.calendar/events"));
            myIntent.PutExtra(CalendarContract.Events.InterfaceConsts.Title, titelText.Text);
            myIntent.PutExtra(CalendarContract.Events.InterfaceConsts.EventLocation, eventLocationText.Text);
            myIntent.PutExtra(CalendarContract.Events.InterfaceConsts.Description, descriptionText.Text);
            myIntent.PutExtra(CalendarContract.Events.InterfaceConsts.AllDay, "0");
            myIntent.PutExtra(CalendarContract.Events.InterfaceConsts.HasAlarm, "1");
            myIntent.PutExtra(CalendarContract.Events.InterfaceConsts.Dtstart, DateTime.Now.ToString());
            myIntent.PutExtra(CalendarContract.Events.InterfaceConsts.Dtend, DateTime.Now.ToString());
            StartActivity(myIntent);
        }
    }
}