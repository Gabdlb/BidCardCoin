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
using System.Collections.ObjectModel;
using BidCardCoin.Vue.Ajouter;

namespace BidCardCoin.Vue
{
    /// <summary>
    /// Logique d'interaction pour Vente.xaml
    /// </summary>
    public partial class Vente : Page
    {

        int selectedVenteId;
        VenteViewModel myDataObject; // Objet de liaison avec la vue lors de l'ajout d'une Vente par exemple.
        ObservableCollection<VenteViewModel> lp;
        public Vente()
        {
            InitializeComponent();

            DALConnection.OpenConnection();
            // Initialisation de la liste des Ventes via la BDD.
            loadVentes();
        }
        private void Btn_Sppr(object sender, RoutedEventArgs e)
        {
            if (List_Vente.SelectedItem is VenteViewModel)
            {
                VenteViewModel toRemove = (VenteViewModel)List_Vente.SelectedItem;
                lp.Remove(toRemove);
                List_Vente.Items.Refresh();
                VenteORM.supprimerVente(selectedVenteId);
            }
        }

        private void listeVentes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((List_Vente.SelectedIndex < lp.Count) && (List_Vente.SelectedIndex >= 0))
            {
                selectedVenteId = (lp.ElementAt<VenteViewModel>(List_Vente.SelectedIndex)).idVenteProperty;
            }
        }

        void loadVentes()
        {
            lp = VenteORM.listeVentes();
            myDataObject = new VenteViewModel();
            //LIEN AVEC la VIEW
            List_Vente.ItemsSource = lp; // bind de la liste avec la source, permettant le binding.
        }

        private void Btn_AjPrs(object sender, RoutedEventArgs e)
        {
            vente.Content = new Ajout_Vente();
        }

    }
}

    

