using simsProj.Core.Naslov;
using simsProj.Gui.RadSaFondomGui.ViewModel;
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

namespace simsProj.Gui.RadSaFondomGui.View
{
    /// <summary>
    /// Interaction logic for PrimerciReview.xaml
    /// </summary>
    public partial class PrimerciReview : Window
    {
        public PrimerciReviewViewModel ViewModel;
        public PrimerciReview(Naslov naslov)
        {
            InitializeComponent();
            ViewModel = new PrimerciReviewViewModel(naslov);
            DataContext = ViewModel;
            ViewModel.fillTable();
            ViewModel.TrenutniProzor = this;

        }
    }
}
