using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidCardCoin
{
    public class VenteViewModel : INotifyPropertyChanged
    {
        public int id;
        public string attribute;
        public DateTime date_debut;
        public DateTime date_fin;
        //public TimeSpan heure_debut;
        //public TimeSpan heure_fin;

        public VenteViewModel() { }

        public VenteViewModel(int id, string attribute, DateTime date_debut, DateTime date_fin)
        {
            this.idVenteProperty = id;
            this.attributeProperty = attribute;
            this.date_debutProperty = date_debut;
            this.date_finProperty = date_fin;
            //this.heure_debutProperty = heure_debut;
            //this.heure_finProperty = heure_fin;
           
        }

        public int idVenteProperty
        {
            get { return id; }
            set
            {
                id = value;
            }
        }

        public String attributeProperty
        {
            get { return attribute; }
            set
            {
                this.attribute = value;
                OnPropertyChanged("attributeProperty"); // indique au système de binding que la valeur a changé
            }

        }

        public DateTime date_debutProperty
        {
            get { return date_debut; }
            set
            {
                this.date_debut = value;
                OnPropertyChanged("date_debutProperty"); // indique au système de binding que la valeur a changé
            }

        }

        public DateTime date_finProperty
        {
            get { return date_fin; }
            set
            {
                this.date_fin = value;
                OnPropertyChanged("date_finProperty"); // indique au système de binding que la valeur a changé
            }

        }

        //public TimeSpan heure_debutProperty
        //{
        //    get { return heure_debut; }
        //    set
        //    {
        //        this.heure_debut = value;
        //        OnPropertyChanged("heure_debutProperty"); // indique au système de binding que la valeur a changé
        //    }

        //}

        //public TimeSpan heure_finProperty
        //{
        //    get { return heure_fin; }
        //    set
        //    {
        //        this.heure_fin = value;
        //        OnPropertyChanged("heure_finProperty"); // indique au système de binding que la valeur a changé
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
                VenteORM.updateVente(this);
            }
        }

    }
}
