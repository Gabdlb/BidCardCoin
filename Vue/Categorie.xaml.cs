using System.Windows;
using System;
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
using System.Linq;

namespace BidCardCoin.Vue
{
    /// <summary>
    /// Logique d'interaction pour Categorie.xaml
    /// </summary>
    public partial class Categorie : Page
    {
        int selectedCategorieId;
        CategorieViewModel myDataObject; // Objet de liaison avec la vue lors de l'ajout d'une Categorie par exemple.
        ObservableCollection<CategorieViewModel> lp;

        ObservableCollection<CategorieViewModel> az;

        CategorieViewModel myDataObjectCP; // Objet de liaison avec la vue lors de l'ajout d'une Produit par exemple.
        ObservableCollection<CategorieViewModel> cp;
        public Categorie()
        {
            InitializeComponent();

            DALConnection.OpenConnection();
            // Initialisation de la liste des Categories via la BDD.
            loadCategories();
        }
        private void Btn_Sppr(object sender, RoutedEventArgs e)
        {
            if (List_Categorie.SelectedItem is CategorieViewModel)
            {
                CategorieViewModel toRemove = (CategorieViewModel)List_Categorie.SelectedItem;
                lp.Remove(toRemove);
                List_Categorie.Items.Refresh();
                CategorieORM.supprimerCategorie(selectedCategorieId);
            }
        }

        private void listeCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((List_Categorie.SelectedIndex < lp.Count) && (List_Categorie.SelectedIndex >= 0))
            {
                selectedCategorieId = (lp.ElementAt<CategorieViewModel>(List_Categorie.SelectedIndex)).idCategorieProperty;
            }
        }

        void loadCategories()
        {
            lp = CategorieORM.listeCategories();
            az = CategorieORM.listeCategories();
            myDataObject = new CategorieViewModel();
            //LIEN AVEC la VIEW
            List_Categorie.ItemsSource = lp; // bind de la liste avec la source, permettant le binding.
            ComboBoxCategorie.ItemsSource = az;
        }

        private void Btn_AjPrs(object sender, RoutedEventArgs e)
        {
            categorie.Content = new Ajout_Categorie();
        }

        private void BtnAfficherProd(object sender, RoutedEventArgs e)
        {
            cp = CategorieORM.getNomCategorie(Convert.ToInt32(ComboBoxCategorie.SelectedValue.ToString()));

            myDataObjectCP = new CategorieViewModel();

            listeCP.ItemsSource = cp;

            listeCP.DataContext = myDataObjectCP;

            listeCP.Items.Refresh();
        }
    }
}
