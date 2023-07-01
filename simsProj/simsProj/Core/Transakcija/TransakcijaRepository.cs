using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace simsProj.Core.Transakcija
{
    public class TransakcijaRepository
    {
        public List<Transakcija> Transakcije { get; set; }
        private string FilePath = "../../Data/transakcije.json";

        public TransakcijaRepository()
        {
            GetAllTransakcije();
        }

        public void GetAllTransakcije()
        {
            Transakcije = JsonConvert.DeserializeObject<List<Transakcija>>(File.ReadAllText(FilePath));
        }

        public void Save()
        {
            File.WriteAllText(FilePath, JsonConvert.SerializeObject(Transakcije, Formatting.Indented));
        }
    }
}
