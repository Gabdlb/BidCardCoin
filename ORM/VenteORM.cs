using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace BidCardCoin
{
    class VenteORM
    {
        public static VenteViewModel getVente(int idVente)
        {
            VenteDAO pDAO = VenteDAO.getVente(idVente);
            VenteViewModel p = new VenteViewModel(pDAO.idVenteDAO, pDAO.attributeDAO, pDAO.date_debutDAO, pDAO.date_finDAO);
            return p;
        }

        public static ObservableCollection<VenteViewModel> listeVentes()
        {
            ObservableCollection<VenteDAO> lDAO = VenteDAO.listeVentes();
            ObservableCollection<VenteViewModel> l = new ObservableCollection<VenteViewModel>();
            foreach (VenteDAO element in lDAO)
            {
                VenteViewModel p = new VenteViewModel(element.idVenteDAO, element.attributeDAO, element.date_debutDAO, element.date_finDAO);
                l.Add(p);
            }
            return l;
        }


        public static void updateVente(VenteViewModel p)
        {
            VenteDAO.updateVente(new VenteDAO(p.idVenteProperty, p.attributeProperty, p.date_debutProperty, p.date_finProperty));
        }

        public static void supprimerVente(int id)
        {
            VenteDAO.supprimerVente(id);
        }

        public static void insertVente(VenteViewModel p)
        {
            VenteDAO.insertVente(new VenteDAO(p.idVenteProperty, p.attributeProperty, p.date_debutProperty, p.date_finProperty));
        }
    }
}
