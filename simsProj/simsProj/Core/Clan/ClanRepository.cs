using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;


namespace simsProj.Core.Clan
{
    public class ClanRepository
    {
        public List<Clan> Clanovi { get; set; }
        private string FilePath = "../../Data/clanovi.json";

        public ClanRepository()
        {
            GetAllClanovi();
        }

        public void GetAllClanovi()
        {
            Clanovi = JsonConvert.DeserializeObject<List<Clan>>(File.ReadAllText(FilePath));
        }

        public void Save()
        {
            File.WriteAllText(FilePath, JsonConvert.SerializeObject(Clanovi, Formatting.Indented));
        }
    }
}
