using System;
using System.ComponentModel;
namespace BidCardCoin
{
    public class PersonneViewModel : INotifyPropertyChanged
    {
        private int idPersonne;
        private string nom;
        private string prenom;
        private string telephone;
        private string email;
        private string concat = "Ajouter ";


        private int age;

        public PersonneViewModel() { }

        public PersonneViewModel(int id, string nom, string prenom, string telephone, string email)
        {
            this.idPersonne = id;
            this.nomProperty = nom;
            this.prenomProperty = prenom;
            this.telephoneProperty = telephone;
            this.emailProperty = email;
        }
        public int idPersonneProperty
        {
            get { return idPersonne; }
            set
            {
                idPersonne = value;
            }
        }
        public String nomProperty
        {
            get { return nom; }
            set
            {
                this.nom = value;
                ConcatProperty = "Ajouter " + nom + " " + prenom;
                OnPropertyChanged("nomProperty"); // indique au système de binding que la valeur a changé
            }

        }
        public String prenomProperty
        {
            get { return prenom; }
            set
            {
                this.prenom = value;
                ConcatProperty = "Ajouter " + nom + " " + prenom;
                OnPropertyChanged("prenomProperty");
            }
        }

        public String telephoneProperty
        {
            get { return telephone; }
            set
            {
                this.telephone = value;
                OnPropertyChanged("telephoneProperty");
            }
        }

        public String emailProperty
        {
            get { return email; }
            set
            {
                this.email = value;
                OnPropertyChanged("email");
            }
        }

        public int AgeProperty
        {
            get { return age; }
            set
            {
                this.age = value;
                OnPropertyChanged("AgeProperty");
            }
        }

        public string ConcatProperty
        {
            get { return concat; }
            set
            {
                this.concat = value;
                OnPropertyChanged("ConcatProperty");
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
                if ((info != "AgeProperty") && (MainWindow.onglet != "ajouter"))
                {
                    PersonneORM.updatePersonne(this);
                }
            }
        }
    }
}