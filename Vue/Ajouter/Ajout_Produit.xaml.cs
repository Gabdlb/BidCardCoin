﻿using System;
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
    /// Logique d'interaction pour Ajout_Produit.xaml
    /// </summary>
    public partial class Ajout_Produit : Page
    {
        ProduitViewModel myDataObject; // Objet de liaison avec la vue lors de l'ajout d'une Produit par exemple.
        ObservableCollection<ProduitViewModel> lp;

        LotViewModel myDataObjectLot; // Objet de liaison avec la vue lors de l'ajout d'une Produit par exemple.
        ObservableCollection<LotViewModel> rt;

        int compteur = 0;
        public Ajout_Produit()
        {
            InitializeComponent();

            DALConnection.OpenConnection();
            // Initialisation de la liste des Produits via la BDD.
            loadProduits();
            loadLots();

            appliquerContexte();
        }

        
        private void Btn_Ajout(object sender, RoutedEventArgs e)
        {
            myDataObject.idProduitProperty = ProduitDAL.getMaxIdProduit() + 1;

            lp.Add(myDataObject);
            ProduitORM.insertProduit(myDataObject);
            compteur = lp.Count();

            // Comme on a inséré une Produit, on crée un nouvel objet ProduitViewModel
            // Et on réatache tout ce qu'il faut pour que la vue soit propre
            myDataObject = new ProduitViewModel();

            // Comme le contexte des élément de la vue est encore l'ancien ProduitViewModel,
            // On refait les liens entre age, slider, textbox, bouton et le nouveau ProduitViewModel
            nomTextBox.DataContext = myDataObject;
            descriptionTextBox.DataContext = myDataObject;
            etatTextBox.DataContext = myDataObject;
            artisteTextBox.DataContext = myDataObject;
            prixdTextBox.DataContext = myDataObject;
            prixrTextBox.DataContext = myDataObject;
            lotComboBox.DataContext = myDataObject;
            Produit.Content = new Article();

        }
        private void Btn_Retour(object sender, RoutedEventArgs e)
        {
            Produit.Content = new Article();
        }
        void loadProduits()
        {
            lp = ProduitORM.listeProduits();
            myDataObject = new ProduitViewModel();
            //LIEN AVEC la VIEW
        }

        void loadLots()
        {
            rt = LotORM.listeLots();
            myDataObjectLot = new LotViewModel();
            lotComboBox.ItemsSource = rt;
            //LIEN AVEC la VIEW
        }
        void appliquerContexte()
        {
            // Lien avec les textbox
            nomTextBox.DataContext = myDataObject;
            descriptionTextBox.DataContext = myDataObject;
            etatTextBox.DataContext = myDataObject;
            artisteTextBox.DataContext = myDataObject;
            prixdTextBox.DataContext = myDataObject;
            prixrTextBox.DataContext = myDataObject;
            lotComboBox.DataContext = myDataObject;
        }

       
    }
}
