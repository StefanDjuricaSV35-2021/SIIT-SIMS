using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using simsProj.Core.Clan;
using simsProj.Gui.ZaduzenjeGui.ViewModel;

namespace simsProj.Gui.ZaduzenjeGui.View
{
    /// <summary>
    /// Interaction logic for ZaduzenjeWindow.xaml
    /// </summary>
    public partial class ZaduzenjeWindow : Window
    {
        public ZaduzenjeWindow(Clan clan)
        {
            InitializeComponent();
            DataContext = new ZaduzenjeViewModel(clan);
        }
    }
}
