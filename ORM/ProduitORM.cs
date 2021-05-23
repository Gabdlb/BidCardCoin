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
            ProduitViewModel p = new ProduitViewModel(pDAO.idProduitDAO, pDAO.nomDAO, pDAO.descriptionDAO, pDAO.prix_departDAO,pDAO.prix_reserveDAO, pDAO.etatDAO, pDAO.artisteDAO, pDAO.idLotDAO);
            return p;
        }

        public static ObservableCollection<ProduitViewModel> getNomProduit(int idProduit)
        {
            ObservableCollection<ProduitDAO> pDAO = ProduitDAO.getNomProduit(idProduit);
            ObservableCollection<ProduitViewModel> p = new ObservableCollection<ProduitViewModel>();
            foreach (ProduitDAO element in pDAO)
            {
                ProduitViewModel pr = new ProduitViewModel(element.nomDAO);
                p.Add(pr);
            }
          
            return p;
        }

        public static ObservableCollection<ProduitViewModel> listeProduits()
        {
            ObservableCollection<ProduitDAO> lDAO = ProduitDAO.listeProduits();
            ObservableCollection<ProduitViewModel> l = new ObservableCollection<ProduitViewModel>();
            foreach (ProduitDAO element in lDAO)
            {
                ProduitViewModel p = new ProduitViewModel(element.idProduitDAO, element.nomDAO, element.descriptionDAO, element.prix_departDAO, element.prix_reserveDAO, element.etatDAO, element.artisteDAO, element.idLotDAO);
                l.Add(p);
            }
            return l;
        }


        public static void updateProduit(ProduitViewModel p)
        {
            ProduitDAO.updateProduit(new ProduitDAO(p.idProduitProperty, p.nomProperty, p.descriptionProperty, p.prix_departProperty, p.prix_reserveProperty, p.etatProperty, p.artisteProperty, p.idLot));
        }

        public static void supprimerProduit(int id)
        {
            ProduitDAO.supprimerProduit(id);
        }

        public static void insertProduit(ProduitViewModel p)
        {
            ProduitDAO.insertProduit(new ProduitDAO(p.idProduitProperty, p.nomProperty, p.descriptionProperty, p.prix_departProperty, p.prix_reserveProperty, p.etatProperty, p.artisteProperty, p.idLot));
        }
    }
}
