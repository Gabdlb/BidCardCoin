using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Windows;
using MySql.Data.MySqlClient;

namespace BidCardCoin
{
     public class ProduitDAL
    {
        public ProduitDAL()
        { }

        public static ObservableCollection<ProduitDAO> selectProduits()
        {
            ObservableCollection<ProduitDAO> l = new ObservableCollection<ProduitDAO>();
            string query = "SELECT * FROM Produit;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataReader reader = null;
            try
            {
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ProduitDAO p = new ProduitDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetString(5), reader.GetString(6), reader.GetInt32(7));
                    l.Add(p);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Il y a un problème dans la table Produit : {0}", e.StackTrace);
            }
            reader.Close();
            return l;
        }

        public static void updateProduit(ProduitDAO p)
        {
            string query = "UPDATE Produit set nom=\"" + p.nomDAO + "\", description=\"" + p.descriptionDAO + "\", prix_depart=\"" + p.prix_departDAO + "\", prix_reserve=\"" + p.prix_reserveDAO + "\", etat=\"" + p.etatDAO + "\", artiste=\"" + p.artisteDAO + "\", idLot=\"" + p.idLotDAO + "\"WHERE idProduit = \"" + p.idProduitDAO + "\" ;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertProduit(ProduitDAO p)
        {
            int id = getMaxIdProduit() + 1;
            string query = "INSERT INTO Produit (idProduit, Nom, Description, prix_depart, prix_reserve, etat, artiste, idLot) VALUES (\"" + id + "\",\"" + p.nomDAO + "\",\"" + p.descriptionDAO + "\",\"" + p.prix_departDAO + "\",\"" + p.prix_reserveDAO + "\",\"" + p.etatDAO + "\",\"" + p.artisteDAO + "\",\"" + p.idLotDAO + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerProduit(int id)
        {
            string query = "DELETE FROM Produit WHERE idProduit = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static int getMaxIdProduit()
        {
            int maxIdProduit = 0;
            string query = "SELECT MAX(idProduit) FROM Produit;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());

            int cnt = cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable schemaTable = reader.GetSchemaTable();

            if (reader.HasRows)
            {
                reader.Read();
                if (!reader.IsDBNull(0))
                {
                    maxIdProduit = reader.GetInt32(0);
                }
                else
                {
                    maxIdProduit = 0;
                }
            }
            reader.Close();
            return maxIdProduit;
        }

        public static ProduitDAO getProduit(int idProduit)
        {
            string query = "SELECT * FROM Produit WHERE id=" + idProduit + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            ProduitDAO pers = new ProduitDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetString(5), reader.GetString(6), reader.GetInt32(7));
            reader.Close();
            return pers;
        }


        public static ObservableCollection<ProduitDAO> getNomProduit(int idProduit)
        {

            ObservableCollection<ProduitDAO> l = new ObservableCollection<ProduitDAO>();
            string query = "SELECT ca.nom FROM produit_categorie c join produit p on p.idProduit=c.idProduit join categorie ca on ca.idCategorie=c.idCategorie WHERE p.idProduit =" + idProduit + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataReader reader = null;
            try
            {
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ProduitDAO p = new ProduitDAO(reader.GetString(0));
                    l.Add(p);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Il y a un problème dans la table CategorieProduit : {0}", e.StackTrace);
            }
            reader.Close();
            return l;
        }
    }
}
