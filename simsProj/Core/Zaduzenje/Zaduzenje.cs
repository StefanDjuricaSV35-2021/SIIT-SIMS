using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simsProj.Core.Zaduzenje
{
    public enum StanjeKnjige
    {
        OSTECENA,NEOSTECENA,IZGUBLJENA
    }

    public enum StanjeZaduzenja
    {
        AKTIVNO,ZAVRSENO,OPOMENA
    }

    public class Zaduzenje
    {
        [JsonProperty("isbn")]
        public string isbn;

        [JsonProperty("jmbg")]
        public string jmbg;

        [JsonProperty("datum pocetka")]
        private DateTime datumPocetka;

        [JsonProperty("datum kraja")]
        public DateTime datumKraja;

        [JsonProperty("stanje knjige")]
        private StanjeKnjige stanjeKnjige;

        [JsonProperty("stanje zaduzenja")]
        public StanjeZaduzenja stanjeZaduzenja;

        public Zaduzenje()
        {

        }

        public Zaduzenje(string isbn, string jmbg, DateTime datumPocetka, DateTime datumKraja, StanjeKnjige stanjeKnjige, StanjeZaduzenja stanjeZaduzenja)
        {
            this.isbn = isbn;
            this.jmbg = jmbg;
            this.datumPocetka = datumPocetka;
            this.datumKraja = datumKraja;
            this.stanjeKnjige = stanjeKnjige;
            this.stanjeZaduzenja = stanjeZaduzenja;
        }
    }
}
