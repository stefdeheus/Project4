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
using Android.Locations;
using Uri = Android.Net.Uri;

namespace Xamarin
{
    [Activity(Label = "MapActivity")]
    public class MapActivity : Activity, ILocationListener
    {
        LocationManager locationManager;
        public string locationProvider;
        double geolongitude;
        double geolatitude;
        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Map);
            locationManager = (LocationManager)GetSystemService(LocationService);

            //Geef een criteria waar je device aan moet voldoen
            Criteria criteriaForLocationService = new Criteria
            {
                Accuracy = Accuracy.Coarse,
                PowerRequirement = Power.Low
            };

            // Create your application here
            var geoUri = Uri.Parse($"geo:{geolatitude},{geolongitude}");
            var mapIntent = new Intent(Intent.ActionView, geoUri);
            StartActivity(mapIntent);
        }

        public void OnLocationChanged(Location location)
        {
            this.geolatitude = location.Latitude;
            this.geolongitude = location.Longitude;
            //Positie = $"{Geofix(geolatitude)}, {Geofix(geolongitude)}";
        }

        public void OnProviderDisabled(string provider)
        {
            throw new NotImplementedException();
        }

        public void OnProviderEnabled(string provider)
        {
            throw new NotImplementedException();
        }

        public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
        {
            throw new NotImplementedException();
        }
    }
}