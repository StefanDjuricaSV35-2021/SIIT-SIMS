using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simsProj.Core.Korisnik
{
    
    public class KorisnickiNalog
    {

        [JsonProperty("username")]
        private string username;

        [JsonProperty("password")]
        private string password;

        public KorisnickiNalog() { }

        public KorisnickiNalog(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }
}
