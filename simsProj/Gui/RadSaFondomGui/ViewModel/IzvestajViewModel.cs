using Prism.Commands;
using simsProj.Core.Fond;
using simsProj.Core.Naslov;
using simsProj.Gui.RadSaFondomGui.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace simsProj.Gui.RadSaFondomGui.ViewModel
{
    public class IzvestajViewModel:BaseViewModel
    {
        private ObservableCollection<Naslov> naslovi;
        public ICommand PrikaziAutoreCommand { get; set; }
       
        public IzvestajViewModel()
        {
            naslovi = new ObservableCollection<Naslov>();
            PrikaziAutoreCommand = new DelegateCommand(prikaziAutoreZaNaslov);
        }

        public ObservableCollection<Naslov> Naslovi
        {
            get { return naslovi; }
            set
            {
                naslovi = value;
                OnPropertyChanged(nameof(Naslovi));
            }
        }

        private Naslov selectedNaslov;
        public Naslov SelectedNaslov
        {
            get { return selectedNaslov; }
            set
            {
                selectedNaslov = value;
                OnPropertyChanged(nameof(SelectedNaslov));
            }
        }

        public void fillTable()
        {
            Naslovi.Clear();
            NaslovRepository naslovRepository = new NaslovRepository();
            List<Naslov> nasloviList = naslovRepository.Naslovi;

            nasloviList.Sort((x, y) => y.brCitanja.CompareTo(x.brCitanja)); // Sortiranje liste po atributu brCitanja u opadajućem poretku
            int brojac = 0;
            foreach (Naslov n in nasloviList)
            {
                if (brojac <= 10)
                {
                    brojac++;
                    Naslovi.Add(n);
                }
                else { break; }
            }
        }

        public void prikaziAutoreZaNaslov()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var autor in SelectedNaslov.autori)
            {
                sb.AppendLine($"{autor.ime} {autor.prezime}");
            }

            MessageBox.Show(sb.ToString(), "Autori");
        }

       
        
    }

}

