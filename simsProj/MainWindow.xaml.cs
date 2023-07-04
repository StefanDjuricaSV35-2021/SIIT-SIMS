using simsProj.Core.Clan;
using simsProj.Core.Korisnik;
using simsProj.Core.ObicanBibliotekar;
using simsProj.Core.SpecijalizovanBibliotekar;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace simsProj
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    using Core.Login;
    using Gui.Login;
    public partial class MainWindow : UserControl
    {
        public ClanRepository ClanRepository { get; set; }
        public ObicanBibliotekarRepository ObicanBibliotekarRepository { get; set; }
        public SpecijalizovanBibliotekarRepository SpecijalizovanBibliotekarRepository { get; set; }
        public MainWindow()
        {
            ClanRepository = new ClanRepository();
            ObicanBibliotekarRepository = new ObicanBibliotekarRepository();
            SpecijalizovanBibliotekarRepository = new SpecijalizovanBibliotekarRepository();
            InitializeComponent();
            DataContext = new LoginViewModel();
        }
    }
}
