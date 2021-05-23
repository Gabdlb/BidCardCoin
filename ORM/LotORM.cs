using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidCardCoin
{
    class LotORM
    {
        public static LotViewModel getLot(int idLot)
        {
            LotDAO pDAO = LotDAO.getLot(idLot);
            LotViewModel p = new LotViewModel(pDAO.idLotDAO, pDAO.nomDAO, pDAO.descriptionDAO, pDAO.prix_departDAO);
            return p;
        }

        public static ObservableCollection<LotViewModel> listeLots()
        {
            ObservableCollection<LotDAO> lDAO = LotDAO.listeLots();
            ObservableCollection<LotViewModel> l = new ObservableCollection<LotViewModel>();
            foreach (LotDAO element in lDAO)
            {
                LotViewModel p = new LotViewModel(element.idLotDAO, element.nomDAO, element.descriptionDAO, element.prix_departDAO);
                l.Add(p);
            }
            return l;
        }


        public static void updateLot(LotViewModel p)
        {
            LotDAO.updateLot(new LotDAO(p.idLotProperty, p.nomProperty, p.descriptionProperty, p.prix_departProperty));
        }

        public static void supprimerLot(int id)
        {
            LotDAO.supprimerLot(id);
        }

        public static void insertLot(LotViewModel p)
        {
            LotDAO.insertLot(new LotDAO(p.idLotProperty, p.nomProperty, p.descriptionProperty, p.prix_departProperty));
        }
    }
}
