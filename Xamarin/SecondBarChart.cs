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
    public class SecondBarChart : AbstractActivity
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
            //the spinner is the dropdown menu
            Spinner spinner = FindViewById<Spinner>(Resource.Id.spinner1);
            spinner.ItemSelected += Spinner_ItemSelected;
            var adapter = ArrayAdapter.CreateFromResource(
                this, Resource.Array.Deelgemeente, global::Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(global::Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = adapter;
            //instanciate factory and graph
            dp = new BarFacFac2();
            grafiek = dp.create();

            this.plotView = FindViewById<PlotView>(Resource.Id.bar2);
            plotView.Model = grafiek.CreatePlot();
            


            
        }
        //sends attribute name to the graph and plots it when spinner is used
        public void Spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            deelGemeente = spinner.GetItemAtPosition(e.Position).ToString();
            
            plotView.Model = grafiek.CreatePlot();
            Console.WriteLine(  );
        }
    }
}