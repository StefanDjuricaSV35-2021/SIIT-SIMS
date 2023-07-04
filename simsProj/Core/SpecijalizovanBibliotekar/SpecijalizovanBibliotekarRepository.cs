using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace simsProj.Core.SpecijalizovanBibliotekar
{
    public class SpecijalizovanBibliotekarRepository
    {
        public List<SpecijalizovanBibliotekar> SpecijalizovaniBibliotekari { get; set; }
        private string FilePath = "../../../Data/specijalizovaniBibliotekari.json";

        public SpecijalizovanBibliotekarRepository()
        {
            GetAllBibliotekari();
        }

        public void GetAllBibliotekari()
        {
            SpecijalizovaniBibliotekari = JsonConvert.DeserializeObject<List<SpecijalizovanBibliotekar>>(File.ReadAllText(FilePath));
        }

        public void Save()
        {
            File.WriteAllText(FilePath, JsonConvert.SerializeObject(SpecijalizovaniBibliotekari, Formatting.Indented));
        }
    }
}
