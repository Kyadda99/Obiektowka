using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w68264
{
    internal class PracownikMedyczny:Pracownik
    {








        public void lekiPacjenta(string pesel)
        {
            string connectionString = "Data Source=(localdb)\\Local;Database=w68264_Projekt;Integrated Security=True";



            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string selectDataQuery = "select Imie,Nazwisko,Pesel,Przyjmowane_Leki as Przyjmuje,Lek as Zalecony_Lek  from Pacjenci p left join Zalecenia z on p.Pesel = z.Pacjent where Pesel = @Pesel";

                using (SqlCommand selectDataCommand = new SqlCommand(selectDataQuery, connection))
                {
                    selectDataCommand.Parameters.AddWithValue("@Pesel", pesel);
                    using (SqlDataReader reader = selectDataCommand.ExecuteReader())
                    {
                        Console.WriteLine("\nPacjent:");
                        while (reader.Read())
                        {

                            string firstName = reader.IsDBNull(reader.GetOrdinal("Imie")) ? string.Empty : reader.GetString(reader.GetOrdinal("Imie"));
                            string lastName = reader.IsDBNull(reader.GetOrdinal("Nazwisko")) ? string.Empty : reader.GetString(reader.GetOrdinal("Nazwisko"));
                            string pes = reader.IsDBNull(reader.GetOrdinal("Pesel")) ? string.Empty : reader.GetString(reader.GetOrdinal("Pesel"));
                            string lek = reader.IsDBNull(reader.GetOrdinal("Przyjmuje")) ? string.Empty : reader.GetString(reader.GetOrdinal("Przyjmuje"));
                            string zaleconyLek = reader.IsDBNull(reader.GetOrdinal("Zalecony_Lek")) ? string.Empty : reader.GetString(reader.GetOrdinal("Zalecony_Lek"));

                            Console.WriteLine($"Imię: {firstName}\n Nazwisko: {lastName}\n Pesel: {pes}\nPrzyjmuje Leki:{lek}\nZalecone Leki:{zaleconyLek}\n");

                            Console.WriteLine();
                        }
                    }
                }
            }


        }


    }
}
