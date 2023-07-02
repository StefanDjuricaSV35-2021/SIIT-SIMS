using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simsProj.Core.Korisnik
{
    using Core.Clan;
    using Core.ObicanBibliotekar;
    using Core.SpecijalizovanBibliotekar;
    public class KorisnickiNalog
    {
        

        [JsonProperty("username")]
        public string username;

        [JsonProperty("password")]
        public string password;

        public KorisnickiNalog() { }

        public KorisnickiNalog(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        
    }
}
