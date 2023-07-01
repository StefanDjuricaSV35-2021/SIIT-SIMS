﻿using Newtonsoft.Json;
using simsProj.Core.Clanska_Karta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simsProj.Core.Naslov
{
    public class Naslov
    {
        [JsonProperty("naslov")]
        private string naslov;

        [JsonProperty("opis")]
        private string opis;

        [JsonProperty("br citanja")]
        private int brCitanja;

        [JsonProperty("lista cekanja")] 
        private List<Clan.Clan> listaCekanja;

        [JsonProperty("autori")]
        private List<Autor.Autor> autori;

        [JsonProperty("primerci")]
        private List<string> primerci;

        public Naslov()
        {
        }

        public Naslov(string naslov, string opis, int brCitanja, List<Clan.Clan> listaCekanja, List<Autor.Autor> autori, List<string> primerci)
        {
            this.naslov = naslov;
            this.opis = opis;
            this.brCitanja = brCitanja;
            this.listaCekanja = listaCekanja;
            this.autori = autori;
            this.primerci = primerci;
        }

        public Naslov(string naslov, string opis, int brCitanja, List<Autor.Autor> autori, List<string> primerci)
        {
            this.naslov = naslov;
            this.opis = opis;
            this.brCitanja = brCitanja;
            this.listaCekanja = new List<Clan.Clan>();
            this.autori = autori;
            this.primerci = primerci;
        }
    }
}