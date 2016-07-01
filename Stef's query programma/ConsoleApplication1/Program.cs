using System;                    // C# , ADO.NET  
using D = System.Data;           // System.Data.dll  
using C = System.Data.SqlClient; // System.Data.dll  

namespace ConsoleApplication1
{
    public class Program
    {
        static public void Main()
        {
            using (var connection = new C.SqlConnection(
                "Server = tcp:infproj4.database.windows.net,1433; Data Source = infproj4.database.windows.net; Initial Catalog = FietstrommelProject; Persist Security Info = False; User ID = raymundo; Password = 97475Thy!; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;"
                ))
            {
                try
                {
                    connection.Open();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                Console.WriteLine("Connected successfully.");

                Program.SelectRows(connection);

                Console.WriteLine("Press any key to finish...");
                Console.ReadKey(true);
            }
        }

        static public void SelectRows(C.SqlConnection connection)
        {

            using (var command = new C.SqlCommand())
            {
                command.Connection = connection;
                command.CommandType = D.CommandType.Text;
                command.CommandText = 

                //Top 5 Deelgemeentes with the largest number of fietstrommels.

                @"
                SELECT TOP 5 Deelgemeente, COUNT(*) AS Aantal_Fietstrommels
                FROM Fietstrommel
                GROUP BY Deelgemeente
                ORDER BY Aantal_Fietstrommels DESC
                ;";

                //Number of stolen bicycles per month.

                //@"
                //SELECT DATENAME(mm, newKennisname) AS Maand, DATENAME(yyyy, newKennisname) AS Jaar, COUNT(*) AS Totaal_Aantal_Gestolen_Fietsen
                //FROM fietsdiefstal
                //GROUP BY DATENAME(mm, newKennisname), DATENAME(yyyy, newKennisname), DATEPART(mm, newKennisname)
                //ORDER BY Jaar ASC, DATEPART(mm, newKennisname) ASC
                //;";

                //Number of installed fietstrommels per month given a specific deelgemeente.

                //@"
                //SELECT DATENAME(mm, Mutdatum), COUNT(*) AS Aantal_Fietstrommels_Geïnstalleerd_Deze_Maand
                //FROM Fietstrommel
                //WHERE Deelgemeente = 'Feijenoord'
                //GROUP BY DATENAME(mm, Mutdatum)
                //;";

                //Number of stolen bicycles per month given a specific neighborhood

                //@"
                //SELECT DATENAME(mm, newKennisname) AS Maand, DATENAME(yyyy, newKennisname) AS Jaar, w.Deelgemeenten, COUNT(*) AS Aantal_Gestolen_Fietsen
                //FROM Wijken w, fietsdiefstal fd
                //WHERE w.Buurten = fd.Buurt
                //AND w.Deelgemeenten = 'Feijenoord'
                //GROUP BY DATENAME(mm, newKennisname), DATENAME(yyyy, newKennisname), DATEPART(mm, newKennisname), w.Deelgemeenten
                //ORDER BY Jaar ASC, DATEPART(mm, newKennisname) ASC
                //;";

                //Number of installed Fietstrommels per month given a specific neighborhood

                //@"
                //SELECT DATENAME(mm, Mutdatum) AS Maand, DATENAME(yyyy, Mutdatum) AS Jaar, w.Deelgemeenten, COUNT(*) AS Aantal_Geplaatste_Fietstrommels
                //FROM Wijken w, Fietstrommel ft
                //WHERE w.Deelgemeenten = ft.Deelgemeente
                //AND w.Deelgemeenten = 'Feijenoord'
                //GROUP BY DATENAME(mm, Mutdatum), DATENAME(yyyy, Mutdatum), DATEPART(mm, Mutdatum), w.Deelgemeenten
                //ORDER BY Jaar ASC, DATEPART(mm, Mutdatum) ASC
                //;";

                //Top 5 colors of bikes most oftenly stolen with numbers.

                //@"
                //SELECT TOP 5 kleur, COUNT(*) AS Aantal
                //FROM fietsdiefstal
                //GROUP BY kleur
                //HAVING kleur != 'ONBEKEND'
                //ORDER BY Aantal DESC
                //;";

                //Top 5 brands of bikes most oftenly stolen with numbers.

                //@"
                //SELECT TOP 5 merk, COUNT(*) AS Aantal
                //FROM fietsdiefstal
                //GROUP BY merk
                //HAVING merk != 'ONBEKEND'
                //ORDER BY Aantal DESC
                //;";

                try
                {
                    C.SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}", reader[0], reader[1]);
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}