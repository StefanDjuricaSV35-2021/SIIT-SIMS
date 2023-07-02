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
        private string ime;

        [JsonProperty("prezime")]
        private string prezime;

        public Autor() { }

        public Autor(string ime, string prezime)
        {
            this.ime = ime;
            this.prezime = prezime;
        }
    }
}
