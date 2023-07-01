using simsProj.Core.Korisnik;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simsProj.Core.SpecijalizovanBibliotekar
{
    public class SpecijalizovanBibliotekar : Korisnik.Korisnik
    {

        public SpecijalizovanBibliotekar()
        {
        }

        public SpecijalizovanBibliotekar(string email, string ime, string prezime, string jmbg, string telefon, KorisnickiNalog nalog)
            : base(email, ime, prezime, jmbg, telefon, nalog)
        {
        }

        public SpecijalizovanBibliotekar(string email, string ime, string prezime, string jmbg, string telefon)
            : base(email, ime, prezime, jmbg, telefon)
        {
        }
    }
}
