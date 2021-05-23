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
    /// Logique d'interaction pour Ajout_Vente.xaml
    /// </summary>
    public partial class Ajout_Vente : Page
    {
        VenteViewModel myDataObject; // Objet de liaison avec la vue lors de l'ajout d'une Vente par exemple.
        ObservableCollection<VenteViewModel> lp;
        int compteur = 0;
        public Ajout_Vente()
        {
            InitializeComponent();

            DALConnection.OpenConnection();
            // Initialisation de la liste des Ventes via la BDD.
            loadVentes();

            appliquerContexte();
        }

        public void attributeChanged(object sender, TextChangedEventArgs e)
        {
            myDataObject.attributeProperty = attributeTextBox.Text;
        }
        
        private void Btn_Ajout(object sender, RoutedEventArgs e)
        {
            myDataObject.idVenteProperty = VenteDAL.getMaxIdVente() + 1;

            lp.Add(myDataObject);
            VenteORM.insertVente(myDataObject);
            compteur = lp.Count();

            // Comme on a inséré une Vente, on crée un nouvel objet VenteViewModel
            // Et on réatache tout ce qu'il faut pour que la vue soit propre
            myDataObject = new VenteViewModel();

            // Comme le contexte des élément de la vue est encore l'ancien VenteViewModel,
            // On refait les liens entre age, slider, textbox, bouton et le nouveau VenteViewModel
            attributeTextBox.DataContext = myDataObject;
            
            vente.Content = new Vente();

        }
        private void Btn_Retour(object sender, RoutedEventArgs e)
        {
            vente.Content = new Vente();
        }
        void loadVentes()
        {
            lp = VenteORM.listeVentes();
            myDataObject = new VenteViewModel();
            //LIEN AVEC la VIEW
        }

        void appliquerContexte()
        {
            // Lien avec les textbox
            attributeTextBox.DataContext = myDataObject;
            
        }
    }
}
