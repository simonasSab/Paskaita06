namespace Uzduotis01
{
    internal class Filmoteka
    {
        // a.Rodyti visus filmus ir jų reitingus.
        // b.Rodyti tik tuos filmus, kurių reitingas didesnis nei nurodyta vertė.
        // c.Rasti filmą pagal pavadinimą ir parodyti jo reitingą.
        // d.Atnaujinti filmo reitingą.
        // e.Ištrinti filmą iš sąrašo.
        public List<Filmas> Filmai { get; set; }

        public Filmoteka()
        {
            Filmai = new();
        }

        public void SukurtiPridetiFilma(string pavadinimas, double reitingas)
        {
            if (pavadinimas != "-1" && reitingas != -1)
            {
                Filmas filmas = new(pavadinimas, reitingas);
                if (Filmai.Contains(filmas))
                {
                    Console.WriteLine("Filmas tokiu pavadinimu jau ivestas, dubliuoti negalima.");
                    return;
                }
                if (filmas != null)
                {
                    string confirmation;
                    do
                    {
                        Console.WriteLine("Patvirtinkite filmo ivedima (taip / ne)\n");
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

                    if (confirmation == "taip")
                    {
                        Filmai.Add(filmas);
                        Console.WriteLine($"Filmas \"{filmas.ToString()}\" sekmingai pridetas prie saraso.\n");
                        return;
                    }
                    Console.WriteLine("Filmas neivestas\n");
                    return;
                }
                Console.WriteLine("Filmas neivestas\n");
                return;
            }
            return;
        }
        public bool RodytiVisusFilmus()
        {
            if (Filmai.Count > 0)
            {
                Console.WriteLine("Visi filmotekos filmai ir ju reitingai:");
                foreach (Filmas filmas in Filmai)
                {
                    Console.WriteLine(filmas.ToString());
                }
                Console.WriteLine();
                return true;
            }
            else
            {
                Console.WriteLine("Filmoteka tuscia!\n");
                return false;
            }
        }

        public void RodytiFilmusDidesniuReitingu(double reitingas)
        {
            if (reitingas == -1)
                return;

            if (Filmai.Count > 0)
            {
                Console.WriteLine($"Filmotekos filmai, kuriu reitingas didesnis nei {reitingas:.00}:");
                foreach (Filmas filmas in Filmai)
                {
                    if (filmas.Reitingas > reitingas)
                        Console.WriteLine(filmas.ToString());
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Filmoteka tuscia!\n");
            }
        }

        public Filmas? RastiFilma(string pavadinimas)
        {
            if (pavadinimas == "-1")
                return null;

            if (Filmai.Count > 0)
            {
                foreach (Filmas filmas in Filmai)
                {
                    if (filmas.Pavadinimas == pavadinimas)
                    {
                        Console.WriteLine($"Reitingas: {filmas.Reitingas:.00}/10\n");
                        return filmas;
                    }
                }
                Console.WriteLine("Filmo tokiu pavadinimu nera.\n");
                return null;
            }
            else
            {
                Console.WriteLine("Filmoteka tuscia!\n");
                return null;
            }
        }

        public int RastiFilmoIndex(string pavadinimas)
        {
            if (pavadinimas == "-1")
                return -1;

            if (Filmai.Count > 0)
            {
                for (int i = 0; i < Filmai.Count; i++)
                {
                    if (Filmai[i].Pavadinimas == pavadinimas)
                    {
                        return i;
                    }
                }
                Console.WriteLine("Filmo tokiu pavadinimu nera.\n");
                return -1;
            }
            else
            {
                Console.WriteLine("Filmoteka tuscia!\n");
                return -1;
            }
        }

        public void NaikintiFilmaIsSaraso(string pavadinimas)
        {
            if (pavadinimas == "-1")
                return;

            if (Filmai.Remove(RastiFilma(pavadinimas)))
            {
                Console.WriteLine($"Sekmingai panaikintas filmas {pavadinimas}\n");
            }
            else
            {
                Console.WriteLine("Filmas nerastas.\n");
            }
        }
    }
}
