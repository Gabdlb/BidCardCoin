using System;
using System.ComponentModel;
namespace BidCardCoin
{
    public class ProduitViewModel : INotifyPropertyChanged
    {
        public int idProduit;
        public string nom;
        public string description;
        public int prix_depart;
        public int prix_reserve;
        public string etat;
        public string artiste;
        //public int idLot;
        //public int idVendeur;

        public ProduitViewModel() { }

        public ProduitViewModel(int id, string nom, string description, int prix_depart, int prix_reserve, string etat, string artiste)
        {
            this.idProduit = id;
            this.nomProperty = nom;
            this.descriptionProperty = description;
            this.prix_departProperty = prix_depart;
            this.prix_reserveProperty = prix_reserve;
            this.etatProperty = etat;
            this.artisteProperty = artiste;
           //this.idLotProperty = idLot;
            //this.idVendeurProperty = idVendeur;

        }

        public ProduitViewModel(string nom)
        {
            
            this.nomProperty = nom;
            
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
                this.nom = value;
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

        public String etatProperty
        {
            get { return etat; }
            set
            {
                this.description = value;
                OnPropertyChanged("etatProperty");
            }
        }

        public String artisteProperty
        {
            get { return artiste; }
            set
            {
                this.description = value;
                OnPropertyChanged("artisteProperty");
            }
        }
        public int prix_departProperty
        {
            get { return prix_depart; }
            set
            {
                prix_depart = value;
            }
        }
        public int prix_reserveProperty
        {
            get { return prix_reserve; }
            set
            {
                prix_reserve = value;
            }
        }
        //public int idLotProperty
        //{
        //    get { return idLot; }
        //    set
        //    {
        //        idLot = value;
        //    }
        //}
        //public int idVendeurProperty
        //{
        //    get { return idVendeur; }
        //    set
        //    {
        //        idVendeur = value;
        //    }
        //}

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