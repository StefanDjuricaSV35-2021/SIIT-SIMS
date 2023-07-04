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
    using simsProj.Core.Clan;
    public partial class ObicanBibliotekarWindow : Window
    {
        public ObicanBibliotekarWindow()
        {
            InitializeComponent();
            RefreshListBox();
        }
        public void RefreshListBox()
        {
            listBoxClanovi.Items.Clear();
            ClanRepository clanRepository = new ClanRepository();
            foreach (Clan clan in clanRepository.Clanovi)
            {
                string s = clan.ime + " " + clan.prezime + " " + clan.email + " " + clan.jmbg + " " + clan.nalog.username;
                listBoxClanovi.Items.Add(s);
            }
            listBoxClanovi.Items.Refresh();
        }
        private void RegistracijaClana_Click(object sender, RoutedEventArgs e)
        {
            new RegistracijaClana().Show();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            ClanRepository clanRepository = new ClanRepository();
            if (listBoxClanovi.SelectedItem != null)
            {
                string selected = listBoxClanovi.SelectedItem.ToString().Split(" ")[4];
                Clan selectedClan = clanRepository.FindClanByUsername(selected);

                clanRepository.Clanovi.Remove(selectedClan);
                clanRepository.Save();
                MessageBox.Show("Clan uspesno obrisan!");
                RefreshListBox();
            }
            else
            {
                MessageBox.Show("Niste izabrali clana za brisanje!");
            }
            
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshListBox();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            ClanRepository clanRepository = new ClanRepository();
            if (listBoxClanovi.SelectedItem != null)
            {
                string selected = listBoxClanovi.SelectedItem.ToString().Split(" ")[4];
                Clan selectedClan = clanRepository.FindClanByUsername(selected);

                new EditClan(selectedClan).Show();
                //RefreshListBox();
            }
            else
            {
                MessageBox.Show("Niste izabrali clana za izmenu!");
            }
            
        }
    }
}
