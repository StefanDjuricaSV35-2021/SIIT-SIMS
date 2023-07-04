using Prism.Commands;
using simsProj.Gui.Login;
using simsProj.Gui.RadSaFondomGui.View;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace simsProj.Gui.BibliotekarGui.ViewModel
{
    public class SpecijalizovanBibliotekarViewModel:BaseViewModel
    {
        public ICommand RegistrujNoviNaslovIPrimerkeCommand { get; }
        public ICommand RegistrujNoviPrimerakCommand { get; }
        public ICommand PrikazNaslovaCommand { get; }

        public ICommand IzvestajCommand { get; }


        public SpecijalizovanBibliotekarViewModel() {

            RegistrujNoviNaslovIPrimerkeCommand = new DelegateCommand(registrujNaslovIPrimerke);
            RegistrujNoviPrimerakCommand = new DelegateCommand(registrujNoviPrimerak);
            PrikazNaslovaCommand = new DelegateCommand(prikaziNaslove);
            IzvestajCommand = new DelegateCommand(prikaziIzvestaj);
        }

        public void registrujNaslovIPrimerke() {
            new RegistrujNoviNaslovIPrimerke().Show();
        }

        public void registrujNoviPrimerak() { 
        
            new RegistrujNoviPrimerakView().Show();
        }
        public void prikaziNaslove()
        {

            new NaslovReview().Show();
        }
        public void prikaziIzvestaj()
        {
            new IzvestajView().Show();
        }
    }
}
