using System;
using System.ComponentModel;
namespace BidCardCoin
{
    public class CategorieViewModel : INotifyPropertyChanged
    {
        public int idCategorie;
        public string nom;

        public CategorieViewModel() { }

        public CategorieViewModel(int id, string nom)
        {
            this.idCategorie = id;
            this.nomsProperty = nom;

        }

        public CategorieViewModel(string nom)
        {
            this.nomsProperty = nom;

        }
        public int idCategorieProperty
        {
            get { return idCategorie; }
            set
            {
                idCategorie = value;
            }
        }
        public String nomsProperty
        {
            get { return nom; }
            set
            {
                nom = value.ToUpper();
                OnPropertyChanged("nomsProperty"); // indique au système de binding que la valeur a changé
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
                CategorieORM.updateCategorie(this);
            }
        }
    }
}