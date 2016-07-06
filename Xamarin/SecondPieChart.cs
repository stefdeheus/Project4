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
    [Activity(Label = "DistributionChartActivity2")]
    public class SecondPieChart : AbstractActivity
    {
        PlotView plotView;
        Factory dp;
        Graph grafiek;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            //instanciate factory and graph
            dp = new PieFacFac2();
            grafiek = dp.create();

            plotView = new PlotView(this);
            plotView.Model = grafiek.CreatePlot();
            //plots the graph

            this.AddContentView(plotView,
            new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent));
        }
    }
}