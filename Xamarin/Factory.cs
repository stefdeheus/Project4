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
    //all our factories

    interface Factory
    {
        Graph create();
    }

    class lineFac : Factory
    {
        public Graph create()
        {
            return new Line();
        }
    }

    abstract class abstractBarFac : Factory
    {
        public abstract Graph create();
    }

    class BarFacFac1 : abstractBarFac
    {
        public override Graph create()
        {
            return new Bar();
        }
    }

    class BarFacFac2 : abstractBarFac
    {
        public override Graph create()
        {
            return new Bar2();
        }
    }

    abstract class abstractPieFac : Factory
    {
        public abstract Graph create();
    }

    class PieFacFac1 : abstractPieFac
    {
        public override Graph create()
        {
            return new Pie();
        }
    }

    class PieFacFac2 : abstractPieFac
    {
        public override Graph create()
        {
            return new Pie2();
        }
    }
}