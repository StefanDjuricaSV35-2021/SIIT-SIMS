﻿using simsProj.Gui.RadSaFondomGui.ViewModel;
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
    /// Interaction logic for RegistrujNoviPrimerakView.xaml
    /// </summary>
    public partial class RegistrujNoviPrimerakView : Window
    {
        public RegistrujNoviPrimerakViewModel ViewModel=new RegistrujNoviPrimerakViewModel();
        public RegistrujNoviPrimerakView()
        {
            InitializeComponent();
            DataContext = ViewModel;
        }
    }
}
