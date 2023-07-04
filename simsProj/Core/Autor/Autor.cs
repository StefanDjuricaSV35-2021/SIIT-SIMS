using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simsProj.Core.Autor
{
    public class Autor
    {
        [JsonProperty("ime")]
        public string ime;

        [JsonProperty("prezime")]
        public string prezime;

        public Autor() { }

        public Autor(string ime, string prezime)
        {
            this.ime = ime;
            this.prezime = prezime;
        }
    }
}
