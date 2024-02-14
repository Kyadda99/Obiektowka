using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace w68264
{
    internal class Pielengniarka:PracownikMedyczny
    {










        public void raportBadanie(int idBadania, int Wykonal, string wynik)
        {

            string connectionString = "Data Source=(localdb)\\Local;Database=w68264_Projekt;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string insertDataQuery = $"UPDATE Wykonane_Badanie  SET Wykonał = {Wykonal}, Wynik = '{wynik}'  WHERE IdBadania = {idBadania}";

                using (SqlCommand insertDataCommand = new SqlCommand(insertDataQuery, connection))
                {
                    try
                    {
                        insertDataCommand.ExecuteNonQuery();
                        Console.WriteLine($"Wprowadzono wynik operacji: {Wykonal},   {wynik},    {idBadania}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Błąd przy dodawaniu danych: {ex.Message}");
                    }
                }


            }


        }


        public void podajLek(string nazwa, int ilosc)
        {
            string connectionString = "Data Source=(localdb)\\Local;Database=w68264_Projekt;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                int zapas = 0;

                string checkPosibility = "select Zapas from leki where Nazwa ='Aggrastat'";
                string insertDataQuery = $"update Leki\r\nset Zapas = Zapas -{ilosc}\r\nwhere Nazwa = '{nazwa}'";
                using (SqlCommand checkDataCommand = new SqlCommand(checkPosibility, connection))
                {
                    zapas = Convert.ToInt32(checkDataCommand.ExecuteScalar());
                }
                Console.WriteLine(zapas);
                if (zapas - ilosc >= 0)
                {
                    using (SqlCommand insertDataCommand = new SqlCommand(insertDataQuery, connection))
                    {
                        try
                        {
                            insertDataCommand.ExecuteNonQuery();
                            Console.WriteLine($"Leki skorygowane: {ilosc},   {nazwa}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Błąd przy dodawaniu danych: {ex.Message}");
                        }
                    }

                }
                else { Console.WriteLine("Za mało leków"); }




            }


        }










    }
}
