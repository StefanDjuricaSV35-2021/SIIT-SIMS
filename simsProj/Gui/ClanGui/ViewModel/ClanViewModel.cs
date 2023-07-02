using Prism.Commands;
using simsProj.Gui.RadSaFondomGui.View;
using simsProj.Core.Clan;
using simsProj.Gui.ClanGui.Command;
using simsProj.Gui.ZaduzenjeGui.View;

using simsProj.Gui.ClanGui.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace simsProj.Gui.ClanGui.ViewModel
{
    public class ClanViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand ZaduziPrimerak { get; set; }
        public ICommand VratiCommand { get; set; }
        public Clan _Clan;
        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ClanViewModel(Clan Clan)
        {
            _Clan = Clan;
            ZaduziPrimerak = new ClanZaduzenjeWindowCommand(this);
            VratiCommand = new DelegateCommand(Vrati);
            
        }

        public void Vrati()
        {
            new VratiWindow().Show();
        }
    }
}
