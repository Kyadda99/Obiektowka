﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w68264
{
    internal class Osoba
    {

        public void wysBadaniaPac(string pesel)
        {
            string connectionString = "Data Source=(localdb)\\Local;Database=w68264_Projekt;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string selectDataQuery = "select idBadania, Nazwa,Cast(Data as date) as Termin,Wynik from Wykonane_Badanie where Pacjent = @pesel";

                using (SqlCommand selectDataCommand = new SqlCommand(selectDataQuery, connection))
                {
                    selectDataCommand.Parameters.AddWithValue("@pesel", pesel);
                    using (SqlDataReader reader = selectDataCommand.ExecuteReader())
                    {

                        Console.WriteLine("\nBadania Pacjenta:");
                        while (reader.Read())
                        {

                            int idBadania = reader.IsDBNull(reader.GetOrdinal("idBadania")) ? 0 : reader.GetInt16(reader.GetOrdinal("idBadania"));
                            string nazwa = reader.IsDBNull(reader.GetOrdinal("Nazwa")) ? "Null" : reader.GetString(reader.GetOrdinal("Nazwa"));
                            DateTime termin = reader.GetDateTime(reader.GetOrdinal("Termin"));
                            string wynik = reader.IsDBNull(reader.GetOrdinal("Wynik")) ? "Null" : reader.GetString(reader.GetOrdinal("Wynik"));


                            Console.WriteLine($"Id Badania: {idBadania},\nNazwa Badania: {nazwa}\nData: {termin}\nWynik: {wynik}");
                            Console.WriteLine();
                        }
                    }
                }
            }


        }

    }
}
