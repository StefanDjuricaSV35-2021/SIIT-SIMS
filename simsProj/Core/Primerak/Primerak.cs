using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using simsProj.Core.Zaduzenje;

namespace simsProj.Core.Primerak
{
    public enum TipKoricenja
    {
        MEKO, TVRDO
    }
    public class Primerak
    {
        [JsonProperty("isbn")]
        public string isbn { get; set; }

        [JsonProperty("godina")]
        public int godina { get; set; }

        [JsonProperty("tipKoricenja")]
        public TipKoricenja tipKoricenja { get; set; }

        [JsonProperty("format")]
        public string format { get; set; }

        [JsonProperty("udk")]
        public string udk { get; set; }

        [JsonProperty("nabavnaCena")]
        public int nabavnaCena { get; set; }

        [JsonProperty("slobodna")]
        public bool slobodna { get; set; }

        [JsonProperty("izdavac")]
        public string izdavac { get; set; }

        [JsonProperty("nazivOgranka")]
        public string nazivOgranka { get; set; }

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

        public string GetIsbn()
        {
            return isbn;
        }

        public bool IsAvailable()
        {
            foreach (Zaduzenje.Zaduzenje zaduzenje in new ZaduzenjeRepository().Zaduzenja)
            {
                if (zaduzenje.IsPrimerak(this) && zaduzenje.IsActive())
                {
                    return false;
                }
            }
            return true;
        }

        public void SetSlobodna(bool b)
        {
            slobodna = b;
        }
    }
}
