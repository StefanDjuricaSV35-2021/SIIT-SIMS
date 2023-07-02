using simsProj.Gui.BibliotekarGui.ViewModel;
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

namespace simsProj.Gui.Bibliotekar
{
    /// <summary>
    /// Interaction logic for SpecijalizovanBibliotekarWindow.xaml
    /// </summary>
    /// 
    public partial class SpecijalizovanBibliotekarWindow : Window
    {
        public SpecijalizovanBibliotekarViewModel ViewModel = new SpecijalizovanBibliotekarViewModel();
        public SpecijalizovanBibliotekarWindow()
        {
            InitializeComponent();
            DataContext = ViewModel;
        }
    }
}
