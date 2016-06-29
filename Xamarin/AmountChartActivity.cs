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
    public class AmountChartActivity : Activity
    {
        PlotView plotView;
        Factory dp;
        Graph grafiek;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            dp = new Factory();
            grafiek = dp.Create(1);

            plotView = new PlotView(this);
            plotView.Model = grafiek.CreatePlot();

            this.AddContentView(plotView,
            new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent));

        }
    }
}