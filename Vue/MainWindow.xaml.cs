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

namespace BidCardCoin
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string onglet;
        int selectedPersonneId;
        PersonneViewModel myDataObject; // Objet de liaison avec la vue lors de l'ajout d'une personne par exemple.
        ObservableCollection<PersonneViewModel> lp;
        int compteur = 0;

        public MainWindow()
        {
            InitializeComponent();

            DALConnection.OpenConnection();
            // Initialisation de la liste des personnes via la BDD.
            loadPersonnes();

            appliquerContexte();

            gererEventSupplémentaires();

        }
        void testEvent(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            MessageBox.Show("Event :" + e.RoutedEvent + " / taille " + b.ActualHeight + " x " + b.ActualWidth);
        }




        public void prenomChanged(object sender, TextChangedEventArgs e)
        {
            myDataObject.prenomProperty = prenomTextBox.Text;
        }
        public void nomChanged(object sender, TextChangedEventArgs e)
        {
            myDataObject.nomProperty = nomTextBox.Text;
        }
        private void nomPrenomButton_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // On ne fait rien
        }

        private void nomPrenomButton_Click(object sender, RoutedEventArgs e)
        {
            myDataObject.idPersonneProperty = PersonneDAL.getMaxIdPersonne() + 1;

            lp.Add(myDataObject);
            PersonneORM.insertPersonne(myDataObject);
            compteur = lp.Count();

            // Comme on a inséré une personne, on crée un nouvel objet PersonneViewModel
            // Et on réatache tout ce qu'il faut pour que la vue soit propre
            listePersonnes.Items.Refresh();
            myDataObject = new PersonneViewModel();

            // Comme le contexte des élément de la vue est encore l'ancien PersonneViewModel,
            // On refait les liens entre age, slider, textbox, bouton et le nouveau PersonneViewModel
            nomTextBox.DataContext = myDataObject;
            prenomTextBox.DataContext = myDataObject;
            nomPrenomButton2.DataContext = myDataObject;
            txtAge.DataContext = myDataObject;
            txtAgeDeux.DataContext = myDataObject;
            mySlider.DataContext = myDataObject;
        }

        private void supprimerButton_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {


            if (listePersonnes.SelectedItem is PersonneViewModel)
            {
                PersonneViewModel toRemove = (PersonneViewModel)listePersonnes.SelectedItem;
                lp.Remove(toRemove);
                listePersonnes.Items.Refresh();
                PersonneORM.supprimerPersonne(selectedPersonneId);
            }
        }
        private void VClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Blue !");
        }
        private void RClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Red !");
        }
        private void BClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Blue !");
        }

        private void listePersonnes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listePersonnes.SelectedIndex < lp.Count) && (listePersonnes.SelectedIndex >= 0))
            {
                selectedPersonneId = (lp.ElementAt<PersonneViewModel>(listePersonnes.SelectedIndex)).idPersonneProperty;
            }
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            myDataObject.AgeProperty = Convert.ToInt32(mySlider.Value);
        }

        void TabControlOnglet_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            switch (Onglets.SelectedIndex)
            {
                case 0: onglet = "ajouter"; break;
                case 1: if (onglet != "grille") loadPersonnes(); onglet = "grille"; break;
                case 2: onglet = "slider"; break;
            }

        }

        void loadPersonnes()
        {
            lp = PersonneORM.listePersonnes();
            myDataObject = new PersonneViewModel();
            //LIEN AVEC la VIEW
            listePersonnes.ItemsSource = lp; // bind de la liste avec la source, permettant le binding.
        }

        void appliquerContexte()
        {
            // Lien avec les textbox
            nomTextBox.DataContext = myDataObject;
            prenomTextBox.DataContext = myDataObject;

            // Lien entre age-slider et bouton
            nomPrenomButton2.DataContext = myDataObject;
            // Lien entre age et slider
            txtAge.DataContext = myDataObject;
            txtAgeDeux.DataContext = myDataObject;
            mySlider.DataContext = myDataObject;
        }

        void gererEventSupplémentaires()
        {
        }


    }
}
