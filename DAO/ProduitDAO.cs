using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;


namespace BidCardCoin
{
    public class ProduitDAO
    {
        public int idProduitDAO;
        public string nomDAO;
        public string descriptionDAO;
        public int prix_departDAO;
        public int prix_reserveDAO;
        public string etatDAO;
        public string artisteDAO;
        public int idLotDAO;
        //public int idVendeurDAO;

        public ProduitDAO(int idProduitDAO, string nomDAO, string descriptionDAO, int prix_departDAO, int prix_reserveDAO, string etatDAO, string artisteDAO, int idLotDAO)
        {
            this.idProduitDAO = idProduitDAO;
            this.nomDAO = nomDAO;
            this.descriptionDAO = descriptionDAO;
            this.prix_departDAO = prix_departDAO;
            this.prix_reserveDAO = prix_reserveDAO;
            this.etatDAO = etatDAO;
            this.artisteDAO = artisteDAO;
            this.idLotDAO = idLotDAO;
            //this.idVendeurDAO = idVendeurDAO;
        }

        public ProduitDAO(string nomDAO)
        {
            this.nomDAO = nomDAO;
        }

        public static ObservableCollection<ProduitDAO> listeProduits()
        {
            ObservableCollection<ProduitDAO> l = ProduitDAL.selectProduits();
            return l;
        }

        public static ProduitDAO getProduit(int idProduit)
        {
            ProduitDAO p = ProduitDAL.getProduit(idProduit);
            return p;
        }

        public static ObservableCollection<ProduitDAO> getNomProduit(int idProduit)
        {
            ObservableCollection<ProduitDAO> p = ProduitDAL.getNomProduit(idProduit);
            return p;
        }

        public static void updateProduit(ProduitDAO p)
        {
            ProduitDAL.updateProduit(p);
        }

        public static void supprimerProduit(int id)
        {
            ProduitDAL.supprimerProduit(id);
        }

        public static void insertProduit(ProduitDAO p)
        {
            ProduitDAL.insertProduit(p);
        }
    }
}
