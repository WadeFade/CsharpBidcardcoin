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
    public static class PhotoDAL
    {
        public static ObservableCollection<PhotoDAO> selectPhotos()
        {
            ObservableCollection<PhotoDAO> lPhotoDAOs = new ObservableCollection<PhotoDAO>();
            string query = "SELECT * FROM photo";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataReader reader = null;
            try
            {
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    PhotoDAO ph = new PhotoDAO(reader.GetString(0), reader.GetString(1), reader.GetString(2),
                        reader.GetString(3));
                    lPhotoDAOs.Add(ph);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Il y a un problème dans la table Photo : {0}", e.StackTrace);
            }
            reader.Close();
            return lPhotoDAOs;
        }

        public static ObservableCollection<PhotoDAO> getPhotoByIdProduit(string idProduit)
        {
            ObservableCollection<PhotoDAO> lPhotoDAOs = new ObservableCollection<PhotoDAO>();
            string query = "SELECT * FROM photo WHERE produit_idProduit = @idProduit";
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
                    PhotoDAO ph = new PhotoDAO(reader.GetString(0), reader.GetString(1), reader.GetString(2),
                        reader.GetString(3));
                    lPhotoDAOs.Add(ph);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Il y a un problème dans la table Photo : {0}", e.StackTrace);
            }
            reader.Close();
            return lPhotoDAOs;
        }

        public static PhotoDAO getPhoto(string idPhoto)
        {
            string query = "SELECT * FROM photo WHERE idPhoto = @idPhoto;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            // Pour éviter l'injection SQL à cause de la concaténation
            cmd.Parameters.AddWithValue("@idPhoto", idPhoto);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            PhotoDAO ph = new PhotoDAO(reader.GetString(0), reader.GetString(1), reader.GetString(2),
                        reader.GetString(3));
            reader.Close();
            return ph;
        }

        public static void updatePhoto(PhotoDAO ph)
        {
            string query = "UPDATE photo SET nomPhoto = @nomPhoto, urlPhoto = @urlPhoto," +
                " produit_idProduit = @idProduit  WHERE idPhoto = @idPhoto;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            // Pour éviter l'injection SQL à cause de la concaténation
            cmd.Parameters.AddWithValue("@nomPhoto", ph.nomPhotoDAO);
            cmd.Parameters.AddWithValue("@urlPhoto", ph.urlPhotoDAO);
            cmd.Parameters.AddWithValue("@idProduit", ph.idProduitDAO);
            cmd.Parameters.AddWithValue("@idPhoto", ph.idPhotoDAO);
            cmd.ExecuteNonQuery();
        }

        public static void supprimerPhoto(string idPhoto)
        {
            string query = "DELETE FROM photo WHERE idPhoto = @idPhoto;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            // Pour éviter l'injection SQL à cause de la concaténation
            cmd.Parameters.AddWithValue("@idPhoto", idPhoto);
            cmd.ExecuteNonQuery();
        }

        public static void insertPhoto(PhotoDAO ph)
        {
            string query = "INSERT INTO photo VALUES (@idPhoto, @nomPhoto, @urlPhoto, @idProduit);";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            // Pour éviter l'injection SQL à cause de la concaténation
            cmd.Parameters.AddWithValue("@idPhoto", ph.idPhotoDAO);
            cmd.Parameters.AddWithValue("@nomPhoto", ph.nomPhotoDAO);
            cmd.Parameters.AddWithValue("@urlPhoto", ph.urlPhotoDAO);
            cmd.Parameters.AddWithValue("@idProduit", ph.idProduitDAO);
            cmd.ExecuteNonQuery();
        }
    }
}
