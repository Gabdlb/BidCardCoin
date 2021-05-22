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
    /// Logique d'interaction pour Ajout_Categorie.xaml
    /// </summary>
    public partial class Ajout_Categorie : Page
    {
        CategorieViewModel myDataObject; // Objet de liaison avec la vue lors de l'ajout d'une Categorie par exemple.
        ObservableCollection<CategorieViewModel> lp;
        int compteur = 0;
        public Ajout_Categorie()
        {
            InitializeComponent();

            DALConnection.OpenConnection();
            // Initialisation de la liste des Categories via la BDD.
            loadCategories();

            appliquerContexte();
        }

        public void nomChanged(object sender, TextChangedEventArgs e)
        {
            myDataObject.nomProperty = nomTextBox.Text;
        }
        private void Btn_Ajout(object sender, RoutedEventArgs e)
        {
            myDataObject.idCategorieProperty = CategorieDAL.getMaxIdCategorie() + 1;

            lp.Add(myDataObject);
            CategorieORM.insertCategorie(myDataObject);
            compteur = lp.Count();

            // Comme on a inséré une Categorie, on crée un nouvel objet CategorieViewModel
            // Et on réatache tout ce qu'il faut pour que la vue soit propre
            myDataObject = new CategorieViewModel();

            // Comme le contexte des élément de la vue est encore l'ancien CategorieViewModel,
            // On refait les liens entre age, slider, textbox, bouton et le nouveau CategorieViewModel
            nomTextBox.DataContext = myDataObject;
            categorie.Content = new Categorie();

        }
        private void Btn_Retour(object sender, RoutedEventArgs e)
        {
            categorie.Content = new Categorie();
        }

        void loadCategories()
        {
            lp = CategorieORM.listeCategories();
            myDataObject = new CategorieViewModel();
            //LIEN AVEC la VIEW
        }

        void appliquerContexte()
        {
            // Lien avec les textbox
            nomTextBox.DataContext = myDataObject;
        }
    }
}
