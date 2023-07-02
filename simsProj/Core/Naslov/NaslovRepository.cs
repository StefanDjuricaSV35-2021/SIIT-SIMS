using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using simsProj.Gui.ZaduzenjeGui.ViewModel;

namespace simsProj.Core.Naslov
{
    public class NaslovRepository
    {
        public List<Naslov> Naslovi { get; set; }
        private string FilePath = "../../../Data/naslovi.json";

        public NaslovRepository()
        {
            GetAllNaslovi();
        }

        public void GetAllNaslovi()
        {
            Naslovi = JsonConvert.DeserializeObject<List<Naslov>>(File.ReadAllText(FilePath));
        }

        public List<Primerak.Primerak> GetNaslovPrimerci(string naslov)
        {
            Naslov Naslov = GetNaslov(naslov);
            if (Naslov != null)
            {
                return Naslov.GetPrimerci();
            }
            return null;
        }

        public Naslov GetNaslov(string Naslov)
        {
            foreach (Naslov naslov in Naslovi)
            {
                if (naslov.GetNaslov() == Naslov)
                {
                    return naslov;
                }
            }

            return null;
        }

        public List<NaslovViewModel> GetNaslovData()
        {
            List<NaslovViewModel> naslovViewModels = new List<NaslovViewModel>();
            foreach (Naslov naslov in Naslovi)
            {
                naslovViewModels.Add(new NaslovViewModel(naslov));
            }
            return naslovViewModels;
        }

        public List<Naslov> GetNaslovi()
        {
            return Naslovi;
        }
        public void Save()
        {
            File.WriteAllText(FilePath, JsonConvert.SerializeObject(Naslovi, Formatting.Indented));
        }

        public void AddReservation(string Naslov, Clan.Clan clan)
        {
            foreach (Naslov naslov in Naslovi)
            {
                if (Naslov == naslov.GetNaslov())
                {
                    naslov.AddReservation(clan);
                    Save();
                    return;
                }
            }
        }
    }
}
