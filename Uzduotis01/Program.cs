namespace Uzduotis01
{
    // Užduotis: Sukurti programą, kuri leis vartotojui įvesti filmų sąrašą ir jų reitingus, o po to atliks įvairias operacijas su šiais duomenimis.
    // Sukurkite konsolinę programą, kuri leis vartotojui įvesti n filmų pavadinimus ir jų reitingus(nuo 1 iki 10).
    // Duomenis saugokite sąraše ar masyve.
    // Leiskite vartotojui pasirinkti iš meniu, ką jis nori atlikti su įvestais duomenimis:
    // a.Rodyti visus filmus ir jų reitingus.
    // b.Rodyti tik tuos filmus, kurių reitingas didesnis nei nurodyta vertė.
    // c.Rasti filmą pagal pavadinimą ir parodyti jo reitingą.
    // d.Atnaujinti filmo reitingą.
    // e.Ištrinti filmą iš sąrašo.
    // f.Išeiti iš programos.
    internal class Program
    {
        private static Filmoteka filmoteka = new();

        public static void Main(string[] args)
        {
            FilmuIvedimas();
            Meniu();
        }

        private static void FilmuIvedimas()
        {
            // Prašoma ivesti filmą ir patvirtinti arba atmesti.
            // Tai kartojama, kol klientas pasirenka nebevesti naujo filmo.
            string confirmation = "";
            do
            {
                string pavadinimas = IvestiPavadinima();
                if (pavadinimas != "-1")
                    filmoteka.SukurtiPridetiFilma(pavadinimas, IvestiReitinga());

                do
                {
                    Console.WriteLine("Ar norite prideti filma (taip / ne)?\n");
                    try
                    {
                        confirmation = Console.ReadLine();
                    }
                    catch
                    {
                        confirmation = "";
                    }
                    Console.WriteLine();
                    confirmation = confirmation.ToLower();
                }
                while (confirmation != "taip" && confirmation != "ne");
            }
            while (confirmation == "taip");

            Console.WriteLine("Filmu ivedimas baigtas\n");
        }

        private static void Meniu()
        {
            int selection;
            bool isInt;
            do
            {
                Console.WriteLine("1.Rodyti visus filmus ir ju reitingus" +
                                "\n2.Rodyti filmus, kuriu reitingas didesnis nei..." +
                                "\n3.Parodyti filmo reitinga" +
                                "\n4.Atnaujinti filmo reitinga" +
                                "\n5.Istrinti filma is saraso" +
                                "\n           0. Baigti darba.\n");
                isInt = int.TryParse(Console.ReadLine(), out selection);
                Console.WriteLine();
            }
            while (!isInt || selection < 0 || selection > 5);

            switch (selection)
            {
                case 0:
                    Console.WriteLine($"Programa baigia darba.");
                    return;
                case 1: // Rodyti visus filmus ir ju reitingus
                    filmoteka.RodytiVisusFilmus();
                    break;
                case 2: // Rodyti filmus, kuriu reitingas didesnis nei...
                    filmoteka.RodytiFilmusDidesniuReitingu(IvestiReitinga());
                    break;
                case 3: // Parodyti filmo reitinga
                    filmoteka.RastiFilma(IvestiPavadinima());
                    break;
                case 4: // Atnaujinti filmo reitinga
                    if (filmoteka.RodytiVisusFilmus())
                        filmoteka.Filmai[filmoteka.RastiFilmoIndex(IvestiPavadinima())].PakeistiFilmoReitinga(IvestiReitinga());
                    break;
                case 5: // Istrinti filma is saraso
                    if (filmoteka.RodytiVisusFilmus())
                        filmoteka.NaikintiFilmaIsSaraso(IvestiPavadinima());
                    break;
                default:
                    Console.WriteLine($"Ivyko nenumatyta klaida, programa baigia darba.");
                    return;
            }
            Meniu();
        }

        public static string IvestiPavadinima()
        {
            if (filmoteka.Filmai.Count < 1)
            {
                Console.WriteLine("Filmoteka tuscia!\n");
                return "-1";
            }    
            string pavadinimas;
            do
            {
                Console.WriteLine("Irasykite filmo pavadinima " +
                    "(Atsaukti: -1)\n");
                pavadinimas = Console.ReadLine();
                if (pavadinimas == "-1")
                {
                    Console.WriteLine("\nAtsaukta\n");
                    return pavadinimas;
                }
                pavadinimas = pavadinimas.ToLower();
            }
            while (pavadinimas == null || pavadinimas.Trim() == "");

            Console.WriteLine();

            return pavadinimas;
        }

        public static double IvestiReitinga()
        {
            if (filmoteka.Filmai.Count < 1)
            {
                Console.WriteLine("Filmoteka tuscia!\n");
                return -1;
            }

            double reitingas;
            bool isDouble;
            do
            {
                Console.WriteLine("Irasykite reitinga nuo 0.01 iki 10.00\n(Atsaukti: -1)\n");
                isDouble = double.TryParse(Console.ReadLine(), out reitingas);
                if (reitingas == -1)
                {
                    Console.WriteLine("\nAtsaukta\n");
                    return reitingas;
                }
            }
            while (!isDouble || reitingas < 0.01 || reitingas > 10);

            Console.WriteLine();

            return reitingas;
        }
    }
}