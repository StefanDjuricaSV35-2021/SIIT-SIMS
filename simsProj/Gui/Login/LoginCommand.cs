﻿using simsProj.Core.Clan;
using simsProj.Core.Korisnik;
using simsProj.Core.ObicanBibliotekar;
using simsProj.Core.SpecijalizovanBibliotekar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using simsProj.Gui.ClanGui.View;

namespace simsProj.Gui.Login
{
    using Core.Login;
    using Gui.BibliotekarGui.View;
    using simsProj.Gui.Bibliotekar;
    using simsProj.Gui.ClanGui.View;

    public class LoginCommand : BaseCommand
    {
        private LoginViewModel _loginViewModel;
        public event EventHandler<bool> LoginEvent;
        public LoginCommand(LoginViewModel loginViewModel)
        {
            _loginViewModel = loginViewModel;
        }
        public bool CanExecute(object? parameter)
        {
            if (_loginViewModel.Username == "" || _loginViewModel.Password=="")
                return false;
            return true;
        }
        public override void Execute(object parameter)
        {
            if (CanExecute(parameter))
            {
                KorisnickiNalog korisnickiNalog = new KorisnickiNalog(_loginViewModel.Username, _loginViewModel.Password);
                Login login = new Login(korisnickiNalog);
                Clan? LoginClan = login.CheckClanLogin();
                ObicanBibliotekar? obicanBibliotekar = login.CheckObicanBibliotekarLogin();
                SpecijalizovanBibliotekar? specijalizovanBibliotekar = login.CheckSpecijalizovanBibliotekarLogin();
                if (_loginViewModel.Username == "admin" && _loginViewModel.Password == "admin")
                {
                    MessageBox.Show("Ulogovao se admin!");
                    //napravi i prikazi prozor admina
                }
                else if (LoginClan != null)
                {
                    MessageBox.Show("Ulogovao se clan");
                    new ClanWindow(LoginClan).Show();

                }
                else if (obicanBibliotekar != null)
                {
                    MessageBox.Show("Ulogovan obican biblotekar!");
                    new ObicanBibliotekarWindow().Show();

                }
                else if (specijalizovanBibliotekar != null)
                {
                    MessageBox.Show("Ulogovan spec biblotekar!");
                    //napravi i prikazi prozor spec bibliotekara
                    new SpecijalizovanBibliotekarWindow().Show();
                }
                else
                {
                    MessageBox.Show("Pogresan username ili password");
                }
            }
            else
            {
                MessageBox.Show("Ne sme se ostaviti prazan tekst");
            }
        }
    }
}
