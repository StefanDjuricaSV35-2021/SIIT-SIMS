
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
using simsProj.Gui.ClanGui.ViewModel;

namespace simsProj.Gui.ClanGui.View
{
    /// <summary>
    /// Interaction logic for ClanWindow.xaml
    /// </summary>
    public partial class ClanWindow : Window
    {
        public ClanWindow(Clan LoginClan)
        {
            InitializeComponent();
            DataContext = new ClanViewModel(LoginClan);
        }
    }
}
