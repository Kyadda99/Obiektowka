using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w68264
{
    internal class Pacjent:Osoba
    {









        //public void wysHistorie(string pesel)
        //{
        //    string connectionString = "Data Source=(localdb)\\Local;Database=w68264_Projekt;Integrated Security=True";



        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        string tableName = "KartyPacjenta";
        //        DataTable NazwyKolumn = connection.GetSchema("Columns", new string[] { null, null, tableName, null });

        //        string selectDataQuery = "select *\r\nfrom KartyPacjenta\r\nwhere Pesel = @Pesel";

        //        using (SqlCommand selectDataCommand = new SqlCommand(selectDataQuery, connection))
        //        {
        //            selectDataCommand.Parameters.AddWithValue("@Pesel", pesel);
        //            using (SqlDataReader reader = selectDataCommand.ExecuteReader())
        //            {
        //                Console.WriteLine("\nPacjent:");
        //                while (reader.Read())
        //                {

        //                    string firstName = reader.IsDBNull(reader.GetOrdinal("Imie")) ? string.Empty : reader.GetString(reader.GetOrdinal("Imie"));
        //                    string lastName = reader.IsDBNull(reader.GetOrdinal("Nazwisko")) ? string.Empty : reader.GetString(reader.GetOrdinal("Nazwisko"));
        //                    string pes = reader.IsDBNull(reader.GetOrdinal("Pesel")) ? string.Empty : reader.GetString(reader.GetOrdinal("Pesel"));
        //                    string lek = reader.IsDBNull(reader.GetOrdinal("Przyjmowane_Leki")) ? string.Empty : reader.GetString(reader.GetOrdinal("Przyjmowane_Leki"));
        //                    string historia = reader.IsDBNull(reader.GetOrdinal("Historia_leczenia")) ? string.Empty : reader.GetString(reader.GetOrdinal("Historia_leczenia"));

        //                    Console.WriteLine($"Imię: {firstName}\n Nazwisko: {lastName}\n Pesel: {pes}\nPrzyjmowane Leki:{lek}\n");
        //                    Console.WriteLine($"Historia Leczenia:{historia}");
        //                    Console.WriteLine();
        //                }
        //            }
        //        }
        //    }


        //}





















    }
}
