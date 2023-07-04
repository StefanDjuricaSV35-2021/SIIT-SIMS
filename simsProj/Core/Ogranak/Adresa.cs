using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simsProj.Core.Ogranak
{
    public class Adresa
    {
        [JsonProperty("grad")]
        private string grad; 
        
        [JsonProperty("ulica")]
        private string ulica;

        [JsonProperty("broj")]
        private string broj;

        public Adresa()
        {

        }

        public Adresa(string grad, string ulica, string broj)
        {
            this.grad = grad;
            this.ulica = ulica;
            this.broj = broj;
        }
    }
}
