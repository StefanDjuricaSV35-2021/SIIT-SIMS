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
    public class ObicanBibliotekarViewModel:BaseViewModel
    {
        public ICommand RegistrujNoviNaslovIPrimerkeCommand { get; }
        public ICommand RegistrujNoviPrimerakCommand { get; }


        public ObicanBibliotekarViewModel() {

            RegistrujNoviNaslovIPrimerkeCommand = new DelegateCommand(registrujNaslovIPrimerke);
            RegistrujNoviPrimerakCommand = new DelegateCommand(registrujNoviPrimerak);
        }

        public void registrujNaslovIPrimerke() {
            new RegistrujNoviNaslovIPrimerke().Show();
        }

        public void registrujNoviPrimerak() { 
        
        new RegistrujNoviPrimerakView().Show();
        }
    }
}
