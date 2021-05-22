using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;


namespace BidCardCoin
{
    public class Produit_CategorieDAO
    {
        public int idProduitDAO;
        public int idCategorieDAO;

        public Produit_CategorieDAO(int idProduitDAO, int idCategorieDAO)
        {
            this.idProduitDAO = idProduitDAO;
            this.idCategorieDAO = idCategorieDAO;
        }

        public static ObservableCollection<Produit_CategorieDAO> listeProduit_Categories()
        {
            ObservableCollection<Produit_CategorieDAO> l = Produit_CategorieDAL.selectProduit_Categories();
            return l;
        }

        public static Produit_CategorieDAO getProduit_Categorie(int id)
        {
            Produit_CategorieDAO p = Produit_CategorieDAL.getProduit_Categorie(id);
            return p;
        }

        public static void supprimerProduit_Categorie(int idProduitProperty, int idCategorieProperty)
        {
            Produit_CategorieDAL.supprimerProduit_Categorie(idProduitProperty, idCategorieProperty);
        }

        public static void insertProduit_Categorie(Produit_CategorieDAO p)
        {
            Produit_CategorieDAL.insertProduit_Categorie(p);
        }
    }
}
