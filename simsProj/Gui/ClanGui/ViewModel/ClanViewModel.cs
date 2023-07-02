using Prism.Commands;
using simsProj.Gui.RadSaFondomGui.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using simsProj.Core.Clan;
using simsProj.Gui.ClanGui.Command;
using simsProj.Gui.ZaduzenjeGui.View;

namespace simsProj.Gui.ClanGui.ViewModel
{
    public class ClanViewModel : BaseViewModel
    {
        public ICommand ZaduziPrimerak { get; }
        public Clan _Clan;

        public ClanViewModel(Clan Clan)
        {
            _Clan = Clan;
            ZaduziPrimerak = new ClanZaduzenjeWindowCommand(this);
        }
    }
}
