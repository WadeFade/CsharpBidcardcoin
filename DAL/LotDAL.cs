using BidCardCoin.DAO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BidCardCoin.DAL
{
    public static class LotDAL
    {
        public static ObservableCollection<LotDAO> selectLots()
        {
            ObservableCollection<LotDAO> lLotDAOs = new ObservableCollection<LotDAO>();
            string query = "SELECT * FROM lot";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataReader reader = null;
            try
            {
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    LotDAO l = new LotDAO(reader.GetString(0), reader.GetString(1), reader.GetString(2), 
                        reader.GetString(3));
                    lLotDAOs.Add(l);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Il y a un problème dans la table Lot : {0}", e.StackTrace);
            }
            reader.Close();
            return lLotDAOs;
        }

        public static LotDAO getLot(string idLot)
        {
            string query = "SELECT * FROM lot WHERE idLot = @idLot;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            // Pour éviter l'injection SQL à cause de la concaténation
            cmd.Parameters.AddWithValue("@idLot", idLot);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            LotDAO l = new LotDAO(reader.GetString(0), reader.GetString(1), reader.GetString(2),
                        reader.GetString(3));
            reader.Close();
            return l;
        }

        public static void updateLot(LotDAO l)
        {
            string query = "UPDATE lot SET nomLot = @nomLot, descriptionLot = @descriptionLot," +
                " salleEnchere_idSalleEnchere = @idSalleEnchere WHERE idLot = @idLot;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            // Pour éviter l'injection SQL à cause de la concaténation
            cmd.Parameters.AddWithValue("@nomLot", l.nomLotDAO);
            cmd.Parameters.AddWithValue("@descriptionLot", l.descriptionLotDAO);
            cmd.Parameters.AddWithValue("@idSalleEnchere", l.idSalleEnchereDAO);
            cmd.Parameters.AddWithValue("@idLot", l.idLotDAO);
            cmd.ExecuteNonQuery();
        }

        public static void supprimerLot(string idLot)
        {
            string query = "DELETE FROM lot WHERE idLot = @idLot;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            // Pour éviter l'injection SQL à cause de la concaténation
            cmd.Parameters.AddWithValue("@idLot", idLot);
            cmd.ExecuteNonQuery();
        }

        public static void insertLot(LotDAO l)
        {
            string query = "INSERT INTO lot VALUES (@idLot, @nomLot, @descriptionLot, @idSalleEnchere);";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            // Pour éviter l'injection SQL à cause de la concaténation
            cmd.Parameters.AddWithValue("@idLot", l.idLotDAO);
            cmd.Parameters.AddWithValue("@nomLot", l.nomLotDAO);
            cmd.Parameters.AddWithValue("@descriptionLot", l.descriptionLotDAO);
            cmd.Parameters.AddWithValue("@idSalleEnchere", l.idSalleEnchereDAO);
            cmd.ExecuteNonQuery();
        }
    }
}
