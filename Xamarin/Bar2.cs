using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Renderscripts;
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







            string sdwConnectionString =
               @"Server = tcp:infproj4.database.windows.net,1433; Data Source = infproj4.database.windows.net; Initial Catalog = FietstrommelProject; Persist Security Info = False; User ID = raymundo; Password = 97475Thy!; MultipleActiveResultSets = False; Connection Timeout = 30;";

            var sdwDBConnection = new SqlConnection(sdwConnectionString);
            sdwDBConnection.Open();
            string querydiefstal = @"
                           SELECT DATENAME(mm, newKennisname) AS Maand, DATENAME(yyyy, newKennisname) AS Jaar, w.Deelgemeenten, COUNT(*) AS Aantal_Gestolen_Fietsen
                           FROM Wijken w, fietsdiefstal fd
                           WHERE w.Buurten = fd.Buurt
                           AND w.Deelgemeenten = 'Feijenoord'
                           GROUP BY DATENAME(mm, newKennisname), DATENAME(yyyy, newKennisname), DATEPART(mm, newKennisname), w.Deelgemeenten
                           ORDER BY Jaar ASC, DATEPART(mm, newKennisname) ASC
                           ; ";
            string queryfietstrommel = @"
                                       SELECT DATENAME(mm, Mutdatum) AS Maand, DATENAME(yyyy, Mutdatum) AS Jaar, w.Deelgemeenten, COUNT(*) AS Aantal_Geplaatste_Fietstrommels
                                       FROM Wijken w, Fietstrommel ft
                                       WHERE w.Deelgemeenten = ft.Deelgemeente
                                       AND w.Deelgemeenten = 'Feijenoord'
                                       GROUP BY DATENAME(mm, Mutdatum), DATENAME(yyyy, Mutdatum), DATEPART(mm, Mutdatum), w.Deelgemeenten
                                       ORDER BY Jaar ASC, DATEPART(mm, Mutdatum) ASC
                                       ; ";
            SqlCommand queryCommand = new SqlCommand(querydiefstal, sdwDBConnection);
            SqlCommand queryCommand2 = new SqlCommand(queryfietstrommel, sdwDBConnection);

            var InstalledContainerBar = new BarSeries { Title = "Amount of installed bicycle containers", StrokeColor = OxyColors.Black, StrokeThickness = 1 };
            var StolenBikeBar = new BarSeries { Title = "Amount of stolen bicycles", StrokeColor = OxyColors.Black, StrokeThickness = 1 };
            var categoryAxis = new CategoryAxis { Position = AxisPosition.Left };
            var valueAxis = new LinearAxis { Position = AxisPosition.Bottom, MinimumPadding = 0, MaximumPadding = 0.06, AbsoluteMinimum = 0 };


            SqlDataReader queryCommandReader2 = queryCommand2.ExecuteReader();
            DataTable dataTable2 = new DataTable();

            dataTable2.Load(queryCommandReader2);
            using (DataTableReader tableReader = dataTable2.CreateDataReader())
            {
                foreach (DataRow row in dataTable2.Rows)
                {
                    InstalledContainerBar.Items.Add(new BarItem { Value = Convert.ToDouble(row[3]) });
                    
                    categoryAxis.Labels.Add(row[0].ToString() + " " + row[1].ToString());

                }
                tableReader.Close();
            }


            SqlDataReader queryCommandReader = queryCommand.ExecuteReader();
           
            DataTable dataTable = new DataTable();
            
            dataTable.Load(queryCommandReader);
           
         

            using (DataTableReader tableReader = dataTable.CreateDataReader())
            {
                foreach (DataRow row in dataTable.Rows )
                {
                    StolenBikeBar.Items.Add(new BarItem { Value = Convert.ToDouble(row[3])});
                    categoryAxis.Labels.Add(row[0].ToString() + " " +  row[1].ToString()); 
                    
                }
                tableReader.Close();
            }

           

            sdwDBConnection.Close();




            //var s1 = new BarSeries { Title = "Amount of installed bicycle containers", StrokeColor = OxyColors.Black, StrokeThickness = 1 };
            //s1.Items.Add(new BarItem { Value = 25 });
            //s1.Items.Add(new BarItem { Value = 137 });
            //s1.Items.Add(new BarItem { Value = 18 });
            //s1.Items.Add(new BarItem { Value = 40 });
            //s1.Items.Add(new BarItem { Value = 20 });
            //s1.Items.Add(new BarItem { Value = 25 });
            //s1.Items.Add(new BarItem { Value = 137 });
            //s1.Items.Add(new BarItem { Value = 18 });
            //s1.Items.Add(new BarItem { Value = 40 });
            //s1.Items.Add(new BarItem { Value = 20 });
            //s1.Items.Add(new BarItem { Value = 40 });
            //s1.Items.Add(new BarItem { Value = 20 });

            //var s2 = new BarSeries { Title = "Amount of stolen bicycles", StrokeColor = OxyColors.Black, StrokeThickness = 1 };
            //s2.Items.Add(new BarItem { Value = 25 });
            //s2.Items.Add(new BarItem { Value = 137 });
            //s2.Items.Add(new BarItem { Value = 18 });
            //s2.Items.Add(new BarItem { Value = 40 });
            //s2.Items.Add(new BarItem { Value = 20 });
            //s2.Items.Add(new BarItem { Value = 25 });
            //s2.Items.Add(new BarItem { Value = 137 });
            //s2.Items.Add(new BarItem { Value = 18 });
            //s2.Items.Add(new BarItem { Value = 40 });
            //s2.Items.Add(new BarItem { Value = 20 });
            //s2.Items.Add(new BarItem { Value = 40 });
            //s2.Items.Add(new BarItem { Value = 20 });

            //var categoryAxis = new CategoryAxis { Position = AxisPosition.Left };
            //categoryAxis.Labels.Add("Neighborhood 1, January");
            //categoryAxis.Labels.Add("Neighborhood 2, February");
            //categoryAxis.Labels.Add("Neighborhood 3, March");
            //categoryAxis.Labels.Add("Neighborhood 4, April");
            //categoryAxis.Labels.Add("Neighborhood 5, May");
            //categoryAxis.Labels.Add("Neighborhood 6, June");
            //categoryAxis.Labels.Add("Neighborhood 7, July");
            //categoryAxis.Labels.Add("Neighborhood 8, August");
            //categoryAxis.Labels.Add("Neighborhood 9, Septembre");
            //categoryAxis.Labels.Add("Neighborhood 10, October");
            //categoryAxis.Labels.Add("Neighborhood 11, November"); 
            //categoryAxis.Labels.Add("Neighborhood 12, December");

           
            model.Series.Add(StolenBikeBar);
            model.Series.Add(InstalledContainerBar);
            model.Axes.Add(categoryAxis);
            model.Axes.Add(valueAxis);

            return model;
        }
    }
}