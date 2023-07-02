using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace simsProj.Gui.RegistracijaClanaGui.ViewModel
{
    using Gui.RegistracijaClanaGui.Command;
    public class RegistracijaViewModel : BaseViewModel
    {
        public string Email { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Jmbg { get; set; }
        public string Telefon { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public ICommand SubmitClanCommand { get; }
        public RegistracijaViewModel()
        {
            Email = "";
            Ime = "";
            Prezime = "";
            Jmbg = "";
            Telefon = "";
            Username = "";
            Password = "";
            SubmitClanCommand = new SubmitClanCommand(this);
        }
    }
}
