using simsProj.Core.Korisnik;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simsProj.Core.ObicanBibliotekar
{
    public class ObicanBibliotekar : Korisnik.Korisnik
    {

        public ObicanBibliotekar()
        {
        }

        public ObicanBibliotekar(string email, string ime, string prezime, string jmbg, string telefon, KorisnickiNalog nalog)
            : base(email, ime, prezime, jmbg, telefon, nalog)
        {
        }

        public ObicanBibliotekar(string email, string ime, string prezime, string jmbg, string telefon)
            : base(email, ime, prezime, jmbg, telefon)
        {
        }
    }
}
