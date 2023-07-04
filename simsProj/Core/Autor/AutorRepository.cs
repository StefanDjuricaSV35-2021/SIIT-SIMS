using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace simsProj.Core.Autor
{
    public class AutorRepository
    {
        public List<Autor> Autori { get; set; }
        private string FilePath = "../../Data/autori.json";

        public AutorRepository()
        {
            GetAllAutori();
        }

        public void GetAllAutori()
        {
            Autori = JsonConvert.DeserializeObject<List<Autor>>(File.ReadAllText(FilePath));
        }

        public void Save()
        {
            File.WriteAllText(FilePath, JsonConvert.SerializeObject(Autori, Formatting.Indented));
        }
    }
}
