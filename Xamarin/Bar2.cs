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
    class Bar2 : Graph
    {
        public PlotModel CreatePlot()
        {
            var model = new PlotModel
            {
                Title = "The amount of stolen bicycles and amount of installed bicycle containers per month given a specific neighborhood",
                LegendPlacement = LegendPlacement.Outside,
                LegendPosition = LegendPosition.BottomCenter,
                LegendOrientation = LegendOrientation.Horizontal,
                LegendBorderThickness = 0
            };

            var s1 = new BarSeries { Title = "Amount of installed bicycle containers", StrokeColor = OxyColors.Black, StrokeThickness = 1 };
            s1.Items.Add(new BarItem { Value = 25 });
            s1.Items.Add(new BarItem { Value = 137 });
            s1.Items.Add(new BarItem { Value = 18 });
            s1.Items.Add(new BarItem { Value = 40 });
            s1.Items.Add(new BarItem { Value = 20 });
            s1.Items.Add(new BarItem { Value = 25 });
            s1.Items.Add(new BarItem { Value = 137 });
            s1.Items.Add(new BarItem { Value = 18 });
            s1.Items.Add(new BarItem { Value = 40 });
            s1.Items.Add(new BarItem { Value = 20 });
            s1.Items.Add(new BarItem { Value = 40 });
            s1.Items.Add(new BarItem { Value = 20 });

            var s2 = new BarSeries { Title = "Amount of stolen bicycles", StrokeColor = OxyColors.Black, StrokeThickness = 1 };
            s2.Items.Add(new BarItem { Value = 25 });
            s2.Items.Add(new BarItem { Value = 137 });
            s2.Items.Add(new BarItem { Value = 18 });
            s2.Items.Add(new BarItem { Value = 40 });
            s2.Items.Add(new BarItem { Value = 20 });
            s2.Items.Add(new BarItem { Value = 25 });
            s2.Items.Add(new BarItem { Value = 137 });
            s2.Items.Add(new BarItem { Value = 18 });
            s2.Items.Add(new BarItem { Value = 40 });
            s2.Items.Add(new BarItem { Value = 20 });
            s2.Items.Add(new BarItem { Value = 40 });
            s2.Items.Add(new BarItem { Value = 20 });

            var categoryAxis = new CategoryAxis { Position = AxisPosition.Left };
            categoryAxis.Labels.Add("Neighborhood 1, January");
            categoryAxis.Labels.Add("Neighborhood 2, February");
            categoryAxis.Labels.Add("Neighborhood 3, March");
            categoryAxis.Labels.Add("Neighborhood 4, April");
            categoryAxis.Labels.Add("Neighborhood 5, May");
            categoryAxis.Labels.Add("Neighborhood 6, June");
            categoryAxis.Labels.Add("Neighborhood 7, July");
            categoryAxis.Labels.Add("Neighborhood 8, August");
            categoryAxis.Labels.Add("Neighborhood 9, Septembre");
            categoryAxis.Labels.Add("Neighborhood 10, October");
            categoryAxis.Labels.Add("Neighborhood 11, November"); 
            categoryAxis.Labels.Add("Neighborhood 12, December");

            var valueAxis = new LinearAxis { Position = AxisPosition.Bottom, MinimumPadding = 0, MaximumPadding = 0.06, AbsoluteMinimum = 0 };
            model.Series.Add(s1);
            model.Series.Add(s2);
            model.Axes.Add(categoryAxis);
            model.Axes.Add(valueAxis);

            return model;
        }
    }
}