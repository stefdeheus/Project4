using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Android.Locations;
using Android.Provider;
using Android.Runtime;
using System.Globalization;
using System.Collections.Generic;

namespace Xamarin
{
    [Activity(Label = "NoteActivity")]
    public class NoteActivity : Activity, ILocationListener
    {
        public string Positie;
        //Location currentLocation;
        LocationManager locationManager;
        public string locationProvider;
        double geolongitude;
        double geolatitude;
        public IList<Address> addresses;


        //On Change Location
        public void OnLocationChanged(Location location)
        {
            this.geolatitude = location.Latitude;
            this.geolongitude = location.Longitude;
            Positie = $"{Geofix(geolatitude)}, {Geofix(geolongitude)}";

            var geo = new Geocoder(this);
            addresses = geo.GetFromLocation(geolatitude, geolongitude, 1);
            
        }
        // Fix the comma to dot in a string
        public static string Geofix(double value) {
            return value.ToString(CultureInfo.GetCultureInfo("en-GB"));
        }
        //Overide Location functions
        public void OnProviderDisabled(string provider) { }
        public void OnProviderEnabled(string provider) { }
        public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras) {}
        //End overide

        //On Start activity 
        protected override void OnStart() {
            var geo = new Geocoder(this);
            addresses = geo.GetFromLocation(geolatitude, geolongitude, 1);
            base.OnStart();
            locationManager = GetSystemService(Context.LocationService) as LocationManager;
            locationManager.RequestLocationUpdates(LocationManager.NetworkProvider, 2, 0, this);
        }

        //On Resume activity 
        protected override void OnResume(){
            var geo = new Geocoder(this);
            addresses = geo.GetFromLocation(geolatitude, geolongitude, 1);
            base.OnResume();
            locationManager = GetSystemService(Context.LocationService) as LocationManager;
            locationManager.RequestLocationUpdates(LocationManager.NetworkProvider, 2, 0, this);
        }

        //On Pause activity 
        protected override void OnPause() {
            base.OnPause();
            locationManager.RemoveUpdates(this);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here
            // Vraag de locatie op van je device
            locationManager = (LocationManager)GetSystemService(LocationService);

            //Geef een criteria waar je device aan moet voldoen
            Criteria criteriaForLocationService = new Criteria {
                Accuracy = Accuracy.Coarse,
                PowerRequirement = Power.Low
            };

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Note);

            // Create your application here
            Button button = FindViewById<Button>(Resource.Id.SaveButton);
            button.Click += Button_Click;
        }

        // create button click
        private void Button_Click(object sender, EventArgs e)
        {
            ShareIt();
        }

        private void ShareIt()
        {
            // Edit text from axml
            var descriptionNote = FindViewById<EditText>(Resource.Id.NotitieTextt).Text;
            
            string Combi = $"{descriptionNote}, Staat Op locatie: ,{addresses[0].Thoroughfare}";

            Intent sharingIntent = new Intent(global::Android.Content.Intent.ActionSend);
            sharingIntent.SetType("text/plain");
            
            // String hieronder wordt doorgegeven aan notitie. Hier moet dus geolocatie/straatnaam in

            sharingIntent.PutExtra(global::Android.Content.Intent.ExtraText, descriptionNote);
            sharingIntent.PutExtra(global::Android.Content.Intent.ExtraText, Combi);

            StartActivity(Intent.CreateChooser(sharingIntent, "Share via"));

        }
    }
}