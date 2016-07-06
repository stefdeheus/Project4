using System;
using System.Data;
using System.Data.SqlClient;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace DesktopApp
{
    class firstBarViewModel
    {
        public PlotModel model { get; set; }
        public firstBarViewModel()
        {
            this.model = new PlotModel
            {
                Title = "The 5 neighborhoods with the biggest amount of bicycle containers",
                LegendPlacement = LegendPlacement.Outside,
                LegendPosition = LegendPosition.BottomCenter,
                LegendOrientation = LegendOrientation.Horizontal,
                LegendBorderThickness = 0,
                DefaultFontSize = 20
            };


            string sdwConnectionString =
                @"Server = tcp:infproj4.database.windows.net,1433; Data Source = infproj4.database.windows.net; Initial Catalog = FietstrommelProject; Persist Security Info = False; User ID = raymundo; Password = 97475Thy!; MultipleActiveResultSets = False; Connection Timeout = 30;";

            var sdwDBConnection = new SqlConnection(sdwConnectionString);
            sdwDBConnection.Open();
            string query = @"
                SELECT TOP 5 Deelgemeente, COUNT(*) AS Aantal_Fietstrommels
                FROM Fietstrommel
                GROUP BY Deelgemeente
                ORDER BY Aantal_Fietstrommels DESC
                ;";
            SqlCommand queryCommand = new SqlCommand(query, sdwDBConnection);
            SqlDataReader queryCommandReader = queryCommand.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(queryCommandReader);

            var barSeries = new BarSeries() { Title = "Amount of bicycle containers", StrokeColor = OxyColors.Black, StrokeThickness = 1 };
            var categoryAxis = new CategoryAxis { Position = AxisPosition.Left, IsZoomEnabled = false, IsPanEnabled = false };
            var valueAxis = new LinearAxis { Position = AxisPosition.Bottom, MinimumPadding = 0, MaximumPadding = 0.06, AbsoluteMinimum = 0, IsZoomEnabled = false, IsPanEnabled = false };

            using (DataTableReader tableReader = dataTable.CreateDataReader())
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    barSeries.Items.Add(new BarItem { Value = Convert.ToDouble(row[1]) });
                    categoryAxis.Labels.Add(row[0].ToString());
                }
                tableReader.Close();
            }
            sdwDBConnection.Close();

            this.model.Series.Add(barSeries);
            this.model.Axes.Add(categoryAxis);
            this.model.Axes.Add(valueAxis);
        }
    }
}