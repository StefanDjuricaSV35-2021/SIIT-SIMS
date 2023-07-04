using Prism.Commands;
using simsProj.Core.Fond;
using simsProj.Core.Naslov;
using simsProj.Core.Ogranak;
using simsProj.Core.Primerak;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace simsProj.Gui.RadSaFondomGui.ViewModel
{
    public class IzmeniPrimerakViewModel:BaseViewModel
    {

        public List<TipKoricenja> EnumValuesKoricenje { get; set; }

        public ObservableCollection<string> Ogranci { get; set; }

        public ICommand PotvrdiIzmenuCommand { get; set; }
        public IzmeniPrimerakViewModel(Primerak p)
        {
            Primerak = p;
            ISBN = p.isbn;
            Godina = p.godina.ToString();
            Format=p.format;
            SelectedEnumKoricenje = p.tipKoricenja;
            Izdavac = p.izdavac;
            UDK = p.udk;
            NabavnaCena = p.nabavnaCena.ToString();
            Ogranak = p.nazivOgranka;

            EnumValuesKoricenje = Enum.GetValues(typeof(TipKoricenja)).Cast<TipKoricenja>().ToList();

            OgranakRepository ogranakRepository = new OgranakRepository();
            Ogranci = new ObservableCollection<string>();
            for (int i = 0; i < ogranakRepository.Ogranci.Count; i++)
            {
                Ogranci.Add(ogranakRepository.Ogranci[i].nazivOgranka);
            }

            PotvrdiIzmenuCommand = new DelegateCommand(izmeniPrimerak);

        }

        private TipKoricenja _selectedEnumKoricenje;
        public TipKoricenja SelectedEnumKoricenje
        {
            get { return _selectedEnumKoricenje; }
            set
            {
                _selectedEnumKoricenje = value;
                OnPropertyChanged(nameof(SelectedEnumKoricenje));
            }
        }

        private string godina;
        private string format;
        private string nabavnaCena;
        private string udk;
        private string izdavac;
        private string isbn;
        private string ogranak;

        public string Ogranak
        {
            get { return ogranak; }
            set
            {
                ogranak = value;
                OnPropertyChanged(nameof(Ogranak));
            }
        }

        public string UDK
        {
            get { return udk; }
            set
            {
                udk = value;
                OnPropertyChanged(nameof(UDK));
            }
        }

        public string Izdavac
        {
            get { return izdavac; }
            set
            {
                izdavac = value;
                OnPropertyChanged(nameof(Izdavac));
            }
        }
        public string Format
        {
            get { return format; }
            set
            {
                format = value;
                OnPropertyChanged(nameof(Format));
            }
        }
        public string Godina
        {
            get { return godina; }
            set
            {
                godina = value;
                OnPropertyChanged(nameof(Godina));
            }
        }
        public string NabavnaCena
        {
            get { return nabavnaCena; }
            set
            {
                nabavnaCena = value;
                OnPropertyChanged(nameof(NabavnaCena));
            }
        }
        public string ISBN
        {
            get { return isbn; }
            set
            {
                isbn= value;
                OnPropertyChanged(nameof(ISBN));
            }
        }

        private Primerak _Primerak;

        public Primerak Primerak
        {
            get { return _Primerak; }
            set
            {
                _Primerak = value;
                OnPropertyChanged(nameof(Primerak));
            }
        }


        public void izmeniPrimerak()
        {
            if (FondService.izmeniPrimerak(Primerak,SelectedEnumKoricenje,Format, NabavnaCena,Ogranak))
            {
                MessageBox.Show("Primerak uspesno izmenjen!");
                return;
            }
            MessageBox.Show("Nevalidni podaci!");
        }
    }


    
}
