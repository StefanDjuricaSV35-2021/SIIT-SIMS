using Prism.Commands;
using simsProj.Core.Fond;
using simsProj.Core.Naslov;
using simsProj.Core.Primerak;
using simsProj.Gui.RadSaFondomGui.View;
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
    public class PrimerciReviewViewModel:BaseViewModel
    {
        public Window _trenutniProzor;
        private ObservableCollection<Primerak> primerci;
        public ICommand IzmeniPrimerakCommand { get; set; }
        public ICommand ObrisiPrimerakCommand { get; set; }


        public Window TrenutniProzor
        {
            get { return _trenutniProzor; }
            set { _trenutniProzor = value; OnPropertyChanged(""); }
        }
        public ObservableCollection<Primerak> Primerci
        {
            get { return primerci; }
            set
            {
                primerci = value;
                OnPropertyChanged(nameof(Primerci));
            }
        }

        private Primerak selectedPrimerak;
        public Primerak SelectedPrimerak
        {
            get { return selectedPrimerak; }
            set
            {
                selectedPrimerak = value;
                OnPropertyChanged(nameof(SelectedPrimerak));
            }
        }

        private Naslov _Naslov;

        public Naslov Naslov
        {
            get { return _Naslov; }
            set
            {
                _Naslov = value;
                OnPropertyChanged(nameof(Naslov));
            }
        }

        public void fillTable()
        {
           
            Primerci.Clear();
            PrimerakRepository primerakRepository = new PrimerakRepository();
            List<Primerak> primerciList = primerakRepository.Primerci;
            foreach (Primerak p in primerciList)
            {
                if(Naslov.primerci.Contains(p.isbn))
                {
                    Primerci.Add(p);
                }
            }
        }

        public PrimerciReviewViewModel(Naslov naslov)
        {
            Naslov = naslov;
            primerci = new ObservableCollection<Primerak>();
            IzmeniPrimerakCommand = new DelegateCommand(izmeniPrimerak);
            ObrisiPrimerakCommand = new DelegateCommand(obrisiPrimerak);

        }

        public void izmeniPrimerak()
        {
           new IzmeniPrimerakView(SelectedPrimerak).Show();
            TrenutniProzor?.Close();
        }

        public void obrisiPrimerak()
        {
            MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni da želite da obrišete primerak?", "Potvrda brisanja", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (rezultat == MessageBoxResult.Yes)
            {
                FondService.obrisiPrimerak(Naslov,SelectedPrimerak);
                MessageBox.Show("Primerak je uspesno obrisan!");
                Primerci.Remove(SelectedPrimerak);
            }
            
        }


    }
}
