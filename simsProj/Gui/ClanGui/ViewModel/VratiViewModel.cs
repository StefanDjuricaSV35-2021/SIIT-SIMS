using Prism.Commands;
using simsProj.Core.Clanska_Karta;
using simsProj.Core.Kazna;
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


    public class VratiViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand VratiKnjigeCommand { get; set; }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public VratiViewModel()
        {
            VratiKnjigeCommand = new DelegateCommand(VratiKnjige);

        }

        private string jmbgClana;
        private string brojClanskeKarte;
        private string primerci;
        private string stanja;

        public string jmbgClanaText
        {
            get { return jmbgClana; }
            set
            {
                jmbgClana = value;
                OnPropertyChanged();
            }
        }

        public string brojClanskeKarteText
        {
            get { return brojClanskeKarte; }
            set
            {
                brojClanskeKarte = value;
                OnPropertyChanged();
            }
        }

        public string primerciText
        {
            get { return primerci; }
            set
            {
                primerci = value;
                OnPropertyChanged();
            }
        }
        public string stanjaText
        {
            get { return stanja; }
            set
            {
                stanja = value;
                OnPropertyChanged();
            }
        }


        public void VratiKnjige()
        {
            // MessageBox.Show("usao u vrati ");
            //MessageBox.Show(jmbgClanaText+" " + tipClanskeKarteText + " " + primerciText + " " + stanjaText);
            KaznaServis.vratiKnjige(primerciText,stanjaText);
            ClanskaKartaRepository clanskaKartaRepository = new ClanskaKartaRepository();
            string tipClanskeKarte="";
            foreach(ClanskaKarta clanskaKarta in clanskaKartaRepository.ClanskeKarte)
            {
                if (clanskaKarta.brClanskeKarte == brojClanskeKarteText)
                {
                    tipClanskeKarte = clanskaKarta.clanstvo.ToString();
                    break;
                }
            }

            int cenaKazne = KaznaServis.vratiCenuKazne(jmbgClanaText,tipClanskeKarte,primerciText,stanjaText);
            
        
            if (cenaKazne == 0)
            {
                MessageBox.Show("Knjige su uspesne vracene. Nema kazne");
            }
            else
            {
                MessageBox.Show("Naplacena je kazna u iznosu od : " + cenaKazne);
            }

            KaznaRepository kaznaRepository = new KaznaRepository();
            List<Kazna> kazne = kaznaRepository.Kazne;
            /* this.jmbg = jmbg;
            this.datumKazne = datumKazne;
            this.iznos = iznos;
            this.placena = placena;
            this.idKazne = idKazne;*/
            Random random = new Random();
            int id = random.Next(1, 10000); // Generiše broj između 1 i 100

            kazne.Add(new Kazna(jmbgClana, DateTime.Now, cenaKazne, false, id.ToString()));
            kaznaRepository.Save();
           
        }


    }
}
