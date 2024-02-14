using System.Data.SqlClient;
using System;
using System.Security.Cryptography.X509Certificates;
using w68264;


class Program
{





    static void Main(string[] args)
    {

        Menu();










         static void Menu()
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
                        Lekarz();
                        break;

                    case "2":
                        Pielengniarka();
                        break;

                    case "3":
                        Obsluga();
                        break;

                    case "4":
                        Pacjent();
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

                       
                        Console.WriteLine("Podaj Id Lekarza:");
                        string PersonelString = Console.ReadLine();
                        int Personel = 0;

                        try{Personel = int.Parse(PersonelString);}
                        catch (FormatException){Console.WriteLine("Podane ID Lekarza jest w nieprawidłowym formacie!"); }

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
                        catch (FormatException) { Console.WriteLine("Podane ID Lekarza jest w nieprawidłowym formacie!"); }


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
                        Console.WriteLine("Podaj pesel:");
                        pesel = Console.ReadLine();
                        
                        lekarz.wysBadaniaPac(pesel);

                        break;

                    case "8":
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

         static void Pielengniarka()
        {

            Pielengniarka pielengniarka = new Pielengniarka();
            bool exit = false;

            while (!exit)
            {

                Console.Clear();
                Console.WriteLine("Opcje:");
                Console.WriteLine("1. Raport Badania");
                Console.WriteLine("2. Podanie Leku");
                Console.WriteLine("3. Wyswietl leki pacjenta");
                Console.WriteLine("4. Wyswietl Wizyty pacjenta");
                Console.WriteLine("5. Wyswietl Badania pacjenta");
                Console.WriteLine("6. Powrót");

                Console.Write("Twój wybór: ");
                string choice = Console.ReadLine();
                Console.Clear();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Podaj Id Badania:");
                        string idString = Console.ReadLine();
                        int id = 0;
                        try { id = int.Parse(idString); }
                        catch (FormatException) { Console.WriteLine("Podane id Badania jest w nieprawidłowym formacie!"); }

                        Console.WriteLine("Podaj ID pracownika wykonującego:");
                        string idPracString = Console.ReadLine();
                        int idPrac = 0;
                        try { idPrac = int.Parse(idPracString); }
                        catch (FormatException) { Console.WriteLine("Podane id Pracownika jest w nieprawidłowym formacie!"); }


                        Console.WriteLine("Podaj Wynik");
                        string wynik = Console.ReadLine();
                       
                        pielengniarka.raportBadanie(id,idPrac,wynik);
                        break;
                    case "2":
                        
                        Console.WriteLine("Podaj nazwe leku:");
                        string nazwa = Console.ReadLine();
                        Console.WriteLine("Podaj ilosc podanego leku:");
                        string iloscString = Console.ReadLine();
                        int ilosc = 0;
                        try { ilosc = int.Parse(iloscString); }
                        catch (FormatException) { Console.WriteLine("Podane id Pracownika jest w nieprawidłowym formacie!"); }

                        pielengniarka.podajLek(nazwa, ilosc);

                        break;
                    
                    case "3":
                        Console.WriteLine("Podaj pesel pacjenta:");
                        string pesel = Console.ReadLine();

                        pielengniarka.lekiPacjenta(pesel);

                        break;
                    case "4":
                        Console.WriteLine("Podaj pesel:");
                        pesel = Console.ReadLine();

                        pielengniarka.wysWizytePacjenta(pesel);

                        break;
                    case "5":
                        Console.WriteLine("Podaj pesel:");
                        pesel = Console.ReadLine();

                        pielengniarka.wysBadaniaPac(pesel);

                        break;

                    case "6":
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

         static void Obsluga()
        {

            Obsługa obsluga = new Obsługa();
            bool exit = false;

            while (!exit)
            {

                Console.Clear();
                Console.WriteLine("Opcje:");
                Console.WriteLine("1. Dodaj wizyte");
                Console.WriteLine("2. Odwołaj wizyte");
                Console.WriteLine("3. Dodaj Pacjenta");
                Console.WriteLine("4. Wyswietl Wizyty pacjenta");
                Console.WriteLine("5. Wyswietl Badania pacjenta");
                Console.WriteLine("6. Powrót");

                Console.Write("Twój wybór: ");
                string choice = Console.ReadLine();
                Console.Clear();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Podaj pesel pacjenta:");
                        string pesel = Console.ReadLine();
                       

                        Console.WriteLine("Podaj ID lekarza :");
                        string idPracString = Console.ReadLine();
                        int idPrac = 0;
                        try { idPrac = int.Parse(idPracString); }
                        catch (FormatException) { Console.WriteLine("Podane id Pracownika jest w nieprawidłowym formacie!"); }

                        Console.WriteLine("Podaj date: (YYYY-MM-DD HH:mm)");
                        string data = Console.ReadLine();

                        Console.WriteLine("Podaj numer sali :");
                        string nrSalaStr = Console.ReadLine();
                        int nrSala = 0;
                        try { nrSala = int.Parse(nrSalaStr); }
                        catch (FormatException) { Console.WriteLine("Podany numer sali jest w nieprawidłowym formacie!"); }

                        obsluga.ZarejestrujWizyte(pesel, idPrac, data, nrSala);
                        break;
                    case "2":

                        Console.WriteLine("Podaj pesel:");
                        pesel = Console.ReadLine();

                        obsluga.wysWizytePacjenta(pesel);

                        Console.WriteLine("Podaj ID Wizyty:");
                        string idWizytyStr = Console.ReadLine();
                        int idWizyty = 0;
                        try { idWizyty = int.Parse(idWizytyStr); }
                        catch (FormatException) { Console.WriteLine("Podane id Pracownika jest w nieprawidłowym formacie!"); }

                        obsluga.OdwolajWizyte(idWizyty);

                        break;
                    
                    case "3":
                        Console.WriteLine("Podaj imie pacjenta:");
                        string imie = Console.ReadLine();

                        Console.WriteLine("Podaj pesel nazwisko:");
                        string nazwisko = Console.ReadLine();

                        Console.WriteLine("Podaj pesel pacjenta:");
                        pesel = Console.ReadLine();

                        Console.WriteLine("Podaj Przyjmowane Leki przez pacjenta:");
                        string przyjmowaneLeki = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(przyjmowaneLeki)) { przyjmowaneLeki = "null"; };

                        Console.WriteLine("Podaj historie leczenia pacjenta:");
                        string historiaLeczenia = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(historiaLeczenia)) { historiaLeczenia = "null"; };

                        obsluga.DodajPacjent(imie, nazwisko, pesel, przyjmowaneLeki, historiaLeczenia);

                        break;
                    case "4":
                        Console.WriteLine("Podaj pesel:");
                        pesel = Console.ReadLine();

                        obsluga.wysWizytePacjenta(pesel);

                        break;
                    case "5":
                        Console.WriteLine("Podaj pesel:");
                        pesel = Console.ReadLine();

                        obsluga.wysBadaniaPac(pesel);

                        break;

                    case "6":
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

         static void Pacjent()
        {

            Pacjent pacjent = new Pacjent();
            bool exit = false;

            while (!exit)
            {

                Console.Clear();
                Console.WriteLine("Opcje:");
                Console.WriteLine("1. Dodaj wizyte");
                Console.WriteLine("2. Sprawdz ilsoc sal z luzkami");
                Console.WriteLine("3. Powrót");

                Console.Write("Twój wybór: ");
                string choice = Console.ReadLine();
                Console.Clear();
                switch (choice)
                {
                    
                    case "1":
                        Console.WriteLine("Podaj pesel:");
                        string pesel = Console.ReadLine();

                        pacjent.wysBadaniaPac(pesel);

                        break;

                    case "2":
                        Console.WriteLine("Podaj ilosc luzek:");
                        string ileStr = Console.ReadLine();
                        int ile = 0;
                        try { ile = int.Parse(ileStr); }
                        catch (FormatException) { Console.WriteLine("Podana ilosc luzek jest w nieprawidłowym formacie!"); }

                        pacjent.ileluzek(ile);

                        break;

                    case "3":
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






































































