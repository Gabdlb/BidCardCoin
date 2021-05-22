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
    /// Logique d'interaction pour Accueil.xaml
    /// </summary>
    public partial class Accueil : Window
    {
        public Accueil()
        {
            InitializeComponent();

        }
        private void Button_Article(object sender, RoutedEventArgs e)
        {
            accueil.Content = new Article();
        }

        private void Button_Categorie(object sender, RoutedEventArgs e)
        {
            accueil.Content = new Categorie();
        }

        private void Button_Lieu(object sender, RoutedEventArgs e)
        {
            accueil.Content = new Lieu();
        }

        private void Button_Comm(object sender, RoutedEventArgs e)
        {
            accueil.Content = new Commissaire();
        }

        private void Button_Utilisateur(object sender, RoutedEventArgs e)
        {
            accueil.Content = new Utilisateur();
        }

        private void Button_Personne(object sender, RoutedEventArgs e)
        {
            accueil.Content = new Personne();
        }
    }
}
