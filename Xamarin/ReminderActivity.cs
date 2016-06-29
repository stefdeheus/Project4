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

namespace Xamarin
{
    [Activity(Label = "ReminderActivity")]
    public class ReminderActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Reminder);

            Button button1 = FindViewById<Button>(Resource.Id.SaveButton);
            button1.Click += Button1_Click;
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
        }
    }
}