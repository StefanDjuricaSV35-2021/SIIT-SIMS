using simsProj.Core.Clan;
using simsProj.Core.Korisnik;
using simsProj.Core.ObicanBibliotekar;
using simsProj.Core.SpecijalizovanBibliotekar;
using simsProj.Gui.Bibliotekar;
using simsProj.Gui.ClanGui.View;
using simsProj.Gui.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using simsProj.Gui.ClanGui.ViewModel;
using simsProj.Gui.ZaduzenjeGui.View;

namespace simsProj.Gui.ClanGui.Command
{
    public class ClanZaduzenjeWindowCommand : BaseCommand
    {
        private ClanViewModel _clanViewModel;
        public event EventHandler<bool> LoginEvent;
        public ClanZaduzenjeWindowCommand(ClanViewModel clanViewModel)
        {
            _clanViewModel = clanViewModel;
        }
        public bool CanExecute(object? parameter)
        {
            if (_clanViewModel._Clan.brClanskeKarte == null)
            {
                return false;
            }
            return true;
        }
        public override void Execute(object parameter)
        {
            if (CanExecute(parameter))
            {
               new ZaduzenjeWindow(_clanViewModel._Clan).Show();
            }
            else
            {
                MessageBox.Show("Clan bez clanske karte ne sme da zaduzuje knjige.");
            }
        }
    }
}
