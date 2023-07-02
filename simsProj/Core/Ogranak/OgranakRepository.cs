using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace simsProj.Core.Ogranak
{
    public class OgranakRepository
    {
        public List<Ogranak> Ogranci { get; set; }
        private string FilePath = "../../Data/ogranci.json";

        public OgranakRepository()
        {
            GetAllOgranci();
        }

        public void GetAllOgranci()
        {
            Ogranci = JsonConvert.DeserializeObject<List<Ogranak>>(File.ReadAllText(FilePath));
        }

        public void Save()
        {
            File.WriteAllText(FilePath, JsonConvert.SerializeObject(Ogranci, Formatting.Indented));
        }
    }
}
