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
    [Activity(Label = "NeighborhoodChart")]
    public class FirstBarChart : AbstractActivity
    {
        PlotView plotView;
        Factory dp;
        Graph grafiek;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            //instanciates factory
            dp = new BarFacFac1();
            //create graph
            grafiek = dp.create();

            plotView = new PlotView(this);
            //plots the graph
            plotView.Model = grafiek.CreatePlot();

            this.AddContentView(plotView,
            new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent));


        }
    }
}