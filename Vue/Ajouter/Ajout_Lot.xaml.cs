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

namespace BidCardCoin.Vue.Ajouter
{
    /// <summary>
    /// Logique d'interaction pour Ajout_Lot.xaml
    /// </summary>
    public partial class Ajout_Lot : Page
    {
        LotViewModel myDataObject; // Objet de liaison avec la vue lors de l'ajout d'une Lot par exemple.
        ObservableCollection<LotViewModel> lp;
        int compteur = 0;
        public Ajout_Lot()
        {
            InitializeComponent();

            DALConnection.OpenConnection();
            // Initialisation de la liste des Lots via la BDD.
            loadLots();

            appliquerContexte();
        }

        //public void nomChanged(object sender, TextChangedEventArgs e)
        //{
        //    myDataObject.nomProperty = nomTextBox.Text;
           
        //}
        //public void descriptionChanged(object sender, TextChangedEventArgs e)
        //{
        //    myDataObject.descriptionProperty = descriptionTextBox.Text;

        //}
        //public void prixChanged(object sender, TextChangedEventArgs e)
        //{
        //    myDataObject.prix_departProperty = Int32.Parse(prixTextBox.Text);

        //}


        private void Btn_Ajout(object sender, RoutedEventArgs e)
        {
            myDataObject.idLotProperty = LotDAL.getMaxIdLot() + 1;

            lp.Add(myDataObject);
            LotORM.insertLot(myDataObject);
            compteur = lp.Count();

            // Comme on a inséré une Lot, on crée un nouvel objet LotViewModel
            // Et on réatache tout ce qu'il faut pour que la vue soit propre
            myDataObject = new LotViewModel();

            // Comme le contexte des élément de la vue est encore l'ancien LotViewModel,
            // On refait les liens entre age, slider, textbox, bouton et le nouveau LotViewModel
            nomTextBox.DataContext = myDataObject;
            descriptionTextBox.DataContext = myDataObject;
            prixTextBox.DataContext = myDataObject;
            lot.Content = new Lot();

        }
        private void Btn_Retour(object sender, RoutedEventArgs e)
        {
            lot.Content = new Lot();
        }
        void loadLots()
        {
            lp = LotORM.listeLots();
            myDataObject = new LotViewModel();
            //LIEN AVEC la VIEW
        }

        void appliquerContexte()
        {
            // Lien avec les textbox
            nomTextBox.DataContext = myDataObject;
            descriptionTextBox.DataContext = myDataObject;
            prixTextBox.DataContext = myDataObject;

        }
    }
}
