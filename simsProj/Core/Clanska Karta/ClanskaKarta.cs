using Newtonsoft.Json;
using System;

namespace simsProj.Core.Clanska_Karta
{
    public enum TipClanstva
    {
        DECA,STUDENTI,PENZIONERI,ODRASLI
    }
    public class ClanskaKarta
    {
        [JsonProperty("broj clanske karte")]
        public string brClanskeKarte;

        [JsonProperty("clanstvo")]
        public TipClanstva clanstvo;

        [JsonProperty("datum placanja")]
        private DateTime datumPlacanja;

        public ClanskaKarta(){}

        public ClanskaKarta(string brClanskeKarte, TipClanstva clanstvo, DateTime datumPlacanja)
        {
            this.brClanskeKarte = brClanskeKarte;
            this.clanstvo = clanstvo;
            this.datumPlacanja = datumPlacanja;
        }

        public string GetBrClanskeKarte()
        {
            return brClanskeKarte;
        }

        public int getMaxDana()
        {
            if (clanstvo == TipClanstva.DECA)
            {
                return 4;
            }
            if (clanstvo == TipClanstva.ODRASLI)
            {
                return 5;
            }
            if (clanstvo == TipClanstva.PENZIONERI)
            {
                return 7;
            }
            return 14;
        }

        public int getMaxKnjiga()
        {
            if (clanstvo == TipClanstva.DECA)
            {
                return 2;
            }
            if (clanstvo == TipClanstva.ODRASLI)
            {
                return 5;
            }
            if (clanstvo == TipClanstva.PENZIONERI)
            {
                return 7;
            }
            return 8;
        }
    }
}
