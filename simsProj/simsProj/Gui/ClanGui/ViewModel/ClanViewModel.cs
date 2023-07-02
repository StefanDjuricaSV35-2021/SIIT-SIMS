using Prism.Commands;
using simsProj.Gui.ClanGui.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace simsProj.Gui.ClanGui.ViewModel
{
    public class ClanViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand IznajmiCommand { get; set; }
        public ICommand VratiCommand { get; set; }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ClanViewModel()
        {
           
            IznajmiCommand = new DelegateCommand(Iznajmi);
            VratiCommand = new DelegateCommand(Vrati);
            
        }

        public void Iznajmi()
        {
            new IznajmiWindow().Show();
        }

        public void Vrati()
        {
            new VratiWindow().Show();
        }




    }
}
