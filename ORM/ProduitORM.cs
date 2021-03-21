using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace BidCardCoin
{
    class ProduitORM
    {

        public static ProduitViewModel getProduit(int idProduit)
        {
            ProduitDAO pDAO = ProduitDAO.getProduit(idProduit);
            ProduitViewModel p = new ProduitViewModel(pDAO.idProduitDAO, pDAO.nomDAO, pDAO.descriptionDAO);
            return p;
        }

        public static ObservableCollection<ProduitViewModel> listeProduits()
        {
            ObservableCollection<ProduitDAO> lDAO = ProduitDAO.listeProduits();
            ObservableCollection<ProduitViewModel> l = new ObservableCollection<ProduitViewModel>();
            foreach (ProduitDAO element in lDAO)
            {
                ProduitViewModel p = new ProduitViewModel(element.idProduitDAO, element.nomDAO, element.descriptionDAO);
                l.Add(p);
            }
            return l;
        }


        public static void updateProduit(ProduitViewModel p)
        {
            ProduitDAO.updateProduit(new ProduitDAO(p.idProduitProperty, p.nomProperty, p.descriptionProperty));
        }

        public static void supprimerProduit(int id)
        {
            ProduitDAO.supprimerProduit(id);
        }

        public static void insertProduit(ProduitViewModel p)
        {
            ProduitDAO.insertProduit(new ProduitDAO(p.idProduitProperty, p.nomProperty, p.descriptionProperty));
        }
    }
}
