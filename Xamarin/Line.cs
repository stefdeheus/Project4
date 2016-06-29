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
using OxyPlot.Axes;
using OxyPlot.Series;

namespace Xamarin
{
    class Line : Graph
    {
        PlotModel plot;
        LineSeries series;
        public PlotModel CreatePlot()
        {
            plot = new PlotModel
            {
                Title = "Amount of stolen bicycles per month"
            };

            plot.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom });
            plot.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Maximum = 10, Minimum = 0 });

            series = new LineSeries
            {
                MarkerType = MarkerType.Circle,
                MarkerSize = 4,
                MarkerStroke = OxyColors.White
            };

            series.Points.Add(new DataPoint(0.0, 6.0));
            series.Points.Add(new DataPoint(1.4, 2.1));
            series.Points.Add(new DataPoint(2.0, 4.2));
            series.Points.Add(new DataPoint(3.3, 2.3));
            series.Points.Add(new DataPoint(4.7, 7.4));
            series.Points.Add(new DataPoint(6.0, 6.2));
            series.Points.Add(new DataPoint(8.9, 8.9));

            plot.Series.Add(series);

            return plot;
        }
    }
}