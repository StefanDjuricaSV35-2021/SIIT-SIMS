using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simsProj.Core.Transakcija
{
    public enum SvrhaPlacanja
    {
        KAZNA,CLANARINA
    }
    public class Transakcija
    {
        [JsonProperty("jmbg")]
        private string jmbg;

        [JsonProperty("datum placanja")]
        private DateTime datumPlacanja;

        [JsonProperty("iznos")]
        private int iznos;

        [JsonProperty("svrha placanja")]
        private SvrhaPlacanja svrha;

        public Transakcija(){}

        public Transakcija(string jmbg, DateTime datumPlacanja, int iznos, SvrhaPlacanja svrha)
        {
            this.jmbg = jmbg;
            this.datumPlacanja = datumPlacanja;
            this.iznos = iznos;
            this.svrha = svrha;
        }

        public Transakcija(string jmbg, int iznos, SvrhaPlacanja svrha)
        {
            this.jmbg = jmbg;
            datumPlacanja = DateTime.Now;
            this.iznos = iznos;
            this.svrha = svrha;
        }


    }
}
