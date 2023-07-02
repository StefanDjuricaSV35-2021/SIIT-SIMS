using Newtonsoft.Json;


namespace simsProj.Core.Korisnik
{
    public class Korisnik
    {
        [JsonProperty("email")]
        public string email;

        [JsonProperty("ime")]
        public string ime;

        [JsonProperty("prezime")]
        public string prezime;

        [JsonProperty("jmbg")]
        public string jmbg;

        [JsonProperty("telefon")]
        public string telefon;

        [JsonProperty("korisnicki nalog")]
        public KorisnickiNalog nalog; 

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
