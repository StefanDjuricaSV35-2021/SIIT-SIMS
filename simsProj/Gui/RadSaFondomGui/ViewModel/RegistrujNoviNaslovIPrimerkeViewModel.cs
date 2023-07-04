using Prism.Commands;
using simsProj.Core.Autor;
using simsProj.Core.Fond;
using simsProj.Core.Naslov;
using simsProj.Core.Ogranak;
using simsProj.Core.Primerak;
using simsProj.Gui.RadSaFondomGui.View;
using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        private List<Autor> autori=new List<Autor>();

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

            if (ImeAutora != null && PrezimeAutora != null)
            {
                Autor a = new Autor(ImeAutora, PrezimeAutora);
                autori.Add(a);
                //MessageBox.Show("Autor je uspesno dodat!");
                ImeAutora = string.Empty;
                PrezimeAutora = string.Empty;
            }
            else {
                MessageBox.Show("Empty fields!");
            }
        }

        public void registrujNaslov() {
            if (FondService.registrujNaslov(ImeNaslova, Opis, autori))
            {
                MessageBox.Show("Naslov je uspesno dodat!");
                ImeNaslova = string.Empty;
                Opis = string.Empty;
                return;
            }
            autori = new List<Autor>();
            MessageBox.Show("Naslov vec postoji u bazi!");
        }
    }
}
