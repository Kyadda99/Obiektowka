using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace w68264
{
    class Lekarz:PracownikMedyczny
    {
 






        //public void wysDanePac(string pesel)
        //{
        //    string connectionString = "Data Source=(localdb)\\Local;Database=w68264_Projekt;Integrated Security=True";



        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();

        //        string selectDataQuery = "select * from Pacjenci where pesel = @Pesel";

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
        public void zlecBadanie(string pesel,string nazwaBadania,string data)//'2024-02-20'
        {
            string connectionString = "Data Source=(localdb)\\Local;Database=w68264_Projekt;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string insertDataQuery = $"INSERT INTO Wykonane_Badanie (Nazwa, Pacjent, Data) VALUES ('{nazwaBadania}','{pesel}','{data}')";

                   using (SqlCommand insertDataCommand = new SqlCommand(insertDataQuery, connection))
                   {
                        try
                        {
                            insertDataCommand.ExecuteNonQuery();
                            Console.WriteLine($"Dodano badanie: {nazwaBadania},    {pesel},     {data}");
                        }
                            catch (Exception ex)
                        {
                            Console.WriteLine($"Błąd przy dodawaniu danych: {ex.Message}");
                        }
                   }
                        
                    
            }
                

        }


        public void zaplanujOperacje(string pesel, string nazwaOperacji)
        {
            string connectionString = "Data Source=(localdb)\\Local;Database=w68264_Projekt;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string insertDataQuery = $"INSERT INTO Wykonane_Operacjie(Nazwa, Pacjent) VALUES ('{nazwaOperacji}','{pesel}')";

                using (SqlCommand insertDataCommand = new SqlCommand(insertDataQuery, connection))
                {
                    try
                    {
                        insertDataCommand.ExecuteNonQuery();
                        Console.WriteLine($"Dodano badanie: {nazwaOperacji},    {pesel}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Błąd przy dodawaniu danych: {ex.Message}");
                    }
                }


            }


        }

        public void raportOperacja(int idOperacji, int Personel, string wynik)
        {
            string connectionString = "Data Source=(localdb)\\Local;Database=w68264_Projekt;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string insertDataQuery = $"UPDATE Wykonane_Operacjie SET Personel = {Personel}, Wynik = '{wynik}' WHERE IdOperacji = {idOperacji}";

                using (SqlCommand insertDataCommand = new SqlCommand(insertDataQuery, connection))
                {
                    try
                    {
                        insertDataCommand.ExecuteNonQuery();
                        Console.WriteLine($"Wprowadzono wynik operacji: {Personel},   {wynik},    {idOperacji}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Błąd przy dodawaniu danych: {ex.Message}");
                    }
                }


            }


        }

        public void wystawZalecenie(string pacjent,int lekarz, string lek,string zalecenie ,DateTime dzienTemp=default(DateTime))
        {
            string dzien = "";
            if (dzienTemp == default(DateTime)) {dzien = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); }
            string connectionString = "Data Source=(localdb)\\Local;Database=w68264_Projekt;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string insertDataQuery = $"INSERT INTO Zalecenia(Pacjent,Lekarz,Lek,Zalecenie,Data) VALUES ('{pacjent}',{lekarz},'{lek}','{zalecenie}',CONVERT(varchar, '{dzien}', 23))";

                using (SqlCommand insertDataCommand = new SqlCommand(insertDataQuery, connection))
                {
                    try
                    {
                        insertDataCommand.ExecuteNonQuery();
                        Console.WriteLine($"Zalecenie to: '{pacjent}','{lekarz}','{lek}','{zalecenie}','{dzien}'");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Błąd przy dodawaniu danych: {ex.Message}");
                    }
                }


            }


        }

        








    }
}
