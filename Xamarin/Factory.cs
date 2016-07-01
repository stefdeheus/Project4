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

            else if (number == 2)
            {
                return new Pie();
            }

            else if (number == 3)
            {
                return new Pie2();
            }

            else if (number == 4)
            {
                return new Bar();
            }

            else if (number == 5)
            {
                return new Bar2();
            }

            else
            {
                return null;
            }
        }
    }
}