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
    [Activity(Label = "AmountChartActivity")]
    public class LineChart : AbstractActivity
    {
        PlotView plotView;
        Factory dp;
        Graph grafiek;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            //intanciates factory and graph
            dp = new lineFac();
            grafiek = dp.create();
            //plots the graph
            plotView = new PlotView(this);
            plotView.Model = grafiek.CreatePlot();

            this.AddContentView(plotView,
            new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 1200));

        }
    }
}