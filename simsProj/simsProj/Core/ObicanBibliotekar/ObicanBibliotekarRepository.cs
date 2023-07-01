using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;


namespace simsProj.Core.ObicanBibliotekar
{
    public class ObicanBibliotekarRepository
    {
        public List<ObicanBibliotekar> ObicniBibliotekari { get; set; }
        private string FilePath = "../../../Data/obicniBibliotekari.json";

        public ObicanBibliotekarRepository()
        {
            GetAllBibliotekari();
        }

        public void GetAllBibliotekari()
        {
            ObicniBibliotekari = JsonConvert.DeserializeObject<List<ObicanBibliotekar>>(File.ReadAllText(FilePath));
        }

        public void Save()
        {
            File.WriteAllText(FilePath, JsonConvert.SerializeObject(ObicniBibliotekari, Formatting.Indented));
        }
    }
}
