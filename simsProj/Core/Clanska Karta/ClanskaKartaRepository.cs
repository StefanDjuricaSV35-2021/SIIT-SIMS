using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace simsProj.Core.Clanska_Karta
{
    public class ClanskaKartaRepository
    {
        public List<ClanskaKarta> ClanskeKarte { get; set; }
        private string FilePath = "../../Data/clanskeKarte.json";

        public ClanskaKartaRepository()
        {
            GetAllClanskeKarte();
        }

        public void GetAllClanskeKarte()
        {
            ClanskeKarte = JsonConvert.DeserializeObject<List<ClanskaKarta>>(File.ReadAllText(FilePath));
        }

        public void Save()
        {
            File.WriteAllText(FilePath, JsonConvert.SerializeObject(ClanskeKarte, Formatting.Indented));
        }
    }
}
