using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace simsProj.Core.Primerak
{
    
    public class PrimerakRepository
    {
        public List<Primerak> Primerci { get; set; }
        private string FilePath = "../../../Data/primerci.json";

        public PrimerakRepository()
        {
            GetAllPrimerci();
        }

        public void GetAllPrimerci()
        {
            Primerci = JsonConvert.DeserializeObject<List<Primerak>>(File.ReadAllText(FilePath));
        }

        public void Save()
        {
            File.WriteAllText(FilePath, JsonConvert.SerializeObject(Primerci, Formatting.Indented));
        }
    }
}
