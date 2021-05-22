using System;
using System.ComponentModel;
namespace BidCardCoin
{
    public class Produit_CategorieViewModel
    {
        private int idProduit;
        private int idCategorie;

        public Produit_CategorieViewModel() { }

        public Produit_CategorieViewModel(int idProduit, int idCategorie)
        {
            this.idProduit = idProduit;
            this.idCategorie = idCategorie;


        }
        public int idProduitProperty
        {
            get { return idProduit; }
            set
            {
                idProduit = value;
            }
        }
        public int idCategorieProperty
        {
            get { return idCategorie; }
            set
            {
                idCategorie = value;
                //OnPropertyChanged("nomProperty"); // indique au système de binding que la valeur a changé
            }

        }
    }
}