using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidCardCoin
{
    class LotViewModel : INotifyPropertyChanged
    {
        public int id;
        public string nom;
        public string description;
        public int prix_depart;
        //public bool isVendu;
        //public int idVente;

        public LotViewModel() { }

        public LotViewModel(int id, string nom, string description, int prix_depart)
        {
            this.idLotProperty = id;
            this.nomProperty = nom;
            this.descriptionProperty = description;
            this.prix_departProperty = prix_depart;
            //this.id_vente_id = id_vente_id_;
            //this.isvendu = isvendu_;
        }

        
        public int idLotProperty
        {
            get { return id; }
            set
            {
                id = value;
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
                OnPropertyChanged("descriptionProperty"); // indique au système de binding que la valeur a changé
            }

        }

        public int prix_departProperty
        {
            get { return prix_depart; }
            set
            {
                prix_depart = value;
                OnPropertyChanged("prix_departProperty");
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
                LotORM.updateLot(this);
            }
        }
    }
}
