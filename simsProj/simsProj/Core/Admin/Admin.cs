using simsProj.Core.Korisnik;


namespace simsProj.Core.Admin
{
    public class Admin:Korisnik.Korisnik
    {

        public Admin()
        {
        }

        public Admin(string email, string ime, string prezime, string jmbg, string telefon, KorisnickiNalog nalog)
            : base(email, ime, prezime, jmbg, telefon, nalog)
        {
        }

        public Admin(string email, string ime, string prezime, string jmbg, string telefon)
            : base(email, ime, prezime, jmbg, telefon)
        {
        }
    }
}
