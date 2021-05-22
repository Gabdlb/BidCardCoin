using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace BidCardCoin
{
    class CategorieORM
    {

        public static CategorieViewModel getCategorie(int idCategorie)
        {
            CategorieDAO pDAO = CategorieDAO.getCategorie(idCategorie);
            CategorieViewModel p = new CategorieViewModel(pDAO.idCategorieDAO, pDAO.nomDAO);
            return p;
        }

        public static ObservableCollection<CategorieViewModel> listeCategories()
        {
            ObservableCollection<CategorieDAO> lDAO = CategorieDAO.listeCategories();
            ObservableCollection<CategorieViewModel> l = new ObservableCollection<CategorieViewModel>();
            foreach (CategorieDAO element in lDAO)
            {
                CategorieViewModel p = new CategorieViewModel(element.idCategorieDAO, element.nomDAO);
                l.Add(p);
            }
            return l;
        }

        public static ObservableCollection<CategorieViewModel> getNomCategorie(int idCategorie)
        {
            ObservableCollection<CategorieDAO> pDAO = CategorieDAO.getNomCategorie(idCategorie);
            ObservableCollection<CategorieViewModel> p = new ObservableCollection<CategorieViewModel>();
            foreach (CategorieDAO element in pDAO)
            {
                CategorieViewModel pr = new CategorieViewModel(element.nomDAO);
                p.Add(pr);
            }

            return p;
        }

        public static void updateCategorie(CategorieViewModel p)
        {
            CategorieDAO.updateCategorie(new CategorieDAO(p.idCategorieProperty, p.nomsProperty));
        }

        public static void supprimerCategorie(int id)
        {
            CategorieDAO.supprimerCategorie(id);
        }

        public static void insertCategorie(CategorieViewModel p)
        {
            CategorieDAO.insertCategorie(new CategorieDAO(p.idCategorieProperty, p.nomsProperty));
        }
    }
}
