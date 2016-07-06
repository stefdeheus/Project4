using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Security;
using Org.Apache.Http.Impl.IO;
using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace Xamarin
{
    class Line : Graph
    {
        PlotModel plot;
        LineSeries series;
        public List<int> month;
        public PlotModel CreatePlot()
        {
            plot = new PlotModel
            {
                Title = "Amount of stolen bicycles per month"
                
            };

            series = new LineSeries
            {
                MarkerType = MarkerType.Circle,
                MarkerSize = 4,
                MarkerStroke = OxyColors.White, FontSize = 20
            };


            //connection string
            string sdwConnectionString =
                @"Server = tcp:infproj4.database.windows.net,1433; Data Source = infproj4.database.windows.net; Initial Catalog = FietstrommelProject; Persist Security Info = False; User ID = raymundo; Password = 97475Thy!; MultipleActiveResultSets = False; Connection Timeout = 30;";
            //sets up database connection
            var sdwDBConnection = new SqlConnection(sdwConnectionString);
            sdwDBConnection.Open();
            string query =
                "SELECT DATEPART(mm, newKennisname) AS Maand, DATEPART(yyyy, newKennisname) AS Jaar, COUNT(*) AS Totaal_aantal_gestolen_fietsen FROM fietsdiefstal GROUP BY DATEPART(mm, newKennisname), DATEPART(yyyy, newKennisname), DATEPART(mm, newKennisname) ORDER BY Jaar ASC, DATEPART(mm, newKennisname) ASC;";

            SqlCommand queryCommand = new SqlCommand(query, sdwDBConnection);
            SqlDataReader queryCommandReader = queryCommand.ExecuteReader();
            DataTable dataTable = new DataTable();
            //datatable to store data
            dataTable.Load(queryCommandReader);

            List<int> amount = new List<int>();
            month = new List<int>();
            List<int> jaar = new List<int>();
            //tablereader reads data
            using (DataTableReader tableReader = dataTable.CreateDataReader())
            {

                
                foreach (DataRow row in dataTable.Rows)
                {
                    month.Add(Convert.ToInt32(row[0]));
                    jaar.Add(Convert.ToInt32(row[1]));
                    amount.Add(Convert.ToInt32(row[2]));
                    
                }

                tableReader.Close();
            }

            //converting because the axis want to receive doubles instead of integers
            double dob;
            List<double> newAmount = new List<double>();
            foreach (int am in amount)
            {
                dob = Convert.ToDouble(am);
                newAmount.Add(dob);
            }

            int Jaar;
            
            for (int i = 0; i < newAmount.Count; i++)
            {
                Jaar = Convert.ToInt32(jaar[i]);
                //adds data to axis
                series.Points.Add(new DataPoint(DateTimeAxis.ToDouble(new DateTime(Jaar, month[i], 1)), newAmount[i]));              
            }
              
            sdwDBConnection.Close();


            DateTimeAxis Xas = new DateTimeAxis
            {
                Position = AxisPosition.Bottom,
                StringFormat = "MMM/yyyy",
                Title = "Months",
                MinorIntervalType = DateTimeIntervalType.Months,
                IntervalLength = 40,
                IntervalType = DateTimeIntervalType.Months,
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.None, 
                IsZoomEnabled = false,
                IsPanEnabled = false,
               

            };

           
            plot.Axes.Add(Xas);
            plot.Axes.Add(new LinearAxis {Title = "Amount of Bike's", Position = AxisPosition.Left, Maximum = 500, Minimum = 200, IsZoomEnabled = false, IsPanEnabled = false }); // max = 780 omdat dat grootste gestolen amount is per maand.


            plot.Series.Add(series);

            return plot;
            }
    }
}

