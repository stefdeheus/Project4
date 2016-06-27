using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Xamarin
{
    [Activity(Label = "Optrommelen", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.NoteButton);
            button.Click += Button_Click;

            Button button2 = FindViewById<Button>(Resource.Id.MapButton);
            button2.Click += Button2_Click;

            Button button3 = FindViewById<Button>(Resource.Id.ChartsButton);
            button3.Click += Button3_Click;

            Button button4 = FindViewById<Button>(Resource.Id.ReminderButton);
            button4.Click += Button4_Click;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(ReminderActivity));
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(ChartsActivity));
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MapActivity));
        }

        private void Button_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(NoteActivity));
        }
    }
}

