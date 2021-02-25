using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BidCardCoin.Vue.Ajouter;
using System.Collections.ObjectModel;

namespace BidCardCoin.Vue
{
    /// <summary>
    /// Logique d'interaction pour Personne.xaml
    /// </summary>
    public partial class Personne : Page
    {
        int selectedPersonneId;
        PersonneViewModel myDataObject; // Objet de liaison avec la vue lors de l'ajout d'une personne par exemple.
        ObservableCollection<PersonneViewModel> lp;
        public Personne()
        {
            InitializeComponent();

            DALConnection.OpenConnection();
            // Initialisation de la liste des personnes via la BDD.
            loadPersonnes();
        }
        private void Btn_Sppr(object sender, RoutedEventArgs e)
        {
            if (List_Personne.SelectedItem is PersonneViewModel)
            {
                PersonneViewModel toRemove = (PersonneViewModel)List_Personne.SelectedItem;
                lp.Remove(toRemove);
                List_Personne.Items.Refresh();
                PersonneORM.supprimerPersonne(selectedPersonneId);
            }
        }

        private void listePersonnes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((List_Personne.SelectedIndex < lp.Count) && (List_Personne.SelectedIndex >= 0))
            {
                selectedPersonneId = (lp.ElementAt<PersonneViewModel>(List_Personne.SelectedIndex)).idPersonneProperty;
            }
        }

        void loadPersonnes()
        {
            lp = PersonneORM.listePersonnes();
            myDataObject = new PersonneViewModel();
            //LIEN AVEC la VIEW
            List_Personne.ItemsSource = lp; // bind de la liste avec la source, permettant le binding.
        }

        private void Btn_AjPrs(object sender, RoutedEventArgs e)
        {
            personne.Content = new Ajout_Personne();
        }
    }
}
