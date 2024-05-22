namespace Uzduotis01
{
    internal class Filmas
    {
        public string Pavadinimas { get; set; }
        public double Reitingas { get; set; }

        public Filmas(string pavadinimas, double reitingas)
        {
            Pavadinimas = pavadinimas;
            Reitingas = reitingas;
        }

        public void PakeistiFilmoReitinga(double naujasReitingas)
        {
            if (naujasReitingas == -1)
                return;

            Reitingas = naujasReitingas;
        }

        public override string ToString()
        {
            return $"{Pavadinimas}, reitingas: {Reitingas:.00}/10";
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;

            Filmas knyga = (Filmas)obj;

            if (knyga.Pavadinimas == this.Pavadinimas)
                return true;
            else
                return false;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
