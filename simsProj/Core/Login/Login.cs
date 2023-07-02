using simsProj.Core.Clan;
using simsProj.Core.ObicanBibliotekar;
using simsProj.Core.SpecijalizovanBibliotekar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simsProj.Core.Login
{
    using Core.Clan;
    using Core.ObicanBibliotekar;
    using Core.SpecijalizovanBibliotekar;
    using simsProj.Core.Korisnik;

    public class Login
    {
        public ClanRepository ClanRepository { get; set; }
        public ObicanBibliotekarRepository ObicanBibliotekarRepository { get; set; }
        public SpecijalizovanBibliotekarRepository SpecijalizovanBibliotekarRepository { get; set; }
        public KorisnickiNalog Nalog { get; set; }
        public Login(KorisnickiNalog nalog)
        {
            Nalog = nalog;
            ClanRepository = new ClanRepository();
            ObicanBibliotekarRepository = new ObicanBibliotekarRepository();
            SpecijalizovanBibliotekarRepository = new SpecijalizovanBibliotekarRepository();
        }
        public Clan? CheckClanLogin()
        {
            return ClanRepository.Clanovi.FirstOrDefault(clan => clan.nalog.username == Nalog.username && clan.nalog.password == Nalog.password);
        }
        public ObicanBibliotekar? CheckObicanBibliotekarLogin()
        {
            return ObicanBibliotekarRepository.ObicniBibliotekari.FirstOrDefault(clan => clan.nalog.username == Nalog.username && clan.nalog.password == Nalog.password);
        }
        public SpecijalizovanBibliotekar? CheckSpecijalizovanBibliotekarLogin()
        {
            return SpecijalizovanBibliotekarRepository.SpecijalizovaniBibliotekari.FirstOrDefault(clan => clan.nalog.username == Nalog.username && clan.nalog.password == Nalog.password);
        }
    }
}
