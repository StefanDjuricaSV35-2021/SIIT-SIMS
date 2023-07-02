using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;


namespace simsProj.Core.Admin
{
    public class AdminRepository
    {
        public List<Admin> Admini { get; set; }
        private string FilePath = "../../Data/admini.json";

        public AdminRepository()
        {
            GetAllAdmini();
        }

        public void GetAllAdmini()
        {
            Admini = JsonConvert.DeserializeObject<List<Admin>>(File.ReadAllText(FilePath));
        }

        public void Save()
        {
            File.WriteAllText(FilePath, JsonConvert.SerializeObject(Admini, Formatting.Indented));
        }
    }
}
