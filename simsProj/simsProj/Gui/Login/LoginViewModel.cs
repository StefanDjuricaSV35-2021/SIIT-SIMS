using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace simsProj.Gui.Login
{
    public class LoginViewModel : BaseViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public ICommand LoginCommand { get; }
        public LoginViewModel()
        {
            Username = "";
            Password = "";
            LoginCommand = new LoginCommand(this);
        }
    }
}
