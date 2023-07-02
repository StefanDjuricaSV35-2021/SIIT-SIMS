using Prism.Commands;
using simsProj.Core.Fond;
using simsProj.Gui.RadSaFondomGui.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace simsProj.Gui.RadSaFondomGui.ViewModel
{
    public class RegistrujNoviNaslovIPrimerkeViewModel:BaseViewModel
    {

        public ICommand DodajAutoraCommand { get; set; }
        public ICommand RegistrujNaslovCommand { get; set; }

        public ICommand DodajPrimerkeCommand { get; set; }


        public RegistrujNoviNaslovIPrimerkeViewModel() {

            DodajAutoraCommand = new DelegateCommand(dodajAutora);
            RegistrujNaslovCommand = new DelegateCommand(registrujNaslov);
            DodajPrimerkeCommand = new DelegateCommand(dodajPrimerke);

        }


        private string imeNaslova;
        private string opis;
        private string imeAutora;
        private string prezimeAutora;


        public string ImeNaslova
        {
            get { return imeNaslova; }
            set
            {
                imeNaslova = value;
                OnPropertyChanged(ImeNaslova);
            }
        }

        public string Opis
        {
            get { return opis; }
            set
            {
                opis = value;
                OnPropertyChanged(Opis);
            }
        }

        public string ImeAutora
        {
            get { return imeAutora; }
            set
            {
                imeAutora = value;
                OnPropertyChanged(ImeAutora);
            }
        }

        public string PrezimeAutora
        {
            get { return prezimeAutora; }
            set
            {
                prezimeAutora = value;
                OnPropertyChanged(PrezimeAutora);
            }
        }

        public void dodajPrimerke() {
            new RegistrujNoviPrimerakView().Show();
        }

        public void dodajAutora() {
        
                
        }

        public void registrujNaslov() {
            FondService.registrujNaslov();
        }
    }
}
