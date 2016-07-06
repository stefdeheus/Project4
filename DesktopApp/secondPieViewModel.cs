using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using OxyPlot;
using OxyPlot.Series;

namespace DesktopApp
{
    class secondPieViewModel
    {
        public PlotModel plot { get; set; }
        public secondPieViewModel()
        {
            
            PieSeries series;

            this.plot = new PlotModel { Title = "Most stolen bicycle colors" };

            series = new PieSeries
            {
                StrokeThickness = 0.5,
                InsideLabelPosition = 0.8,
                AngleSpan = 360,
                StartAngle = 0,
                Diameter = 0.8,
                FontSize = 20
            };
            //database connection string
            string sdwConnectionString =
              @"Server = tcp:infproj4.database.windows.net,1433; Data Source = infproj4.database.windows.net; Initial Catalog = FietstrommelProject; Persist Security Info = False; User ID = raymundo; Password = 97475Thy!; MultipleActiveResultSets = False; Connection Timeout = 30;";

            var sdwDBConnection = new SqlConnection(sdwConnectionString);
            sdwDBConnection.Open();
            string query =
            @"
            SELECT TOP 5 kleur, COUNT(*) AS Aantal
            FROM fietsdiefstal
            GROUP BY kleur
            HAVING kleur != 'ONBEKEND'
            ORDER BY Aantal DESC
            ;";
            SqlCommand queryCommand = new SqlCommand(query, sdwDBConnection);
            SqlDataReader queryCommandReader = queryCommand.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(queryCommandReader);
            //datatbale to store the data

            List<string> kleuren = new List<string>();
            //table reader to read the data of the datatable
            using (DataTableReader tableReader = dataTable.CreateDataReader())
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    series.Slices.Add(new PieSlice(row[0].ToString(), Convert.ToInt32(row[1])) { Fill = kleur(row[0].ToString()) });
                    kleuren.Add(row[0].ToString());
                }
                tableReader.Close();
            }

            sdwDBConnection.Close();

            this.plot.Series.Add(series);
        }

        //method for matching colors with actual colors
        public OxyColor kleur(string kleurString)
        {
            if (kleurString == "ZWART")
            {
                return OxyColors.Black;
            }
            if (kleurString == "BLAUW")
            {
                return OxyColors.Blue;
            }
            if (kleurString == "GRIJS")
            {
                return OxyColors.Gray;
            }
            if (kleurString == "ZILVERKLEURIG")
            {
                return OxyColors.Silver;
            }
            else
            {
                return OxyColors.White;
            }
        }
    }
}