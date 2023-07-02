﻿using simsProj.Core.Clan;
using simsProj.Core.ObicanBibliotekar;
using simsProj.Core.SpecijalizovanBibliotekar;
using simsProj.Gui.Login;
using simsProj.Gui.RegistracijaClanaGui.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace simsProj.Gui.RegistracijaClanaGui.Command
{
    using Core.Korisnik;
    using System.Security.Policy;

    public class SubmitClanCommand : BaseCommand
    {
        private RegistracijaViewModel registracijaViewModel;
        public event EventHandler<bool> SubmitEvent;
        public SubmitClanCommand(RegistracijaViewModel registracijaViewModel)
        {
            this.registracijaViewModel = registracijaViewModel;
        }
        public bool CanExecute(object? parameter)
        {
            if (registracijaViewModel.Email=="" || registracijaViewModel.Ime=="" || registracijaViewModel.Username == "" || registracijaViewModel.Password == ""
                || registracijaViewModel.Prezime=="" || registracijaViewModel.Telefon=="" || registracijaViewModel.Jmbg=="")
                return false;
            if (!UniqueUsername())
                return false;

            return true;
        }

        public override void Execute(object parameter)
        {
            if (CanExecute(parameter))
            {
                KorisnickiNalog korisnickiNalog = new KorisnickiNalog(registracijaViewModel.Username, registracijaViewModel.Password);
                Clan clan = new Clan(registracijaViewModel.Email, registracijaViewModel.Ime, registracijaViewModel.Prezime, registracijaViewModel.Jmbg,
                    registracijaViewModel.Telefon,korisnickiNalog, GenerateUniqueBrClanskeKarte());
                ClanRepository clanRepository = new ClanRepository();
                clanRepository.Clanovi.Add(clan);
                clanRepository.Save();
                MessageBox.Show("Novi clan je kreiran!");
            }
            else
            {
                MessageBox.Show("Nisu svi podaci popunjeni ili username nije jedinstven!");
            }
        }

        public string GenerateUniqueBrClanskeKarte()
        {
            ClanRepository clanRepository = new ClanRepository();
            List<string> clKarte = new List<string>();
            foreach(Clan clan in clanRepository.Clanovi)
                clKarte.Add(clan.brClanskeKarte);
            string retStr = "";
            while (retStr == "")
            {
                Random random = new Random();
                int randomNumber = random.Next(1, 1001);
                string randomString=randomNumber.ToString();
                if (!clKarte.Contains(randomString))
                {
                    retStr=randomString;
                }
            }
            return retStr;
        }
        public bool UniqueUsername()
        {
            ClanRepository clanRepository = new ClanRepository();
            foreach(Clan clan in clanRepository.Clanovi){
                if (clan.nalog.username == registracijaViewModel.Username)
                    return false;
            }
            ObicanBibliotekarRepository obicanBibliotekarRepository = new ObicanBibliotekarRepository();
            foreach(ObicanBibliotekar obican in obicanBibliotekarRepository.ObicniBibliotekari)
            {
                if (obican.nalog.username == registracijaViewModel.Username)
                    return false;
            }
            SpecijalizovanBibliotekarRepository specijalizovan = new SpecijalizovanBibliotekarRepository();
            foreach(SpecijalizovanBibliotekar specijalizovan1 in specijalizovan.SpecijalizovaniBibliotekari)
            {
                if (specijalizovan1.nalog.username == registracijaViewModel.Username)
                    return false;
            }
            return true;
        }
    }
}
