﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w68264
{
    internal class Obsługa:Pracownik
    {


        public void ZarejestrujWizyte(string pesel, int lekarz, DateTime data, int sala)//'2024-02-20'
        {
            string connectionString = "Data Source=(localdb)\\Local;Database=w68264_Projekt;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string insertDataQuery = $"insert into Umówione_Wizyty(Pacjent,Lekarz,Data,Sala)\r\nValues ('{pesel}',{lekarz},{data},{sala})\r\n";

                using (SqlCommand insertDataCommand = new SqlCommand(insertDataQuery, connection))
                {
                    try
                    {
                        insertDataCommand.ExecuteNonQuery();
                        Console.WriteLine($"Rejestracja przebiegła pomyslnie: {pesel},    {lekarz},     {data},     {sala}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Błąd przy dodawaniu danych: {ex.Message}");
                    }
                }


            }


        }

        public void OdwolajWizyte(string idWizyty)
        {
            string connectionString = "Data Source=(localdb)\\Local;Database=w68264_Projekt;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string insertDataQuery = $"delete from Umówione_Wizyty\r\nwhere IdWiz = {idWizyty}";

                using (SqlCommand insertDataCommand = new SqlCommand(insertDataQuery, connection))
                {
                    try
                    {
                        insertDataCommand.ExecuteNonQuery();
                        Console.WriteLine($"Wizyta odwołana: {idWizyty}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Błąd przy dodawaniu danych: {ex.Message}");
                    }
                }


            }


        }

        //public void wysWizytePacjenta(string pesel)
        //{
        //    string connectionString = "Data Source=(localdb)\\Local;Database=w68264_Projekt;Integrated Security=True";

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();

        //        string selectDataQuery = "select *\r\nfrom Umówione_Wizyty\r\nwhere Pacjent = @Pesel";

        //        using (SqlCommand selectDataCommand = new SqlCommand(selectDataQuery, connection))
        //        {
        //            selectDataCommand.Parameters.AddWithValue("@Pesel", pesel);
        //            using (SqlDataReader reader = selectDataCommand.ExecuteReader())
        //            {
        //                Console.WriteLine("\nWizyta:");
        //                while (reader.Read())
        //                {

        //                    string idWiz = reader.IsDBNull(reader.GetOrdinal("idWiz")) ? string.Empty : reader.GetString(reader.GetOrdinal("idWiz"));
        //                    string Pacjent = reader.IsDBNull(reader.GetOrdinal("Pacjent")) ? string.Empty : reader.GetString(reader.GetOrdinal("Pacjent"));
        //                    string Lekarz = reader.IsDBNull(reader.GetOrdinal("Lekarz")) ? string.Empty : reader.GetString(reader.GetOrdinal("Lekarz"));
        //                    DateTime Data = reader.GetDateTime(reader.GetOrdinal("Data"));
        //                    string sala = reader.IsDBNull(reader.GetOrdinal("sala")) ? string.Empty : reader.GetString(reader.GetOrdinal("sala"));

        //                    Console.WriteLine($"Imię: {idWiz}\n Nazwisko: {Pacjent}\n Pesel: {Lekarz}\nPrzyjmowane Leki:{Data}\n");
        //                    Console.WriteLine($"Historia Leczenia:{sala}");
        //                    Console.WriteLine();
        //                }
        //            }
        //        }
        //    }


        //}


        public void DodajPacjent(string imie,string nazwisko,string pesel ,string przyjmowaneLeki = "null", string historiaLeczenia = "null")
        {
            string connectionString = "Data Source=(localdb)\\Local;Database=w68264_Projekt;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string insertDataQuery = $"insert into Pacjenci(Imie,Nazwisko,Pesel,Przyjmowane_Leki,Historia_leczenia)\r\nvalues ('{imie}','{nazwisko}','{pesel}',{przyjmowaneLeki},{historiaLeczenia})";

                using (SqlCommand insertDataCommand = new SqlCommand(insertDataQuery, connection))
                {
                    try
                    {
                        insertDataCommand.ExecuteNonQuery();
                        Console.WriteLine($"Rejestracja przebiegła pomyslnie: {imie},    {nazwisko},     {pesel},     {przyjmowaneLeki},     {historiaLeczenia}");
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
