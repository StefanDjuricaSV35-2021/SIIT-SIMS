using simsProj.Gui.ClanGui.ViewModel;
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

namespace simsProj.Gui.ClanGui.View
{
    /// <summary>
    /// Interaction logic for VratiWindow.xaml
    /// </summary>
    public partial class VratiWindow : Window
    {
        public VratiViewModel viewModel { get; set; }
        public VratiWindow()
        {
            InitializeComponent();
            viewModel = new VratiViewModel();
            DataContext = viewModel;
        }
    }
}
