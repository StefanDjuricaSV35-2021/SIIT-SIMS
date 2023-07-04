using simsProj.Gui.ClanGui.ViewModel;
using simsProj.Gui.ZaduzenjeGui.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using simsProj.Core.Naslov;
using simsProj.Core.Primerak;
using simsProj.Core.Zaduzenje;
using simsProj.Gui.ZaduzenjeGui.ViewModel;

namespace simsProj.Gui.ZaduzenjeGui.Command
{
    public class ZaduziPrimerakCommand : BaseCommand
    {
        private ZaduzenjeViewModel zaduzenjeViewModel;
        public event EventHandler<bool> LoginEvent;
        public ZaduziPrimerakCommand(ZaduzenjeViewModel zaduzenjeViewModel)
        {
            this.zaduzenjeViewModel = zaduzenjeViewModel;
        }
        public bool CanExecute(object? parameter)
        {
            if (zaduzenjeViewModel.SelectedNaslov == null)
            {
                MessageBox.Show("Morate izabrati naslov koji zelite da zaduzite.");
                return false;
            }

            if (zaduzenjeViewModel.maxZaduzenja <= zaduzenjeViewModel.currentZaduzenjeNum)
            {
                MessageBox.Show("Morate imati manji broj zaduzenih knjiga od dozvoljenog da bi ste mogli jos da ih zaduzujete.");
                return false;
            }
            return true;
        }
        public override void Execute(object parameter)
        {
            if (CanExecute(parameter))
            {
                
                foreach (Primerak primerak in zaduzenjeViewModel.naslovRepository.GetNaslovPrimerci(zaduzenjeViewModel.SelectedNaslov.naslov))
                {
                    if (primerak.IsAvailable())
                    {
                        Zaduzenje zaduzenje = new Zaduzenje(primerak.GetIsbn(), zaduzenjeViewModel.LogedInClan.jmbg, DateTime.Now, DateTime.Now.AddDays(zaduzenjeViewModel.LogedInClan.GetClanskaKarta().getMaxKnjiga()), StanjeKnjige.NEOSTECENA, StanjeZaduzenja.AKTIVNO);
                        
                        PrimerakRepository primerakRepository = new PrimerakRepository();
                        primerakRepository.ZaduziPrimerak(primerak);

                        zaduzenjeViewModel.zaduzenjeRepository.Add(zaduzenje);

                        zaduzenjeViewModel.currentZaduzenjeNum += 1;

                        MessageBox.Show("Uspesno zaduzen primer.");
                        return;
                    }
                }


                MessageBoxResult result = MessageBox.Show("Nije nadjen ni jedan slobodan primer za taj naslov da li zelite da ga rezervisete?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                if (result == MessageBoxResult.Yes)
                {
                    zaduzenjeViewModel.naslovRepository.AddReservation(zaduzenjeViewModel.SelectedNaslov.naslov, zaduzenjeViewModel.LogedInClan);
                    MessageBox.Show("Uspesno rezervisan primer primer.");
                }

            }
            
        }
    }
}
