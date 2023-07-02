using simsProj.Core.Primerak;
using simsProj.Core.Zaduzenje;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simsProj.Core.Kazna
{
    class KaznaServis

    {
        /*   public Kazna(string jmbg, DateTime datumKazne, int iznos, bool placena, string idKazne)
        {
            this.jmbg = jmbg;
            this.datumKazne = datumKazne;
            this.iznos = iznos;
            this.placena = placena;
            this.idKazne = idKazne;
        }*/
        //
        //OSTECENA,NEOSTECENA,IZGUBLJENA
        public static void vratiKnjige(string primerciText,string stanjaText)
        {
            for(int i=0; i < primerciText.Split(',').Length; i++)
            {
                if (stanjaText.Split(',')[i] == "izgubljena")
                {
                    PrimerakRepository pRepository = new PrimerakRepository();
                    List<Primerak.Primerak> primerci = pRepository.Primerci;
                    foreach (Primerak.Primerak primerak in primerci)
                    {
                        if (primerak.isbn == primerciText.Split(',')[i]) { 
                            primerak.slobodna = false;
                            pRepository.Save();
                        
                        }

                    }
                  
                }
                else
                {
                   PrimerakRepository pRepository=new PrimerakRepository();
                    List<Primerak.Primerak> primerci = pRepository.Primerci;
                    foreach(Primerak.Primerak primerak in primerci)
                    {   
                        if (primerak.isbn == primerciText.Split(',')[i]) { 
                            primerak.slobodna = true;
                            pRepository.Save();
                        }
                       
                    }
                }
            }

        }

        public static int naplatiKaznuOstecenje(string tipClanskeKarte)
        {
            int cena = 0;
            int parametar = 5;
            if (tipClanskeKarte == "DECA")
            {
                cena = parametar * 100;
            }else if (tipClanskeKarte == "STUDENTI")
            {
                cena = parametar * 200;
            }else if (tipClanskeKarte == "PENZIONERI")
            {
                cena = parametar*5;
            }
            else
            {
                //odrasli
                cena = parametar * 300;
            }
            return cena;

        }

        public static int naplatiKaznuGubitak(string tipClanskeKarte)
        {
            int cena = 0;
            int parametar = 2;
            if (tipClanskeKarte == "DECA")
            {
                cena = parametar * 100;
            }
            else if (tipClanskeKarte == "STUDENTI")
            {
                cena = parametar * 200;
            }
            else if (tipClanskeKarte == "PENZIONERI")
            {
                cena = parametar * 5;
            }
            else
            {
                //odrasli
                cena = parametar * 300;
            }
            return cena;
        }
        public static int vratiCenuKazne(string jmbgClanaText, string tipClanskeKarteText, string primerciText, string stanjaText)
        {
            int cenaKazne=0;
           

            for (int i = 0; i < primerciText.Split(',').Length; i++)
            {
                if (stanjaText.Split(',')[i] == "izgubljena")
                {
                    cenaKazne+=naplatiKaznuGubitak(tipClanskeKarteText);

                }
                if (stanjaText.Split(',')[i] == "ostecena")
                {
                   cenaKazne += naplatiKaznuOstecenje(tipClanskeKarteText);
                }

                if (izracunajPrekoracenje(DateTime.Now,jmbgClanaText, primerciText.Split(',')[i])>0)
                {
                    cenaKazne+=naplatiPrekoracenje(tipClanskeKarteText) ;
                }
               
            }
            return cenaKazne;


        }

        internal static int naplatiPrekoracenje(string tipClanskeKarte)
        {

            int cena = 0;
            int parametar = 10;
            if (tipClanskeKarte == "DECA")
            {
                cena = parametar * 100;
            }
            else if (tipClanskeKarte == "STUDENTI")
            {
                cena = parametar * 200;
            }
            else if (tipClanskeKarte == "PENZIONERI")
            {
                cena = parametar * 5;
            }
            else
            {
                //odrasli
                cena = parametar * 300;
            }
            return cena;

        }

        public static int izracunajPrekoracenje(DateTime now,string jmbgClana,string isbn)
        {
            int prekoracenje = 0;

            ZaduzenjeRepository pRepository = new ZaduzenjeRepository();
            List<Zaduzenje.Zaduzenje> zaduzenja = pRepository.Zaduzenja;
            foreach (Zaduzenje.Zaduzenje zaduzenje in zaduzenja)
            {
                if (zaduzenje.isbn==isbn && zaduzenje.jmbg==jmbgClana)
                {

                    TimeSpan razlika = now.Subtract(zaduzenje.datumKraja);
                    prekoracenje = razlika.Days;
                    zaduzenje.stanjeZaduzenja = StanjeZaduzenja.ZAVRSENO;
                    pRepository.Save();
                }

            }

            return prekoracenje;
        }
    }
}
