using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Windows;
using MySql.Data.MySqlClient;

namespace BidCardCoin
{
     public class Produit_CategorieDAL
    {
        public Produit_CategorieDAL()
        { }

        public static ObservableCollection<Produit_CategorieDAO> selectProduit_Categories()
        {
            ObservableCollection<Produit_CategorieDAO> l = new ObservableCollection<Produit_CategorieDAO>();
            string query = "SELECT * FROM Produit_Categorie;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataReader reader = null;
            try
            {
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Produit_CategorieDAO p = new Produit_CategorieDAO(reader.GetInt32(0), reader.GetInt32(1));
                    l.Add(p);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Il y a un problème dans la table Produit_Categorie : {0}", e.StackTrace);
            }
            reader.Close();
            return l;
        }

        public static void updateProduit_Categorie(Produit_CategorieDAO p)
        {
            string query = "UPDATE Produit_Categorie set idCategorie=\"" + p.idCategorieDAO + "\"WHERE idProduit = \"" + p.idProduitDAO + "\";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertProduit_Categorie(Produit_CategorieDAO p)
        {
           
            string query = "INSERT INTO Produit_Categorie (idProduit, idCategorie) VALUES (\"" + p.idProduitDAO + "\",\"" + p.idCategorieDAO + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerProduit_Categorie(int id)
        {
            string query = "DELETE FROM Produit_Categorie WHERE idProduit = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }

        public static Produit_CategorieDAO getProduit_Categorie(int idProduit)
        {
            string query = "SELECT * FROM Produit_Categorie WHERE idProduit=" + idProduit + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            Produit_CategorieDAO pers = new Produit_CategorieDAO(reader.GetInt32(0), reader.GetInt32(1));
            reader.Close();
            return pers;
        }
    }
}
