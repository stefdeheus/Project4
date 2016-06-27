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
    [Activity(Label = "NoteActivity")]
    public class NoteActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Note);

            // Create your application here
            Button button = FindViewById<Button>(Resource.Id.SaveButton);
            button.Click += Button_Click;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
        }
    }
}