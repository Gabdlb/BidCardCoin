using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace BidCardCoin
{
    class VenteDAO
    {
        public int idVenteDAO;
        public string attributeDAO;
        public DateTime date_debutDAO;
        public DateTime date_finDAO;
        //public TimeSpan heure_debutDAO;
        //public TimeSpan heure_finDAO;


        public VenteDAO(int idVenteDAO, string attributeDAO, DateTime date_debutDAO, DateTime date_finDAO)
        {
            this.idVenteDAO = idVenteDAO;
            this.attributeDAO = attributeDAO;
            this.date_debutDAO = date_debutDAO;
            this.date_finDAO = date_finDAO;
            //this.heure_debutDAO = heure_debutDAO;
            //this.heure_finDAO = heure_finDAO;

        }

        

        public static ObservableCollection<VenteDAO> listeVentes()
        {
            ObservableCollection<VenteDAO> l = VenteDAL.selectVentes();
            return l;
        }

        public static VenteDAO getVente(int idVente)
        {
            VenteDAO p = VenteDAL.getVente(idVente);
            return p;
        }

       

        public static void updateVente(VenteDAO p)
        {
            VenteDAL.updateVente(p);
        }

        public static void supprimerVente(int id)
        {
            VenteDAL.supprimerVente(id);
        }

        public static void insertVente(VenteDAO p)
        {
            VenteDAL.insertVente(p);
        }
    }
}
