using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w68264
{
    internal class Pracownik:Osoba
    {

        public void wysWizytePacjenta(string pesel)
        {
            string connectionString = "Data Source=(localdb)\\Local;Database=w68264_Projekt;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string selectDataQuery = "select IDWiz, PAcjent,Lekarz,Data,Sala from Umówione_Wizyty where Pacjent = @Pesel";

                using (SqlCommand selectDataCommand = new SqlCommand(selectDataQuery, connection))
                {
                    selectDataCommand.Parameters.AddWithValue("@Pesel", pesel);
                    using (SqlDataReader reader = selectDataCommand.ExecuteReader())
                    {
                        Console.WriteLine("\nWizyta:");
                        while (reader.Read())
                        {
                            int idWiz = reader.IsDBNull(reader.GetOrdinal("IDWiz")) ? 0 : reader.GetInt32(reader.GetOrdinal("IDWiz"));
                            string Pacjent = reader.IsDBNull(reader.GetOrdinal("Pacjent")) ? string.Empty : reader.GetString(reader.GetOrdinal("Pacjent"));
                            string Lekarz = reader.IsDBNull(reader.GetOrdinal("Lekarz")) ? string.Empty : reader.GetString(reader.GetOrdinal("Lekarz"));
                            DateTime Data = reader.GetDateTime(reader.GetOrdinal("Data"));
                            int sala = reader.IsDBNull(reader.GetOrdinal("sala")) ? 0 : reader.GetInt32(reader.GetOrdinal("sala"));

                            Console.WriteLine($"Identyfikator Wizyty: {idWiz}\n Pacjent: {Pacjent}\n Lekarz: {Lekarz}\n Data: {Data}\n Sala: {sala}\n");
                            Console.WriteLine();
                        }

                    }
                }
            }


        }









    }
}
