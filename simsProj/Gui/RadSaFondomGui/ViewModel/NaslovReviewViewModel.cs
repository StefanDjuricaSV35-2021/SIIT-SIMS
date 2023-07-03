using Prism.Commands;
using simsProj.Core.Admin;
using simsProj.Core.Naslov;
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
    public class NaslovReviewViewModel:BaseViewModel
    {
        private ObservableCollection<Naslov> naslovi;
        public ICommand PrikaziAutoreCommand { get; set; }
        public ICommand PrikaziPrimerkeCommand { get; set; }
        public NaslovReviewViewModel() {

            naslovi = new ObservableCollection<Naslov>();
            PrikaziPrimerkeCommand = new DelegateCommand(prikaziPrimerkeZaNaslov);
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

        public void fillTable() {
            Naslovi.Clear();
            NaslovRepository naslovRepository = new NaslovRepository();
            List<Naslov> nasloviList = naslovRepository.Naslovi;
            foreach (Naslov n in nasloviList)
            {
                Naslovi.Add(n);
            }
        }

        public void prikaziAutoreZaNaslov() {
            StringBuilder sb = new StringBuilder();
            foreach (var autor in SelectedNaslov.autori)
            {
                sb.AppendLine($"{autor.ime} {autor.prezime}");
            }

            MessageBox.Show(sb.ToString(), "Autori");
        }

        public void prikaziPrimerkeZaNaslov()
        {
            new PrimerciReview(SelectedNaslov).Show();
        }

        public bool CanExecute()
        {
            return SelectedNaslov != null;
        }
    }
}
