using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows;
using MySql.Data.MySqlClient;
using System.Collections.ObjectModel;

namespace BidCardCoin
{
    class VenteDAL
    {
        public VenteDAL()
        { }

        public static ObservableCollection<VenteDAO> selectVentes()
        {
            ObservableCollection<VenteDAO> l = new ObservableCollection<VenteDAO>();
            string query = "SELECT * FROM Vente;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataReader reader = null;
            try
            {
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    VenteDAO p = new VenteDAO(reader.GetInt32(0), reader.GetString(1), reader.GetDateTime(2), reader.GetDateTime(3));
                    l.Add(p);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Il y a un problème dans la table Vente : {0}", e.StackTrace);
            }
            reader.Close();
            return l;
        }

        public static void updateVente(VenteDAO p)
        {
            string query = "UPDATE Vente set attribute=\"" + p.attributeDAO + "\", date_debut=\"" + p.date_debutDAO + "\", date_fin=\"" + p.date_finDAO + "\"WHERE id = \"" + p.idVenteDAO + "\";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertVente(VenteDAO p)
        {
            int id = getMaxIdVente() + 1;
            string query = "INSERT INTO Vente (id, attribute, date_debut, date_fin) VALUES (\"" + id + "\",\"" + p.attributeDAO + "\",\"" + p.date_debutDAO + "\",\"" + p.date_finDAO + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerVente(int id)
        {
            string query = "DELETE FROM Vente WHERE id = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static int getMaxIdVente()
        {
            int maxIdVente = 0;
            string query = "SELECT MAX(id) FROM Vente;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());

            int cnt = cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable schemaTable = reader.GetSchemaTable();

            if (reader.HasRows)
            {
                reader.Read();
                if (!reader.IsDBNull(0))
                {
                    maxIdVente = reader.GetInt32(0);
                }
                else
                {
                    maxIdVente = 0;
                }
            }
            reader.Close();
            return maxIdVente;
        }

        public static VenteDAO getVente(int idVente)
        {
            string query = "SELECT * FROM Vente WHERE id=" + idVente + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            VenteDAO pers = new VenteDAO(reader.GetInt32(0), reader.GetString(1), reader.GetDateTime(2), reader.GetDateTime(3));
            reader.Close();
            return pers;
        }


   
    }
}
