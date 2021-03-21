﻿using System;
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

namespace BidCardCoin.Vue
{
    /// <summary>
    /// Logique d'interaction pour Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("L'application se ferme");

            this.Close();
        }
        private void BtnConnect_Click(object sender, RoutedEventArgs e)
        {

            Accueil wnd = new Accueil();
            wnd.ShowDialog();
            this.Close();
        }
    }
}
