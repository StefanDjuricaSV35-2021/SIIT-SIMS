using simsProj.Core.Korisnik;
using Newtonsoft.Json;

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
    }
}
