﻿using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;


namespace simsProj.Core.Zaduzenje
{
    public class ZaduzenjeRepository
    {
        public List<Zaduzenje> Zaduzenja { get; set; }
        private string FilePath = "../../../Data/zaduzenja.json";

        public ZaduzenjeRepository()
        {
            GetAllZaduzenja();
        }

        public void GetAllZaduzenja()
        {
            Zaduzenja = JsonConvert.DeserializeObject<List<Zaduzenje>>(File.ReadAllText(FilePath));
        }

        public void Save()
        {
            File.WriteAllText(FilePath, JsonConvert.SerializeObject(Zaduzenja, Formatting.Indented));
        }
    }
}
