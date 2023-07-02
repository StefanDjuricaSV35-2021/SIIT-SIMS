using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using simsProj.Core.Clan;
using simsProj.Core.Naslov;
using simsProj.Core.Zaduzenje;
using simsProj.Gui.ZaduzenjeGui.Command;

namespace simsProj.Gui.ZaduzenjeGui.ViewModel
{
    public class ZaduzenjeViewModel : BaseViewModel
    {
        public NaslovRepository naslovRepository = new NaslovRepository();
        public ZaduzenjeRepository zaduzenjeRepository = new ZaduzenjeRepository();

        public Clan LogedInClan;
        private int _currentZaduzenjeNum = 0;
        private List<NaslovViewModel> naslovViewModels;
        private NaslovViewModel selectedNaslovViewModel;
        public List<NaslovViewModel> naslovi
        {
            get { return naslovViewModels; }
            set
            {
                naslovViewModels = value;
                OnPropertyChanged(nameof(naslovi));
            }
        }

        public NaslovViewModel SelectedNaslov
        {
            get { return selectedNaslovViewModel; }
            set
            {
                selectedNaslovViewModel = value;
                OnPropertyChanged(nameof(SelectedNaslov));
            }
        }

        public int currentZaduzenjeNum
        {
            get { return _currentZaduzenjeNum; }
            set
            {
                _currentZaduzenjeNum = value;
                OnPropertyChanged(nameof(currentZaduzenjeNum));
            }
        }

        private int _maxZaduzenja = 0;
        public int maxZaduzenja
        {
            get { return _maxZaduzenja; }
            set
            {
                _maxZaduzenja = value;
                OnPropertyChanged(nameof(maxZaduzenja));
            }
        }

        public ICommand Zaduzi { get; }

        public ZaduzenjeViewModel(Clan clan)
        {
            LogedInClan = clan;
            naslovViewModels = naslovRepository.GetNaslovData();

            selectedNaslovViewModel = null;
            _maxZaduzenja = LogedInClan.GetClanskaKarta().getMaxKnjiga();

            foreach (Zaduzenje zaduzenje in zaduzenjeRepository.GetZaduzenja())
            {
                if (zaduzenje.IsClans(LogedInClan) && zaduzenje.IsActive())
                {
                    _currentZaduzenjeNum += 1;
                }
            }

            Zaduzi = new ZaduziPrimerakCommand(this);
        }
    }
}
