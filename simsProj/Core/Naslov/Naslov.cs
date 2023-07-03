using Newtonsoft.Json;
using simsProj.Core.Clanska_Karta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using simsProj.Core.Primerak;

namespace simsProj.Core.Naslov
{
    public class Naslov
    {
        [JsonProperty("naslov")]
        public string naslov { get; set; }

        [JsonProperty("opis")]
        public string opis { get; set; }

        [JsonProperty("brCitanja")]
        public int brCitanja { get; set; }

        [JsonProperty("listaCekanja")] 
        public List<Clan.Clan> listaCekanja { get; set; }

        [JsonProperty("autori")]
        public List<Autor.Autor> autori { get; set; }

        [JsonProperty("primerci")]
        public List<string> primerci { get; set; }

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

        public string GetNaslov() { return naslov; }
        public string GetOpis() { return opis; }

        public List<Primerak.Primerak> GetPrimerci()
        { 
           List<Primerak.Primerak> retPrimerci = new List<Primerak.Primerak>();
           PrimerakRepository primerakRepository = new PrimerakRepository();

           foreach (Primerak.Primerak primerak in primerakRepository.Primerci)
           {
               if(primerci.Contains(primerak.GetIsbn()))
               {
                   retPrimerci.Add(primerak);
               }
           }

           return retPrimerci;
        }

        public void AddReservation(Clan.Clan clan)
        {
            listaCekanja.Add(clan);
        }
    }
}
