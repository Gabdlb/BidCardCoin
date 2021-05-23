using BidCardCoin.Vue.Ajouter;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace BidCardCoin.Vue
{
    /// <summary>
    /// Logique d'interaction pour Lot.xaml
    /// </summary>
    public partial class Lot : Page
    {
        int selectedLotId;
        LotViewModel myDataObject; // Objet de liaison avec la vue lors de l'ajout d'une Lot par exemple.
        ObservableCollection<LotViewModel> lp;
        public Lot()
        {
            InitializeComponent();

            DALConnection.OpenConnection();
            // Initialisation de la liste des Lots via la BDD.
            loadLots();
        }
        private void Btn_Sppr(object sender, RoutedEventArgs e)
        {
            if (List_Lot.SelectedItem is LotViewModel)
            {
                LotViewModel toRemove = (LotViewModel)List_Lot.SelectedItem;
                lp.Remove(toRemove);
                List_Lot.Items.Refresh();
                LotORM.supprimerLot(selectedLotId);
            }
        }

        private void listeLots_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((List_Lot.SelectedIndex < lp.Count) && (List_Lot.SelectedIndex >= 0))
            {
                selectedLotId = (lp.ElementAt<LotViewModel>(List_Lot.SelectedIndex)).idLotProperty;
            }
        }

        void loadLots()
        {
            lp = LotORM.listeLots();
            myDataObject = new LotViewModel();
            //LIEN AVEC la VIEW
            List_Lot.ItemsSource = lp; // bind de la liste avec la source, permettant le binding.
        }

        private void Btn_AjPrs(object sender, RoutedEventArgs e)
        {
            lot.Content = new Ajout_Lot();
        }
    }
}
