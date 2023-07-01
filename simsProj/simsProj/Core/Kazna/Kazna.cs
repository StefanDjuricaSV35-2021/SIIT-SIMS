using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simsProj.Core.Kazna
{
    public class Kazna
    {
        [JsonProperty("jmbg")]
        private string jmbg;

        [JsonProperty("datum kazne")]
        private DateTime datumKazne;

        [JsonProperty("iznos")]
        private int iznos;

        [JsonProperty("placena")]
        private bool placena;

        [JsonProperty("id kazne")]
        private string idKazne;

        public Kazna(){}

        public Kazna(string jmbg, DateTime datumKazne, int iznos, bool placena, string idKazne)
        {
            this.jmbg = jmbg;
            this.datumKazne = datumKazne;
            this.iznos = iznos;
            this.placena = placena;
            this.idKazne = idKazne;
        }
    }
}
