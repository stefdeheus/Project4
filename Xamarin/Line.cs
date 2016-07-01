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
        public PlotModel CreatePlot()
        {
            plot = new PlotModel
            {
                Title = "Amount of stolen bicycles per month"
            };
            

            plot.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, });
            plot.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Maximum = 1000 , Minimum = 400 }); // max = 780 omdat dat grootste gestolen amount is per maand.

            series = new LineSeries
            {
                MarkerType = MarkerType.Circle,
                MarkerSize = 4,
                MarkerStroke = OxyColors.White
            };


            string sdwConnectionString =
                @"Server = tcp:infproj4.database.windows.net,1433; Data Source = infproj4.database.windows.net; Initial Catalog = FietstrommelProject; Persist Security Info = False; User ID = raymundo; Password = 97475Thy!; MultipleActiveResultSets = False; Connection Timeout = 30;";

            var sdwDBConnection = new SqlConnection(sdwConnectionString);
            sdwDBConnection.Open();
            string query =
                "SELECT DATENAME(mm, newKennisname) AS Maand, DATENAME(yyyy, newKennisname) AS Jaar, COUNT(*) AS Totaal_aantal_gestolen_fietsen FROM fietsdiefstal GROUP BY DATENAME(mm, newKennisname), DATENAME(yyyy, newKennisname), DATEPART(mm, newKennisname) ORDER BY Jaar ASC, DATEPART(mm, newKennisname) ASC;";

            SqlCommand queryCommand = new SqlCommand(query, sdwDBConnection);
            SqlDataReader queryCommandReader = queryCommand.ExecuteReader();
            DataTable dataTable = new DataTable();
            
            dataTable.Load(queryCommandReader);

            List<string> amount = new List<string>();
            List<string> month = new List<string>();
            List<string> jaar = new List<string>();

            using (DataTableReader tableReader = dataTable.CreateDataReader())
            {

                
                foreach (DataRow row in dataTable.Rows)
                {
                    month.Add(row[0].ToString());
                    jaar.Add(row[1].ToString());
                    amount.Add(row[2].ToString());
                }

                tableReader.Close();
            }
            double dob;
            List<double> newAmount = new List<double>();
            foreach (string am in amount)
            {
                dob = Convert.ToDouble(am);
                newAmount.Add(dob);
            }

            int a = 5;
            for (int i = 0; i < newAmount.Count; i++)
            {
                series.Points.Add(new DataPoint(i,newAmount[i]));

                plot.Annotations.Add(new TextAnnotation { TextPosition = new DataPoint(i,0), Text = month[i]});
            }
           
            
            
            
            



          
            
            sdwDBConnection.Close();

        

            plot.Series.Add(series);

            return plot;

            
        }
    }
}

