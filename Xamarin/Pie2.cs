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
using OxyPlot;
using OxyPlot.Series;

namespace Xamarin
{
    class Pie2 : Graph
    {
        public PlotModel CreatePlot()
        {
            PlotModel plot;
            PieSeries series;

            plot = new PlotModel { Title = "Most stolen bicycle colors" };

            series = new PieSeries
            {
                StrokeThickness = 0.5,
                InsideLabelPosition = 0.8,
                AngleSpan = 360,
                StartAngle = 0
            };

            series.Slices.Add(new PieSlice("Blue bicycles", 1030) { IsExploded = false, Fill = OxyColors.PaleVioletRed });
            series.Slices.Add(new PieSlice("Red bicycles", 929) { IsExploded = true });
            series.Slices.Add(new PieSlice("Yellow bicycles", 929) { IsExploded = true });
            series.Slices.Add(new PieSlice("Black bicycles", 929) { IsExploded = true });

            plot.Series.Add(series);

            return plot;
        }
    }
}