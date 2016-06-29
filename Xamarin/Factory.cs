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

namespace Xamarin
{
    class Factory
    {
        public Graph Create(int number)
        {
            if (number == 1)
            {
                return new Line();
            }

            else
            {
                return null;
            }
        }
    }
}