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

        public ProduitDAO(int idProduitDAO, string nomDAO, string descriptionDAO)
        {
            this.idProduitDAO = idProduitDAO;
            this.nomDAO = nomDAO;
            this.descriptionDAO = descriptionDAO;
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
