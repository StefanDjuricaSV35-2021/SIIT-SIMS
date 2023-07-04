using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace simsProj.Core.Clanska_Karta
{
    public class ClanskaKartaRepository
    {
        public List<ClanskaKarta> ClanskeKarte { get; set; }
        private string FilePath = "../../../Data/clanskeKarte.json";

        public ClanskaKartaRepository()
        {
            GetAllClanskeKarte();
        }
        public List<ClanskaKarta> GetClanskeKarte()
        {
            return ClanskeKarte;
        }
        public void GetAllClanskeKarte()
        {
            ClanskeKarte = JsonConvert.DeserializeObject<List<ClanskaKarta>>(File.ReadAllText(FilePath));
        }
        public ClanskaKarta? GetClanskaKartaByBr(string brKarte)
        {
            foreach(ClanskaKarta clanskaKarta in ClanskeKarte)
            {
                if (clanskaKarta.brClanskeKarte == brKarte)
                    return clanskaKarta;
            }
            return null;
        }
        public void Save()
        {
            File.WriteAllText(FilePath, JsonConvert.SerializeObject(ClanskeKarte, Formatting.Indented));
        }
    }
}
