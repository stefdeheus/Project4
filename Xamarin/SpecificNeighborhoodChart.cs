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

using OxyPlot.Xamarin.Android;

namespace Xamarin
{
    [Activity(Label = "SpecificNeighborhoodChart")]
    public class SpecificNeighborhoodChart : Activity
    {
        PlotView plotView;
        Factory dp;
        Graph grafiek;
        public static string deelGemeente;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SpecificNeighborhood);
            // Create your application here
            deelGemeente = "'Feijenoord'";
            Spinner spinner = FindViewById<Spinner>(Resource.Id.spinner1);
            spinner.ItemSelected += Spinner_ItemSelected;
            var adapter = ArrayAdapter.CreateFromResource(
                this, Resource.Array.Deelgemeente, global::Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(global::Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = adapter;

            dp = new Factory();
            grafiek = dp.Create(5);

            this.plotView = FindViewById<PlotView>(Resource.Id.bar2);
            plotView.Model = grafiek.CreatePlot();
            


            //plotView = new PlotView(this);
            //plotView.Model = grafiek.CreatePlot();


            //this.AddContentView(plotView,
            //new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent));
        }

        public void Spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            deelGemeente = spinner.GetItemAtPosition(e.Position).ToString();
            
            plotView.Model = grafiek.CreatePlot();
            Console.WriteLine(  );
        }
    }
}