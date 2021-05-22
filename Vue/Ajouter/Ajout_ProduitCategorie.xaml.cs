using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Linq;
using System.Windows.Media;
using System.Collections.ObjectModel;
namespace BidCardCoin.Vue.Ajouter
{
    /// <summary>
    /// Logique d'interaction pour Ajout_ProduitCategorie.xaml
    /// </summary>
    public partial class Ajout_ProduitCategorie : Page
    {
        Produit_CategorieViewModel myDataObject; // Objet de liaison avec la vue lors de l'ajout d'une personne par exemple.
        ObservableCollection<Produit_CategorieViewModel> lp;

        ProduitViewModel myDataObjectProduit; // Objet de liaison avec la vue lors de l'ajout d'une personne par exemple.
        ObservableCollection<ProduitViewModel> pr;

        CategorieViewModel myDataObjectCategorie; // Objet de liaison avec la vue lors de l'ajout d'une personne par exemple.
        ObservableCollection<CategorieViewModel> lc;

        int compteur = 0;
        public Ajout_ProduitCategorie()
        {
            InitializeComponent();
            DALConnection.OpenConnection();
            // Initialisation de la liste des personnes via la BDD.
            loadProduitCategories();
            loadProduits();
            loadCategories();


            appliquerContexte();
        }
       
        private void Btn_Ajout(object sender, RoutedEventArgs e)
        {
            lp.Add(myDataObject);
            Produit_CategorieORM.insertProduit_Categorie(myDataObject);
            compteur = lp.Count();

            // Comme on a inséré une personne, on crée un nouvel objet PersonneViewModel
            // Et on réatache tout ce qu'il faut pour que la vue soit propre
            myDataObject = new Produit_CategorieViewModel();

            // Comme le contexte des élément de la vue est encore l'ancien PersonneViewModel,
            // On refait les liens entre age, slider, textbox, bouton et le nouveau PersonneViewModel

            ComboBoxProduit.DataContext = myDataObject;
            ComboBoxCategorie.DataContext = myDataObject;

        }
        private void Btn_Retour(object sender, RoutedEventArgs e)
        {
            produitcategorie.Content = new Article();
        }
        void loadProduitCategories()
        {
            lp = Produit_CategorieORM.listeProduit_Categories();
            myDataObject = new Produit_CategorieViewModel();
            //LIEN AVEC la VIEW
        }

        void appliquerContexte()
        {
            // Lien avec les textbox
            ComboBoxProduit.DataContext = myDataObject;
            ComboBoxCategorie.DataContext = myDataObject;
        }

        void loadProduits()
        {
            pr = ProduitORM.listeProduits();
            myDataObjectProduit = new ProduitViewModel();
            ComboBoxProduit.ItemsSource = pr;
            //LIEN AVEC la VIEW
            //List_Produit.ItemsSource = lp; // bind de la liste avec la source, permettant le binding.
        }

        void loadCategories()
        {
            lc = CategorieORM.listeCategories();
            myDataObjectCategorie = new CategorieViewModel();
            ComboBoxCategorie.ItemsSource = lc;
            //LIEN AVEC la VIEW
            //List_Categorie.ItemsSource = lp; // bind de la liste avec la source, permettant le binding.
        }
    }
}
