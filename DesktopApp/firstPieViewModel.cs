using System;
using System.Data;
using System.Data.SqlClient;
using OxyPlot;
using OxyPlot.Series;

namespace DesktopApp
{
    class firstPieViewModel
    {
        public PlotModel plot { get; set; }
        public firstPieViewModel()
        {
            
            PieSeries series;


            this.plot = new PlotModel { Title = "Most stolen bicycle brands" };

            series = new PieSeries
            {
                StrokeThickness = 0.5,
                InsideLabelPosition = 0.8,
                AngleSpan = 360,
                StartAngle = 0,
                Diameter = 0.8,
                FontSize = 20
            };

            string sdwConnectionString =
                @"Server = tcp:infproj4.database.windows.net,1433; Data Source = infproj4.database.windows.net; Initial Catalog = FietstrommelProject; Persist Security Info = False; User ID = raymundo; Password = 97475Thy!; MultipleActiveResultSets = False; Connection Timeout = 30;";

            var sdwDBConnection = new SqlConnection(sdwConnectionString);
            sdwDBConnection.Open();
            string query = @"
            SELECT TOP 5 merk, COUNT(*) AS Aantal
            FROM fietsdiefstal
            GROUP BY merk
            HAVING merk != 'ONBEKEND'
            ORDER BY Aantal DESC
            ;";
            SqlCommand queryCommand = new SqlCommand(query, sdwDBConnection);
            SqlDataReader queryCommandReader = queryCommand.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(queryCommandReader);


            using (DataTableReader tableReader = dataTable.CreateDataReader())
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    series.Slices.Add(new PieSlice(row[0].ToString(), Convert.ToInt32(row[1])));
                }
                tableReader.Close();
            }

            sdwDBConnection.Close();
            this.plot.Series.Add(series);
        }
    }
}