using System;
using System.ComponentModel;
namespace BidCardCoin
{
    public class ProduitViewModel : INotifyPropertyChanged
    {
        private int idProduit;
        private string nom;
        private string description;

        public ProduitViewModel() { }

        public ProduitViewModel(int id, string nom, string description)
        {
            this.idProduit = id;
            this.nomProperty = nom;
            this.descriptionProperty = description;

        }
        public int idProduitProperty
        {
            get { return idProduit; }
            set
            {
                idProduit = value;
            }
        }
        public String nomProperty
        {
            get { return nom; }
            set
            {
                nom = value.ToUpper();
                OnPropertyChanged("nomProperty"); // indique au système de binding que la valeur a changé
            }

        }
        public String descriptionProperty
        {
            get { return description; }
            set
            {
                this.description = value;
                OnPropertyChanged("descriptionProperty");
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
                ProduitORM.updateProduit(this);
            }
        }
    }
}