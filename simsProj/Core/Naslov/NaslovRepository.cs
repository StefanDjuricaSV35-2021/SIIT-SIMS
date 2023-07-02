using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace simsProj.Core.Naslov
{
    public class NaslovRepository
    {
        public List<Naslov> Naslovi { get; set; }
        private string FilePath = "../../../Data/naslovi.json";

        public NaslovRepository()
        {
            GetAllNaslovi();
        }

        public void GetAllNaslovi()
        {
            Naslovi = JsonConvert.DeserializeObject<List<Naslov>>(File.ReadAllText(FilePath));
        }

        public void Save()
        {
            File.WriteAllText(FilePath, JsonConvert.SerializeObject(Naslovi, Formatting.Indented));
        }
    }
}
