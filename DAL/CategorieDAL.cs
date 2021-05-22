using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Windows;
using MySql.Data.MySqlClient;

namespace BidCardCoin
{
     public class CategorieDAL
    {
        public CategorieDAL()
        { }

        public static ObservableCollection<CategorieDAO> selectCategories()
        {
            ObservableCollection<CategorieDAO> l = new ObservableCollection<CategorieDAO>();
            string query = "SELECT * FROM Categorie;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataReader reader = null;
            try
            {
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    CategorieDAO p = new CategorieDAO(reader.GetInt32(0), reader.GetString(1));
                    l.Add(p);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Il y a un problème dans la table Categorie : {0}", e.StackTrace);
            }
            reader.Close();
            return l;
        }

        public static void updateCategorie(CategorieDAO p)
        {
            string query = "UPDATE Categorie set nom=\"" + p.nomDAO + "\"WHERE idCategorie = \"" + p.idCategorieDAO + "\";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertCategorie(CategorieDAO p)
        {
            int id = getMaxIdCategorie() + 1;
            string query = "INSERT INTO Categorie (idCategorie, Nom) VALUES (\"" + id + "\",\"" + p.nomDAO + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerCategorie(int id)
        {
            string query = "DELETE FROM Categorie WHERE idCategorie = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static int getMaxIdCategorie()
        {
            int maxIdCategorie = 0;
            string query = "SELECT MAX(idCategorie) FROM Categorie;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());

            int cnt = cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable schemaTable = reader.GetSchemaTable();

            if (reader.HasRows)
            {
                reader.Read();
                if (!reader.IsDBNull(0))
                {
                    maxIdCategorie = reader.GetInt32(0);
                }
                else
                {
                    maxIdCategorie = 0;
                }
            }
            reader.Close();
            return maxIdCategorie;
        }

        public static CategorieDAO getCategorie(int idCategorie)
        {
            string query = "SELECT * FROM Categorie WHERE id=" + idCategorie + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            CategorieDAO pers = new CategorieDAO(reader.GetInt32(0), reader.GetString(1));
            reader.Close();
            return pers;
        }

        public static ObservableCollection<CategorieDAO> getNomCategorie(int idCategorie)
        {

            ObservableCollection<CategorieDAO> l = new ObservableCollection<CategorieDAO>();
            string query = "SELECT p.nom FROM produit_categorie c join categorie ca on ca.idCategorie=c.idCategorie join produit p on p.idProduit=c.idProduit WHERE ca.idCategorie =" + idCategorie + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataReader reader = null;
            try
            {
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    CategorieDAO p = new CategorieDAO(reader.GetString(0));
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
