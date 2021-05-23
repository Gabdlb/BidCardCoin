using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BidCardCoin
{
    class LotDAL
    {
        public LotDAL()
        { }

        public static ObservableCollection<LotDAO> selectLots()
        {
            ObservableCollection<LotDAO> l = new ObservableCollection<LotDAO>();
            string query = "SELECT * FROM Lot;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataReader reader = null;
            try
            {
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    LotDAO p = new LotDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3));
                    l.Add(p);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Il y a un problème dans la table Lot : {0}", e.StackTrace);
            }
            reader.Close();
            return l;
        }

        public static void updateLot(LotDAO p)
        {
            string query = "UPDATE Lot set nom=\"" + p.nomDAO + "\", description=\"" + p.descriptionDAO + "\", prix_depart=\"" + p.prix_departDAO + "\"WHERE id = \"" + p.idLotDAO + "\" ;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertLot(LotDAO p)
        {
            int id = getMaxIdLot() + 1;
            string query = "INSERT INTO Lot (id, nom, description, prix_depart) VALUES (\"" + id + "\",\"" + p.nomDAO + "\",\"" + p.descriptionDAO + "\",\"" + p.prix_departDAO + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerLot(int id)
        {
            string query = "DELETE FROM Lot WHERE id = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static int getMaxIdLot()
        {
            int maxIdLot = 0;
            string query = "SELECT MAX(id) FROM Lot;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());

            int cnt = cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable schemaTable = reader.GetSchemaTable();

            if (reader.HasRows)
            {
                reader.Read();
                if (!reader.IsDBNull(0))
                {
                    maxIdLot = reader.GetInt32(0);
                }
                else
                {
                    maxIdLot = 0;
                }
            }
            reader.Close();
            return maxIdLot;
        }

        public static LotDAO getLot(int idLot)
        {
            string query = "SELECT * FROM Lot WHERE id=" + idLot + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            LotDAO pers = new LotDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3));
            reader.Close();
            return pers;
        }
    }
}
