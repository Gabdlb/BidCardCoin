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
        int compteur = 0;
        public Ajout_ProduitCategorie()
        {
            InitializeComponent();
            DALConnection.OpenConnection();
            // Initialisation de la liste des personnes via la BDD.
            loadProduitCategories();

            appliquerContexte();
        }
        public void prenomChanged(object sender, TextChangedEventArgs e)
        {
            myDataObject.idProduitProperty = prenomTextBox.Text;
        }
        public void nomChanged(object sender, TextChangedEventArgs e)
        {
            myDataObject.idCategorieProperty = nomTextBox.Text;
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
            nomTextBox.DataContext = myDataObject;
            prenomTextBox.DataContext = myDataObject;
            produitcategorie.Content = new Article();

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
            nomTextBox.DataContext = myDataObject;
            prenomTextBox.DataContext = myDataObject;
        }
    }
}
