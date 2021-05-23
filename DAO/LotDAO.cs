using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidCardCoin
{
    class LotDAO
    {
        public int idLotDAO;
        public string nomDAO;
        public string descriptionDAO;
        public int prix_departDAO;
        //public bool isVendu;
        //public int idVente;


        public LotDAO(int idLotDAO, string nomDAO, string descriptionDAO, int prix_departDAO)
        {
            this.idLotDAO = idLotDAO;
            this.nomDAO = nomDAO;
            this.descriptionDAO = descriptionDAO;
            this.prix_departDAO = prix_departDAO;

        }



        public static ObservableCollection<LotDAO> listeLots()
        {
            ObservableCollection<LotDAO> l = LotDAL.selectLots();
            return l;
        }

        public static LotDAO getLot(int idLot)
        {
            LotDAO p = LotDAL.getLot(idLot);
            return p;
        }



        public static void updateLot(LotDAO p)
        {
            LotDAL.updateLot(p);
        }

        public static void supprimerLot(int id)
        {
            LotDAL.supprimerLot(id);
        }

        public static void insertLot(LotDAO p)
        {
            LotDAL.insertLot(p);
        }
    }
}

