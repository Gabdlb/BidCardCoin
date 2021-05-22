using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;


namespace BidCardCoin
{
    public class CategorieDAO
    {
        public int idCategorieDAO;
        public string nomDAO;

        public CategorieDAO(int idCategorieDAO, string nomDAO)
        {
            this.idCategorieDAO = idCategorieDAO;
            this.nomDAO = nomDAO;
        }

        public CategorieDAO(string nomDAO)
        {
            this.nomDAO = nomDAO;
        }

        public static ObservableCollection<CategorieDAO> listeCategories()
        {
            ObservableCollection<CategorieDAO> l = CategorieDAL.selectCategories();
            return l;
        }

        public static CategorieDAO getCategorie(int idCategorie)
        {
            CategorieDAO p = CategorieDAL.getCategorie(idCategorie);
            return p;
        }

        public static ObservableCollection<CategorieDAO> getNomCategorie(int idCategorie)
        {
            ObservableCollection<CategorieDAO> p = CategorieDAL.getNomCategorie(idCategorie);
            return p;
        }


        public static void updateCategorie(CategorieDAO p)
        {
            CategorieDAL.updateCategorie(p);
        }

        public static void supprimerCategorie(int id)
        {
            CategorieDAL.supprimerCategorie(id);
        }

        public static void insertCategorie(CategorieDAO p)
        {
            CategorieDAL.insertCategorie(p);
        }
    }
}
