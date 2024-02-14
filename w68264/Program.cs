using System.Data.SqlClient;
using System;
using System.Security.Cryptography.X509Certificates;
using w68264;


class Program
{





    static void Main(string[] args)
    {

        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("Kto:");
            Console.WriteLine("1. Lekarz");
            Console.WriteLine("2. Pielengniarka");
            Console.WriteLine("3. Obsługa");
            Console.WriteLine("4. Pacjent");
            Console.WriteLine("5. Wyjście");

            Console.Write("Twój wybór: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Wybrano opcję 1.");
                    Lekarz();
                    // Tutaj dodaj kod dla opcji 1
                    break;

                case "2":
                    Console.WriteLine("Wybrano opcję 2.");
                    // Tutaj dodaj kod dla opcji 2
                    break;

                case "3":
                    Console.WriteLine("Wybrano opcję 3.");
                    // Tutaj dodaj kod dla opcji 3
                    break;

                case "4":
                    Console.WriteLine("Wybrano opcję 4.");
                    // Tutaj dodaj kod dla opcji 4
                    break;

                case "5":
                    Console.WriteLine("Wybrano wyjście. Program zostanie zakończony.");
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
                    break;
            }
        }





         static void Lekarz()
        {

            Lekarz lekarz = new Lekarz();
            bool exit = false;

            while (!exit)
            {

                Console.Clear();
                Console.WriteLine("Opcje:");
                Console.WriteLine("1. Zlec Badanie");
                Console.WriteLine("2. Zaplanuj Operacje");
                Console.WriteLine("3. Raport z Operacji");
                Console.WriteLine("4. Wystaw Zalecenie");
                Console.WriteLine("5. Wyswietl leki pacjenta");
                Console.WriteLine("6. Wyswietl Wizyty pacjenta");
                Console.WriteLine("7. Wyswietl Badania pacjenta");
                Console.WriteLine("8. Powrót");

                Console.Write("Twój wybór: ");
                string choice = Console.ReadLine();
                Console.Clear();
                switch (choice)
                {
                    case "1":
                        // Zlec Badanie
                        Console.WriteLine("Podaj pesel:");
                        string pesel = Console.ReadLine();
                        Console.WriteLine("Podaj nazwe Badania:");
                        string nazwaBadania = Console.ReadLine();
                        Console.WriteLine("Podaj date: (YYYY-MM-DD HH:mm)");
                        string data = Console.ReadLine();


                        lekarz.zlecBadanie(pesel, nazwaBadania, data);

                        break;
                    case "2":
                        
                        Console.WriteLine("Podaj pesel:");
                        pesel = Console.ReadLine();
                        Console.WriteLine("Podaj nazwe Operacji:");
                        string nazwaOperacji = Console.ReadLine();

                        lekarz.zaplanujOperacje(pesel, nazwaOperacji);

                        break;
                    case "3":
                        Console.WriteLine("Podaj idOperacji:");
                        string idOperacjiString = Console.ReadLine();
                        int idOperacji = 0;

                        try {  idOperacji = int.Parse(idOperacjiString); }
                        catch (FormatException){Console.WriteLine("Podane idOperacji jest w nieprawidłowym formacie!");}

                       
                        Console.WriteLine("Podaj nazwe Badania:");
                        string PersonelString = Console.ReadLine();
                        int Personel = 0;

                        try{Personel = int.Parse(PersonelString);}
                        catch (FormatException){Console.WriteLine("Podany wiek jest w nieprawidłowym formacie!"); }

                        Console.WriteLine("Podaj date: (YYYY-MM-DD HH:mm)");
                        string wynik = Console.ReadLine();


                        lekarz.raportOperacja(idOperacji,Personel, wynik);

                        break;
                    case "4":
                        Console.WriteLine("Podaj Pesel Pacjenta:");
                        string pacjent = Console.ReadLine();
                        Console.WriteLine("Podaj nazwe ID Lekarza:");
                        PersonelString = Console.ReadLine();
                        Personel = 0;

                        try { Personel = int.Parse(PersonelString); }
                        catch (FormatException) { Console.WriteLine("Podany wiek jest w nieprawidłowym formacie!"); }


                        Console.WriteLine("Podaj Lek:");
                        string lek = Console.ReadLine(); 
                        Console.WriteLine("Wpisz Zalecenie:");
                        string zalecenie = Console.ReadLine();


                        lekarz.wystawZalecenie(pacjent,Personel,lek,zalecenie);

                        break;
                    case "5":
                        Console.WriteLine("Podaj pesel pacjenta:");
                        pesel = Console.ReadLine();

                        lekarz.lekiPacjenta(pesel);

                        break;
                    case "6":
                        Console.WriteLine("Podaj pesel:");
                        pesel = Console.ReadLine();
                        
                        lekarz.wysWizytePacjenta(pesel);

                        break;

                    case "7":
                        Console.WriteLine("Wybrano wyjście. Program zostanie zakończony.");
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
                        break;

                }
                Console.ReadKey();
            }

        }
    }

}






































































