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
using BidCardCoin.Vue.Ajouter;
using System.Collections.ObjectModel;

namespace BidCardCoin.Vue
{
    /// <summary>
    /// Logique d'interaction pour Article.xaml
    /// </summary>
    public partial class Article : Page
    {
        int selectedProduitId;
        ProduitViewModel myDataObject; // Objet de liaison avec la vue lors de l'ajout d'une Produit par exemple.
        ObservableCollection<ProduitViewModel> lp;
        ObservableCollection<ProduitViewModel> az;

        ProduitViewModel myDataObjectCP; // Objet de liaison avec la vue lors de l'ajout d'une Produit par exemple.
        ObservableCollection<ProduitViewModel> cp;
        public Article()
        {
            InitializeComponent();
            
            DALConnection.OpenConnection();
            // Initialisation de la liste des Produits via la BDD.
            loadProduits();
        }
        private void Btn_Sppr(object sender, RoutedEventArgs e)
        {
            if (List_Produit.SelectedItem is ProduitViewModel)
            {
                ProduitViewModel toRemove = (ProduitViewModel)List_Produit.SelectedItem;
                lp.Remove(toRemove);
                List_Produit.Items.Refresh();
                ProduitORM.supprimerProduit(selectedProduitId);
            }
        }

        private void listeProduits_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((List_Produit.SelectedIndex < lp.Count) && (List_Produit.SelectedIndex >= 0))
            {
                selectedProduitId = (lp.ElementAt<ProduitViewModel>(List_Produit.SelectedIndex)).idProduitProperty;
            }
        }

    
        void loadProduits()
        {
            lp = ProduitORM.listeProduits();
            az = ProduitORM.listeProduits();
            myDataObject = new ProduitViewModel();
            //LIEN AVEC la VIEW
            List_Produit.ItemsSource = lp; // bind de la liste avec la source, permettant le binding.
            ComboBoxProduit.ItemsSource = az;
        }

        private void Btn_AjArt(object sender, RoutedEventArgs e)
        {
            article.Content = new Ajout_Produit();
        }

        private void Btn_ProdCat(object sender, RoutedEventArgs e)
        {
            article.Content = null;
            article.Content = new Ajout_ProduitCategorie();
            
        }

        private void BtnAfficherCat(object sender, RoutedEventArgs e)
        {
            cp = ProduitORM.getNomProduit(Convert.ToInt32(ComboBoxProduit.SelectedValue.ToString()));

            myDataObjectCP = new ProduitViewModel();

            listeCP.ItemsSource = cp;

            listeCP.DataContext = myDataObjectCP;

            listeCP.Items.Refresh();
        }

       
    }
}
