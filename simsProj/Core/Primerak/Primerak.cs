using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simsProj.Core.Primerak
{
    public enum TipKoricenja
    {
        MEKO, TVRDO
    }
    public class Primerak
    {
        [JsonProperty("isbn")]
        public string isbn;

        [JsonProperty("godina")]
        private int godina;

        [JsonProperty("tipKoricenja")]
        private TipKoricenja tipKoricenja;

        [JsonProperty("format")]
        private string format;

        [JsonProperty("udk")]
        private string udk;

        [JsonProperty("nabavnaCena")]
        private int nabavnaCena;

        [JsonProperty("slobodna")]
        private bool slobodna;

        [JsonProperty("izdavac")]
        private string izdavac;

        [JsonProperty("nazivOgranka")]
        private string nazivOgranka;

        public Primerak()
        {

        }

        public Primerak(string isbn, int godina, TipKoricenja tipKoricenja, string format, string udk, int nabavnaCena, bool slobodna, string izdavac, string nazivOgranka)
        {
            this.isbn = isbn;
            this.godina = godina;
            this.tipKoricenja = tipKoricenja;
            this.format = format;
            this.udk = udk;
            this.nabavnaCena = nabavnaCena;
            this.slobodna = slobodna;
            this.izdavac = izdavac;
            this.nazivOgranka = nazivOgranka;
        }
    }
}
