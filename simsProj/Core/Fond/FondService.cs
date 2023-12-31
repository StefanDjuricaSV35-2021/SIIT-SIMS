﻿using simsProj.Core.Autor;
using simsProj.Core.Naslov;
using simsProj.Core.Primerak;
using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simsProj.Core.Fond
{
   public class FondService
    {

        public static bool registrujNaslov(string imeNaslova,string opis,List<Autor.Autor> autori) {

            if (proveriDaLiPostojiNaslov(imeNaslova)) {
                return false;
            }
            List<string> primerci = new List<string>();
            Naslov.Naslov n = new Naslov.Naslov(imeNaslova, opis, 0, autori, primerci);
            NaslovRepository naslovRepository = new NaslovRepository();
            naslovRepository.Naslovi.Add(n);
            naslovRepository.Save();
            return true;
        }
        public static bool proveriDaLiPostojiNaslov(string imeNaslova) {

            NaslovRepository naslovRepository=new NaslovRepository();
            List<Naslov.Naslov> naslovi = naslovRepository.Naslovi;

            for (int i = 0; i < naslovi.Count(); i++)
            {
                if (naslovi[i].naslov == imeNaslova) { return true; }
            }
            return false;
        }

        public static bool dodajPrimerak(string naslov,string isbn, string godina, TipKoricenja koricenje,string format,string udk,string nabavnaCena, string izdavac, string ogranak)
        {
            //provera da li primerak sa ovim isbn-om vec postoji
            if (proveriDaLiPostojiPrimerak(isbn))
            {
                return false;
            }

            if(string.IsNullOrEmpty(naslov) || string.IsNullOrEmpty(isbn) || string.IsNullOrEmpty(godina) || string.IsNullOrEmpty(format) || string.IsNullOrEmpty(udk) || string.IsNullOrEmpty(nabavnaCena) || string.IsNullOrEmpty(izdavac))
            {
                return false;
            }

            int parsedGodina;
            int parsedNabavnaCena;

            if (int.TryParse(godina,out parsedGodina)==false || int.TryParse(nabavnaCena,out parsedNabavnaCena)==false)
            {
                return false;
            }

            Primerak.Primerak primerak=new Primerak.Primerak(isbn,parsedGodina,koricenje,format,udk,parsedNabavnaCena,true,izdavac,ogranak);
            PrimerakRepository primerakRepository = new PrimerakRepository();
            primerakRepository.Primerci.Add(primerak);
            primerakRepository.Save();

            //sada dodajemo u taj naslov isbn primerka koji smo uneli
            NaslovRepository naslovRepository = new NaslovRepository();
            for(int i = 0; i < naslovRepository.Naslovi.Count; i++)
            {
                if (naslovRepository.Naslovi[i].naslov==naslov) {
                    naslovRepository.Naslovi[i].primerci.Add(isbn);
                    naslovRepository.Save();
                    break;
                }
            }
            return true;
        }
        public static bool proveriDaLiPostojiPrimerak(string isbn)
        {
            PrimerakRepository primerakRepository = new PrimerakRepository();

            for (int i = 0; i < primerakRepository.Primerci.Count; i++)
            {
                if (primerakRepository.Primerci[i].isbn == isbn) { return true; }
            }
            return false;
        }

        public static void obrisiPrimerak(Naslov.Naslov naslov,Primerak.Primerak p)
        {
            NaslovRepository naslovRepository=new NaslovRepository();
            for( int i = 0; i < naslovRepository.Naslovi.Count; i++)
            {
                if (naslovRepository.Naslovi[i].naslov==naslov.naslov)
                {
                    naslovRepository.Naslovi[i].primerci.Remove(p.isbn);
                    naslovRepository.Save();
                    break;
                }
            }
            PrimerakRepository primerakRepository=new PrimerakRepository();
            primerakRepository.Primerci.Remove(p);
            primerakRepository.Save();
        }

        public static bool izmeniPrimerak(Primerak.Primerak p,TipKoricenja tipKoricenja, string format, string nabavnaCena, string ogranak)
        {
            if (string.IsNullOrEmpty(format) ||  string.IsNullOrEmpty(nabavnaCena))
            {
                return false;
            }
           
            int parsedNabavnaCena;

            if (int.TryParse(nabavnaCena, out parsedNabavnaCena) == false)
            {
                return false;
            }

            PrimerakRepository primerakRepository = new PrimerakRepository();
            for(int i=0;i<primerakRepository.Primerci.Count;i++)
            {
                if (primerakRepository.Primerci[i].isbn == p.isbn)
                {
                    primerakRepository.Primerci[i].tipKoricenja= tipKoricenja;
                    primerakRepository.Primerci[i].format = format;
                    primerakRepository.Primerci[i].nabavnaCena = parsedNabavnaCena;
                    primerakRepository.Primerci[i].nazivOgranka = ogranak;
                    primerakRepository.Save();
                    break;
                }
            }

            return true;
        }

        public static void obrisiNaslov(Naslov.Naslov naslov)
        {
            //prvo brisemo sve primerke ovog naslova
            PrimerakRepository primerakRepository= new PrimerakRepository();
            List<Primerak.Primerak> novaLista = new List<Primerak.Primerak>();
            for( int i = 0; i < primerakRepository.Primerci.Count(); i++)
            {
                if (!naslov.primerci.Contains(primerakRepository.Primerci[i].isbn))
                {
                    novaLista.Add(primerakRepository.Primerci[i]);
                }
            }

            primerakRepository.Primerci= novaLista;
            primerakRepository.Save();

            NaslovRepository naslovRepository= new NaslovRepository();
            List<Naslov.Naslov> novaListaNaslova = new List<Naslov.Naslov>();

            for (int i = 0; i < naslovRepository.Naslovi.Count(); i++)
            {
                if (naslovRepository.Naslovi[i].naslov!=naslov.naslov)
                {
                    novaListaNaslova.Add(naslovRepository.Naslovi[i]);
                }
            }

            naslovRepository.Naslovi=novaListaNaslova;

            naslovRepository.Save();    
        }
}
}
