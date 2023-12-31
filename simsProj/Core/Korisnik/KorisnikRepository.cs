﻿using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;


namespace simsProj.Core.Korisnik
{
    
    public class KorisnikRepository
    {
        public List<Korisnik> Korisnici { get; set; }
        private string FilePath = "../../Data/korisnici.json";

        public KorisnikRepository()
        {
            GetAllKorisnici();
        }

        public void GetAllKorisnici()
        {
            Korisnici = JsonConvert.DeserializeObject<List<Korisnik>>(File.ReadAllText(FilePath));
        }

        public void Save()
        {
            File.WriteAllText(FilePath, JsonConvert.SerializeObject(Korisnici, Formatting.Indented));
        }

    }
}
