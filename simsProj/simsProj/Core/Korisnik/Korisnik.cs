using Newtonsoft.Json;


namespace simsProj.Core.Korisnik
{
    public class Korisnik
    {
        [JsonProperty("email")]
        private string email;

        [JsonProperty("ime")]
        private string ime;

        [JsonProperty("prezime")]
        private string prezime;

        [JsonProperty("jmbg")]
        private string jmbg;

        [JsonProperty("telefon")]
        private string telefon;

        [JsonProperty("korisnicki nalog")]
        private KorisnickiNalog nalog; 

        public Korisnik()
        {

        }
        public Korisnik(string email, string ime, string prezime, string jmbg, string telefon, KorisnickiNalog nalog)
        {
            this.email = email;
            this.ime = ime;
            this.prezime = prezime;
            this.jmbg = jmbg;
            this.telefon = telefon;
            this.nalog = nalog;
        }

        public Korisnik(string email, string ime, string prezime, string jmbg, string telefon)
        {
            this.email = email;
            this.ime = ime;
            this.prezime = prezime;
            this.jmbg = jmbg;
            this.telefon = telefon;
        }
    }
}
