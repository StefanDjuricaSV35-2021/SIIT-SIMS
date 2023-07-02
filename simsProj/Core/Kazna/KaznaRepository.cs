using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace simsProj.Core.Kazna
{
    public class KaznaRepository
    {
        public List<Kazna> Kazne { get; set; }
        private string FilePath = "../../Data/kazne.json";

        public KaznaRepository()
        {
            GetAllKazne();
        }

        public void GetAllKazne()
        {
            Kazne = JsonConvert.DeserializeObject<List<Kazna>>(File.ReadAllText(FilePath));
        }

        public void Save()
        {
            File.WriteAllText(FilePath, JsonConvert.SerializeObject(Kazne, Formatting.Indented));
        }
    }
}
