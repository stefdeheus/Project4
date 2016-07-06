using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Geolocator.Plugin;



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
            ShareIt();
        }

        private async void ShareIt()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;

            var position = await locator.GetPositionAsync(timeoutMilliseconds: 10000);
            

            Intent sharingIntent = new Intent(global::Android.Content.Intent.ActionSend);
            sharingIntent.SetType("text/plain");
            // String hieronder wordt doorgegeven aan notitie. Hier moet dus geolocatie/straatnaam in
            string toShare = "Haalllo"; 
            sharingIntent.PutExtra(global::Android.Content.Intent.ExtraText, toShare);

            StartActivity(Intent.CreateChooser(sharingIntent, "Share via"));

        }
    }
}