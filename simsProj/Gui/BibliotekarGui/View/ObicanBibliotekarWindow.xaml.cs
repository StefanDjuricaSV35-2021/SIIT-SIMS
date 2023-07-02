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

namespace simsProj.Gui.BibliotekarGui.View
{
    /// <summary>
    /// Interaction logic for ObicanBibliotekarWindow.xaml
    /// </summary>
    using Gui.RegistracijaClanaGui.View;
    public partial class ObicanBibliotekarWindow : Window
    {
        public ObicanBibliotekarWindow()
        {
            InitializeComponent();
        }

        private void RegistracijaClana_Click(object sender, RoutedEventArgs e)
        {
            new RegistracijaClana().Show();
        }
    }
}
