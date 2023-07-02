using Prism.Commands;
using simsProj.Core.Autor;
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
using System.Windows.Controls;
using System.Windows.Input;

namespace simsProj.Gui.RadSaFondomGui.ViewModel
{
    public class RegistrujNoviPrimerakViewModel:BaseViewModel
    {
        public ICommand RegistrujPrimerakCommand { get; set; }

        public ObservableCollection<string> Naslovi { get; set; }

        public List<TipKoricenja> EnumValuesKoricenje { get; set; }

        public ObservableCollection<string> Ogranci { get; set; }


        public RegistrujNoviPrimerakViewModel() {

            RegistrujPrimerakCommand = new DelegateCommand(registrujPrimerak);

            NaslovRepository naslovRepository= new NaslovRepository();
            Naslovi= new ObservableCollection<string>();    
            for(int i=0;i<naslovRepository.Naslovi.Count;i++)
            {
                Naslovi.Add(naslovRepository.Naslovi[i].naslov);
            }
            EnumValuesKoricenje = Enum.GetValues(typeof(TipKoricenja)).Cast<TipKoricenja>().ToList();

            OgranakRepository ogranakRepository = new OgranakRepository();
            Ogranci = new ObservableCollection<string>();
            for (int i = 0; i < ogranakRepository.Ogranci.Count; i++)
            {
                Ogranci.Add(ogranakRepository.Ogranci[i].nazivOgranka);
            }

        }
        private string naslov;
        private string isbn;
        private string godina;
       
        private string format;
        private string udk;
        private string nabavnaCena;
        private string izdavac;

        public string Naslov
        {
            get { return naslov; }
            set
            {
                naslov = value;
                OnPropertyChanged(Naslov);
            }
        }
        public string ISBN
        {
            get { return isbn; }
            set
            {
                isbn = value;
                OnPropertyChanged(ISBN);
            }
        }

        public string Godina
        {
            get { return godina; }
            set
            {
                godina = value;
                OnPropertyChanged(Godina);
            }
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

        public string Format
        {
            get { return format; }
            set
            {
                format = value;
                OnPropertyChanged(Format);
            }
        }
        public string UDK
        {
            get { return udk; }
            set
            {
                udk = value;
                OnPropertyChanged(UDK);
            }
        }

        public string NabavnaCena
        {
            get { return nabavnaCena; }
            set
            {
                nabavnaCena = value;
                OnPropertyChanged(NabavnaCena);
            }
        }

        public string Izdavac
        {
            get { return izdavac; }
            set
            {
                izdavac = value;
                OnPropertyChanged(Izdavac);
            }
        }
        private string ogranak;
        public string Ogranak
        {
            get { return ogranak; }
            set
            {
                ogranak = value;
                OnPropertyChanged(Ogranak);
            }
        }

        public void registrujPrimerak()
        {
            if(FondService.dodajPrimerak(Naslov,ISBN,Godina, SelectedEnumKoricenje, Format, UDK, NabavnaCena, Izdavac, Ogranak))
            {
                MessageBox.Show("Primerak uspesno dodat!");
                Naslov = string.Empty;
                ISBN = string.Empty;
                Godina = string.Empty;
                SelectedEnumKoricenje = default(TipKoricenja);
                Format = string.Empty;
                UDK = string.Empty;
                NabavnaCena = string.Empty;
                Izdavac = string.Empty;
                Ogranak = string.Empty;
                return;
            }
            MessageBox.Show("Nevalidni podaci!");
        }
    }
}
