﻿using BidCardCoin.Vue.Ajouter;
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

namespace BidCardCoin.Vue
{
    /// <summary>
    /// Logique d'interaction pour Article.xaml
    /// </summary>
    public partial class Article : Page
    {
        public Article()
        {
            InitializeComponent();
        }

        private void Btn_AjArt(object sender, RoutedEventArgs e)
        {
            article.Content = new Ajout_Article();
        }
    }
}