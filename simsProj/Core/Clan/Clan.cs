using simsProj.Core.Korisnik;
using Newtonsoft.Json;
using simsProj.Core.Clanska_Karta;

namespace simsProj.Core.Clan
{
    public class Clan : Korisnik.Korisnik
    {
        [JsonProperty("broj clanske karte")]
        public string brClanskeKarte { get; set; }

        public Clan()
        {
        }

        public Clan(string email, string ime, string prezime, string jmbg, string telefon, KorisnickiNalog nalog, string brClanskeKarte)
            : base(email, ime, prezime, jmbg, telefon, nalog)
        {
            this.brClanskeKarte = brClanskeKarte;
        }

        public Clan(string email, string ime, string prezime, string jmbg, string telefon, string brClanskeKarte)
            : base(email, ime, prezime, jmbg, telefon)
        {
            this.brClanskeKarte = brClanskeKarte;
        }

        public Clan(string email, string ime, string prezime, string jmbg, string telefon, KorisnickiNalog nalog)
            : base(email, ime, prezime, jmbg, telefon, nalog)
        {
            this.brClanskeKarte = null;
        }

        public Clan(string email, string ime, string prezime, string jmbg, string telefon)
            : base(email, ime, prezime, jmbg, telefon)
        {
            this.brClanskeKarte = null;
        }

        public ClanskaKarta GetClanskaKarta()
        {
            if (brClanskeKarte == null)
            {
                return null;
            }

            ClanskaKartaRepository ckr = new ClanskaKartaRepository();

            foreach (ClanskaKarta clanskaKarta in ckr.GetClanskeKarte())
            {
                if (clanskaKarta.GetBrClanskeKarte() == brClanskeKarte)
                {
                    return clanskaKarta;
                }
            }
            return null;
        } 
    }
}
