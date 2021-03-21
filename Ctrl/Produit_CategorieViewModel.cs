using System;
using System.ComponentModel;
namespace BidCardCoin
{
    public class Produit_CategorieViewModel : INotifyPropertyChanged
    {
        private ProduitViewModel idProduit;
        private CategorieViewModel idCategorie;

        public Produit_CategorieViewModel() { }

        public Produit_CategorieViewModel(ProduitViewModel produit, CategorieViewModel categorie)
        {
            this.idProduit = produit;
            this.idCategorie = categorie;


        }
        public ProduitViewModel idProduitProperty
        {
            get { return idProduit; }
            set
            {
                idProduit = value;
            }
        }
        public CategorieViewModel idCategorieProperty
        {
            get { return idCategorie; }
            set
            {
                idCategorie = value;
                //OnPropertyChanged("nomProperty"); // indique au système de binding que la valeur a changé
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                this.PropertyChanged(this, new PropertyChangedEventArgs(info));
                Produit_CategorieORM.updateProduit_Categorie(this);
            }
        }
    }
}