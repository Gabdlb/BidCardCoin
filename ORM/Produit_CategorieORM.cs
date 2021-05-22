using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace BidCardCoin
{
    class Produit_CategorieORM
    {

        public static Produit_CategorieViewModel getProduit_Categorie(int id)
        {
            Produit_CategorieDAO pDAO = Produit_CategorieDAO.getProduit_Categorie(id);
            Produit_CategorieViewModel p = new Produit_CategorieViewModel(pDAO.idProduitDAO, pDAO.idCategorieDAO);
            return p;
        }

        public static ObservableCollection<Produit_CategorieViewModel> listeProduit_Categories()
        {
            ObservableCollection<Produit_CategorieDAO> lDAO = Produit_CategorieDAO.listeProduit_Categories();
            ObservableCollection<Produit_CategorieViewModel> l = new ObservableCollection<Produit_CategorieViewModel>();
            foreach (Produit_CategorieDAO element in lDAO)
            {
                Produit_CategorieViewModel p = new Produit_CategorieViewModel(element.idProduitDAO, element.idCategorieDAO);
                l.Add(p);
            }
            return l;
        }

        public static void supprimerProduit_Categorie(int idProduit, int idCategorie)
        {
            Produit_CategorieDAO.supprimerProduit_Categorie(idProduit, idCategorie);
        }

        public static void insertProduit_Categorie(Produit_CategorieViewModel p)
        {
            Produit_CategorieDAO.insertProduit_Categorie(new Produit_CategorieDAO(p.idProduitProperty, p.idCategorieProperty));
        }
    }
}
