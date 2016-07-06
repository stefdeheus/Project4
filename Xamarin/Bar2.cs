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
    class Bar2 : AbstractBar
    {
        

       


        public override PlotModel CreatePlot()
        {
            var model = new PlotModel
            {
                Title = "The amount of stolen bicycles and amount of installed bicycle containers per month given a specific neighborhood",
                LegendPlacement = LegendPlacement.Outside,
                LegendPosition = LegendPosition.BottomCenter,
                LegendOrientation = LegendOrientation.Horizontal,
                LegendBorderThickness = 0
            };


            
            string deelGemeente = SecondBarChart.deelGemeente;

            



            //connection string
            string sdwConnectionString =
               @"Server = tcp:infproj4.database.windows.net,1433; Data Source = infproj4.database.windows.net; Initial Catalog = FietstrommelProject; Persist Security Info = False; User ID = raymundo; Password = 97475Thy!; MultipleActiveResultSets = False; Connection Timeout = 30;";

            var sdwDBConnection = new SqlConnection(sdwConnectionString);
            sdwDBConnection.Open();
            string querydiefstal = @"
                           SELECT DATENAME(mm, newKennisname) AS Maand, DATENAME(yyyy, newKennisname) AS Jaar, w.Deelgemeenten, COUNT(DISTINCT Voorval_nummer) AS Aantal_Gestolen_Fietsen
                           FROM Wijken w, fietsdiefstal fd
                           WHERE w.Buurten = fd.Buurt
                           AND w.Deelgemeenten = " + deelGemeente + " " + 
                                   "GROUP BY DATENAME(mm, newKennisname), DATENAME(yyyy, newKennisname), DATEPART(mm, newKennisname), w.Deelgemeenten ORDER BY Jaar ASC, DATEPART(mm, newKennisname) ASC;";

            string queryfietstrommel = @"
                                       SELECT DATENAME(mm, Mutdatum) AS Maand, DATENAME(yyyy, Mutdatum) AS Jaar, w.Deelgemeenten, COUNT(DISTINCT Inventarisnr) AS Aantal_Geplaatste_Fietstrommels
                                       FROM Wijken w, Fietstrommel ft
                                       WHERE w.Deelgemeenten = ft.Deelgemeente
                                       AND w.Deelgemeenten =" + deelGemeente + " " +
                                       "GROUP BY DATENAME(mm, Mutdatum), DATENAME(yyyy, Mutdatum), DATEPART(mm, Mutdatum), w.Deelgemeenten ORDER BY Jaar ASC, DATEPART(mm, Mutdatum) ASC;";
                                       
            SqlCommand queryCommand1 = new SqlCommand(querydiefstal, sdwDBConnection);
            SqlCommand queryCommand2 = new SqlCommand(queryfietstrommel, sdwDBConnection);

            var InstalledContainerBar = new BarSeries { Title = "Amount of installed bicycle containers", StrokeColor = OxyColors.Black, StrokeThickness = 1 };
            var StolenBikeBar = new BarSeries { Title = "Amount of stolen bicycles", StrokeColor = OxyColors.Black, StrokeThickness = 1 };
            var categoryAxis = new CategoryAxis { Position = AxisPosition.Left };
            var valueAxis = new LinearAxis { Position = AxisPosition.Bottom, MinimumPadding = 0, MaximumPadding = 0.06, AbsoluteMinimum = 0 };

            SqlDataReader queryCommandReader1 = queryCommand1.ExecuteReader();
            //datatable of stolen bycicles
            DataTable stolen = new DataTable();
            stolen.Load(queryCommandReader1);

            SqlDataReader queryCommandReader2 = queryCommand2.ExecuteReader();
            //datatble of installed containers
            DataTable trommel = new DataTable();
            trommel.Load(queryCommandReader2);
            //third datatable for merging
            DataTable dataTable3 = new DataTable();
            dataTable3.Columns.Add("Maand", typeof(string));
            dataTable3.Columns.Add("Jaar", typeof(string));
            dataTable3.Columns.Add("DeelGemeente", typeof(string));
            dataTable3.Columns.Add("Aantal_Geplaatste_Trommels", typeof(Int32));
            dataTable3.Columns.Add("Aantal_Gestolen_Fietsen", typeof(Int32));

            // 4th datatable is the correct one
            DataTable dataTable4 = new DataTable();

            //datatable reader for reading out the datatables
            using (DataTableReader tableReader2 = trommel.CreateDataReader())
            {
                foreach (DataRow row in trommel.Rows)
                {
                    DataRow dataRow = dataTable3.NewRow();
                    dataRow[0] = row[0];
                    dataRow[1] = row[1];
                    dataRow[2] = row[2];
                    dataRow[3] = row[3];                    
                    string trommelString = (row[0] + " " + row[1]);

                    using (DataTableReader tableReader1 = stolen.CreateDataReader())
                    {
                        foreach (DataRow rowtje in stolen.Rows)
                        {
                            string stolenString = (rowtje[0] + " " + rowtje[1]);
                            if (trommelString == stolenString)
                            {
                                dataRow[4] = rowtje[3];

                            }
                        }
                        dataTable3.Rows.Add(dataRow);
                        tableReader1.Close();
                    }

                }
                tableReader2.Close();
            }

            dataTable4 = dataTable3.Copy();

            using (DataTableReader tableReader1 = stolen.CreateDataReader())
            {
                foreach (DataRow row in stolen.Rows)
                {
                    bool isEqual = false;
                    string GestolenString = row[0] + " " + row[1];

                    foreach (DataRow rowtje in dataTable3.Rows)
                    {
                        string dataTable3String = rowtje[0] + " " + rowtje[1];
                        if (GestolenString == dataTable3String)
                        {
                            isEqual = true;
                        }
                    }

                    if (isEqual == false)
                    {
                        DataRow dataRow = dataTable4.NewRow();
                        dataRow[0] = row[0];
                        dataRow[1] = row[1];
                        dataRow[2] = row[2];
                        dataRow[4] = row[3];
                        dataTable4.Rows.Add(dataRow);
                    }
                }
                tableReader1.Close();
            }


            using (DataTableReader datatableReader4 = dataTable4.CreateDataReader())
            {
                foreach (DataRow row in dataTable4.Rows)
                {
                    string datum = row[0] + " " + row[1];
                    categoryAxis.Labels.Add(datum);
                    if(row[4] == DBNull.Value) { StolenBikeBar.Items.Add(new BarItem { Value = 0 }); }
                    else
                    {
                        StolenBikeBar.Items.Add(new BarItem { Value = Convert.ToDouble(row[4]) });
                    }
                    if(row[3] == DBNull.Value) { InstalledContainerBar.Items.Add(new BarItem { Value = 0 }); }
                    else
                    {
                        InstalledContainerBar.Items.Add(new BarItem { Value = Convert.ToDouble(row[3]) });
                    }
                    
                    
                }


                datatableReader4.Close();
            }


            
            sdwDBConnection.Close();
            Console.WriteLine();
 

            model.Series.Add(StolenBikeBar);
            model.Series.Add(InstalledContainerBar);
            model.Axes.Add(categoryAxis);
            model.Axes.Add(valueAxis);

            return model;
        }
    }
}