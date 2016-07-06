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

namespace Xamarin
{
    [Activity(Label = "Activity1")]
    public class DBConnectTest : AbstractActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.DBConnectTest);
            // Create your application here

            //connection string
            string sdwConnectionString =
                @"Server = tcp:infproj4.database.windows.net,1433; Data Source = infproj4.database.windows.net; Initial Catalog = FietstrommelProject; Persist Security Info = False; User ID = raymundo; Password = 97475Thy!; MultipleActiveResultSets = False; Connection Timeout = 30;";
                //opens database connection with the connection string
                var sdwDBConnection = new SqlConnection(sdwConnectionString);
                sdwDBConnection.Open();

            string query = "SELECT * FROM Fietsdiefstal";
            //creates command with query and get executed
            SqlCommand queryCommand = new SqlCommand(query, sdwDBConnection);
            SqlDataReader queryCommandReader = queryCommand.ExecuteReader();
            //creates datatable and stores data in it
            DataTable dataTable = new DataTable();
            dataTable.Load(queryCommandReader);
            string columns = string.Empty;

            foreach (DataColumn column in dataTable.Columns)
            {
                columns += column.ColumnName + " | ";
            }
            System.Diagnostics.Debug.WriteLine(columns);

            sdwDBConnection.Close();



        }
    }
} 