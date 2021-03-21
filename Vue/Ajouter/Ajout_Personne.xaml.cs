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
    /// Logique d'interaction pour Ajout_Personne.xaml
    /// </summary>
    public partial class Ajout_Personne : Page
    {
        PersonneViewModel myDataObject; // Objet de liaison avec la vue lors de l'ajout d'une personne par exemple.
        ObservableCollection<PersonneViewModel> lp;
        int compteur = 0;
        public Ajout_Personne()
        {
            InitializeComponent();

            DALConnection.OpenConnection();
            // Initialisation de la liste des personnes via la BDD.
            loadPersonnes();

            appliquerContexte();
        }

        public void prenomChanged(object sender, TextChangedEventArgs e)
        {
            myDataObject.prenomProperty = prenomTextBox.Text;
        }
        public void nomChanged(object sender, TextChangedEventArgs e)
        {
            myDataObject.nomProperty = nomTextBox.Text;
        }
        public void emailChanged(object sender, TextChangedEventArgs e)
        {
            myDataObject.emailProperty = emailTextBox.Text;
        }
        public void telephoneChanged(object sender, TextChangedEventArgs e)
        {
            myDataObject.telephoneProperty = telephoneTextBox.Text;
        }
        private void Btn_Ajout(object sender, RoutedEventArgs e)
        {
            myDataObject.idPersonneProperty = PersonneDAL.getMaxIdPersonne() + 1;

            lp.Add(myDataObject);
            PersonneORM.insertPersonne(myDataObject);
            compteur = lp.Count();

            // Comme on a inséré une personne, on crée un nouvel objet PersonneViewModel
            // Et on réatache tout ce qu'il faut pour que la vue soit propre
            myDataObject = new PersonneViewModel();

            // Comme le contexte des élément de la vue est encore l'ancien PersonneViewModel,
            // On refait les liens entre age, slider, textbox, bouton et le nouveau PersonneViewModel
            nomTextBox.DataContext = myDataObject;
            prenomTextBox.DataContext = myDataObject;
            emailTextBox.DataContext = myDataObject;
            telephoneTextBox.DataContext = myDataObject;
            personne.Content = new Personne();

        }
        private void Btn_Retour(object sender, RoutedEventArgs e)
        {
            personne.Content = new Personne();
        }
        void loadPersonnes()
        {
            lp = PersonneORM.listePersonnes();
            myDataObject = new PersonneViewModel();
            //LIEN AVEC la VIEW
        }

        void appliquerContexte()
        {
            // Lien avec les textbox
            nomTextBox.DataContext = myDataObject;
            prenomTextBox.DataContext = myDataObject;
            emailTextBox.DataContext = myDataObject;
            telephoneTextBox.DataContext = myDataObject;
        }
    }
}
