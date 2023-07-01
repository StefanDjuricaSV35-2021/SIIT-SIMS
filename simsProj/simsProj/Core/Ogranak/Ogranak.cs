using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simsProj.Core.Ogranak
{
    public class Ogranak
    {
        [JsonProperty("adresa")]
        private Adresa adresa;

        [JsonProperty("naziv ogranka")]
        private string nazivOgranka;

        [JsonProperty("neradni Dani")]
        private List<DateTime> neradniDani;

        public Ogranak()
        {

        }

        public Ogranak(Adresa adresa, string nazivOgranka, List<DateTime> neradniDani)
        {
            this.adresa = adresa;
            this.nazivOgranka = nazivOgranka;
            this.neradniDani = neradniDani;
        }
    }
}
