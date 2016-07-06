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

namespace Xamarin
{
    abstract class AbstractBar : Graph
    {
        public abstract PlotModel CreatePlot();
    }
}