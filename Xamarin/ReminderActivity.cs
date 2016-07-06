using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Locations;
using Android.Provider;
using Uri = Android.Net.Uri;
using Android.Widget;
using Android.Runtime;
using System.Globalization;

namespace Xamarin
{
    [Activity(Label = "ReminderActivity")]
    public class ReminderActivity : Activity, ILocationListener
    {
        public string Positie;
        //Location currentLocation;
        LocationManager locationManager;
        public string locationProvider;
        double geolongitude;
        double geolatitude;


        public void OnLocationChanged(Location location)
        {
            this.geolatitude = location.Latitude;
            this.geolongitude = location.Longitude;
            Positie = $"{Geofix(geolatitude)}, {Geofix(geolongitude)}";
        }
        public static string Geofix(double value)
        {
            return value.ToString(CultureInfo.GetCultureInfo("en-GB"));
        }
        public void OnProviderDisabled(string provider)
        {
            
        }

        public void OnProviderEnabled(string provider)
        {
            
        }

        public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
        {
            
        }

        protected override void OnStart()
        {
            base.OnStart();
            locationManager = GetSystemService(Context.LocationService) as LocationManager;
            locationManager.RequestLocationUpdates(LocationManager.NetworkProvider, 2, 0, this);
        }

        protected override void OnResume()
        {
            base.OnResume();
            locationManager = GetSystemService(Context.LocationService) as LocationManager;
            locationManager.RequestLocationUpdates(LocationManager.NetworkProvider, 2, 0, this);
        }

        //
        protected override void OnPause()
        {
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
            Criteria criteriaForLocationService = new Criteria
            {
                Accuracy = Accuracy.Coarse,
                PowerRequirement = Power.Low
            };

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Reminder);

            // Create your application here
            var createappointment = FindViewById<Button>(Resource.Id.SaveButton);
            createappointment.Click += Createappointment_Click;
        }

        private void Createappointment_Click(object sender, EventArgs e)
        {
            var titelText           = FindViewById<EditText>(Resource.Id.editText);
            var descriptionText     = FindViewById<EditText>(Resource.Id.descriptionText);
            

            if (Positie == null){
                Positie = "positie kan niet gevonden worden";
            }

            Intent myIntent = new Intent(Intent.ActionInsert, Uri.Parse("content://com.android.calendar/events"));
            myIntent.PutExtra(CalendarContract.Events.InterfaceConsts.Title, titelText.Text);
            myIntent.PutExtra(CalendarContract.Events.InterfaceConsts.EventLocation, Positie);
            myIntent.PutExtra(CalendarContract.Events.InterfaceConsts.Description, descriptionText.Text);
            myIntent.PutExtra(CalendarContract.Events.InterfaceConsts.AllDay, "0");
            myIntent.PutExtra(CalendarContract.Events.InterfaceConsts.HasAlarm, "1");
            myIntent.PutExtra(CalendarContract.Events.InterfaceConsts.Id, "Optrommelen");
            myIntent.PutExtra(CalendarContract.Events.InterfaceConsts.Dtstart, DateTime.Now.ToString());
            myIntent.PutExtra(CalendarContract.Events.InterfaceConsts.Dtend, DateTime.Now.ToString());
            StartActivity(myIntent);
        }
    }
}