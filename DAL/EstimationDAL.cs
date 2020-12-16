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
    public static class EstimationDAL
    {
        public static ObservableCollection<EstimationDAO> selectEstimations()
        {
            ObservableCollection<EstimationDAO> lEstimationDAOs = new ObservableCollection<EstimationDAO>();
            string query = "SELECT * FROM estimation";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataReader reader = null;
            try
            {
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    EstimationDAO e = new EstimationDAO(reader.GetString(0), reader.GetString(1), reader.GetString(2),
                        reader.GetDouble(3), reader.GetDateTime(4));
                    lEstimationDAOs.Add(e);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Il y a un problème dans la table Estimation : {0}", e.StackTrace);
            }
            reader.Close();
            return lEstimationDAOs;
        }

        public static ObservableCollection<EstimationDAO> getEstimationByIdProduit(string idProduit)
        {
            ObservableCollection<EstimationDAO> lEstimationDAOs = new ObservableCollection<EstimationDAO>();
            string query = "SELECT * FROM estimation WHERE produit_idProduit = @idProduit";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            // Pour éviter l'injection SQL à cause de la concaténation
            cmd.Parameters.AddWithValue("@idProduit", idProduit);
            MySqlDataReader reader = null;
            try
            {
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    EstimationDAO e = new EstimationDAO(reader.GetString(0), reader.GetString(1), reader.GetString(2),
                        reader.GetDouble(3), reader.GetDateTime(4));
                    lEstimationDAOs.Add(e);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Il y a un problème dans la table Estimation : {0}", e.StackTrace);
            }
            reader.Close();
            return lEstimationDAOs;
        }

        public static EstimationDAO getEstimation(string idEstimation)
        {
            string query = "SELECT * FROM estimation WHERE idEstimation = @idEstimation;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            // Pour éviter l'injection SQL à cause de la concaténation
            cmd.Parameters.AddWithValue("@idEstimation", idEstimation);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            EstimationDAO e = new EstimationDAO(reader.GetString(0), reader.GetString(1), reader.GetString(2),
                        reader.GetDouble(3), reader.GetDateTime(4));
            reader.Close();
            return e;
        }

        public static void updateEstimation(EstimationDAO e)
        {
            string query = "UPDATE estimation SET produit_idProduit = @idProduit, commissairePriseur_idCommissairePriseur = @idCommissaire," +
                " prixEstime = @prixEstime, dateEstimation = @dateEstimation WHERE idEstimation = @idEstimation;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            // Pour éviter l'injection SQL à cause de la concaténation
            cmd.Parameters.AddWithValue("@idProduit", e.idProduitDAO);
            cmd.Parameters.AddWithValue("@idCommissaire", e.idCommissaireDAO);
            cmd.Parameters.AddWithValue("@prixEstime", e.prixEstimeDAO);
            cmd.Parameters.AddWithValue("@dateEstimation", e.dateEstimationDAO);
            cmd.Parameters.AddWithValue("@idEstimation", e.idEstimationDAO);
            cmd.ExecuteNonQuery();
        }

        public static void supprimerEstimation(string idEstimation)
        {
            string query = "DELETE FROM estimation WHERE idEstimation = @idEstimation;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            // Pour éviter l'injection SQL à cause de la concaténation
            cmd.Parameters.AddWithValue("@idEstimation", idEstimation);
            cmd.ExecuteNonQuery();
        }

        public static void insertEstimation(EstimationDAO e)
        {
            string query = "INSERT INTO estimation VALUES (@idEstimation, @idProduit, @idCommissaire, @prixEstime, @dateEstimation);";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            // Pour éviter l'injection SQL à cause de la concaténation
            cmd.Parameters.AddWithValue("@idEstimation", e.idEstimationDAO);
            cmd.Parameters.AddWithValue("@idProduit", e.idProduitDAO);
            cmd.Parameters.AddWithValue("@idCommissaire", e.idCommissaireDAO);
            cmd.Parameters.AddWithValue("@prixEstime", e.prixEstimeDAO);
            cmd.Parameters.AddWithValue("@dateEstimation", e.dateEstimationDAO);
            cmd.ExecuteNonQuery();
        }
    }
}
