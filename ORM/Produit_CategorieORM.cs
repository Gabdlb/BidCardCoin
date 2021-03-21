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
            int idProduit = pDAO.idProduitDAO;
            ProduitViewModel pr = ProduitORM.getProduit(idProduit);
            int idCategorie = pDAO.idCategorieDAO;
            CategorieViewModel c = CategorieORM.getCategorie(idCategorie);
            Produit_CategorieViewModel p = new Produit_CategorieViewModel(pr, c);
            return p;
        }

        public static ObservableCollection<Produit_CategorieViewModel> listeProduit_Categories()
        {
            ObservableCollection<Produit_CategorieDAO> lDAO = Produit_CategorieDAO.listeProduit_Categories();
            ObservableCollection<Produit_CategorieViewModel> l = new ObservableCollection<Produit_CategorieViewModel>();
            foreach (Produit_CategorieDAO element in lDAO)
            {
                int idProduit = element.idProduitDAO;
                ProduitViewModel pr = ProduitORM.getProduit(idProduit);
                int idCategorie = element.idCategorieDAO;
                CategorieViewModel c = CategorieORM.getCategorie(idCategorie);
                Produit_CategorieViewModel p = new Produit_CategorieViewModel(pr, c);
                l.Add(p);
            }
            return l;
        }


        public static void updateProduit_Categorie(Produit_CategorieViewModel p)
        {
            Produit_CategorieDAO.updateProduit_Categorie(new Produit_CategorieDAO(p.idProduitProperty.idProduit, p.idCategorieProperty.idCategorie));
        }

        public static void supprimerProduit_Categorie(int id)
        {
            Produit_CategorieDAO.supprimerProduit_Categorie(id);
        }

        public static void insertProduit_Categorie(Produit_CategorieViewModel p)
        {
            Produit_CategorieDAO.insertProduit_Categorie(new Produit_CategorieDAO(p.idProduitProperty.idProduit, p.idCategorieProperty.idCategorie));
        }
    }
}
