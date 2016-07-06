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
    [Activity(Label = "ChartsActivity")]
    public class ChartsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Charts);

            Button button1 = FindViewById<Button>(Resource.Id.AmountChartButton);
            button1.Click += Button1_Click;

            Button button3 = FindViewById<Button>(Resource.Id.DistributionChartButton);
            button3.Click += Button3_Click;

            Button button4 = FindViewById<Button>(Resource.Id.SpecificNeighborhoodButton);
            button4.Click += Button4_Click;

            Button button5 = FindViewById<Button>(Resource.Id.DistributionChartButton2);
            button5.Click += Button5_Click;

            Button button6 = FindViewById<Button>(Resource.Id.NeighborhoodButton2);
            button6.Click += Button6_Click;
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(FirstBarChart));
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(SecondPieChart));
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(SecondBarChart));
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(FirstPieChart));
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(LineChart));
        }
    }
}