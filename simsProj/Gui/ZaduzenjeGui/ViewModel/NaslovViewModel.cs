using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using simsProj.Core.Naslov;

namespace simsProj.Gui.ZaduzenjeGui.ViewModel
{
    public class NaslovViewModel : BaseViewModel
    {
        public Naslov Naslov;

        private string _naslov;
        public string naslov
        {
            get { return _naslov; }
            set
            {
                _naslov = value;
                OnPropertyChanged(nameof(naslov));
            }
        }

        private string _opis;
        public string opis
        {
            get { return _opis; }
            set
            {
                _opis = value;
                OnPropertyChanged(nameof(opis));
            }
        }
        public NaslovViewModel(Naslov naslov)
        {
            Naslov = naslov;
            _naslov = Naslov.GetNaslov();
            _opis = Naslov.GetOpis();
        }
    }
}
