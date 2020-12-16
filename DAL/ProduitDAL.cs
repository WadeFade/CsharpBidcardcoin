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
    public static class ProduitDAL
    {

        public static ObservableCollection<ProduitDAO> selectProduits()
        {
            ObservableCollection<ProduitDAO> lProduitDAOs = new ObservableCollection<ProduitDAO>();
            string query = "SELECT * FROM produit";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataReader reader = null;
            try
            {
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ProduitDAO p = new ProduitDAO(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetDouble(3),
                        reader.GetDouble(4), reader.GetDouble(5), reader.GetBoolean(6), reader.GetBoolean(7), reader.GetInt32(8),
                        reader.GetString(9), reader.GetString(10), reader.GetString(11));
                    lProduitDAOs.Add(p);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Il y a un problème dans la table Produit : {0}", e.StackTrace);
            }
            reader.Close();
            return lProduitDAOs;
        }

        public static ProduitDAO getProduit(string idProduit)
        {
            string query = "SELECT * FROM produit WHERE idProduit = @idProduit;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            // Pour éviter l'injection SQL à cause de la concaténation
            cmd.Parameters.AddWithValue("@idProduit", idProduit);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            ProduitDAO p = new ProduitDAO(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetDouble(3),
                        reader.GetDouble(4), reader.GetDouble(5), reader.GetBoolean(6), reader.GetBoolean(7), reader.GetInt32(8),
                        reader.GetString(9), reader.GetString(10), reader.GetString(11));
            reader.Close();
            return p;
        }

        public static ObservableCollection<ProduitDAO> getProduitByIdUtilisateur(string idUtilisateur)
        {
            ObservableCollection<ProduitDAO> lProduitDAOs = new ObservableCollection<ProduitDAO>();
            string query = "SELECT * FROM produit WHERE utilisateur_idUtilisateur = @idUtilisateur";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.Parameters.AddWithValue("@idUtilisateur", idUtilisateur);
            MySqlDataReader reader = null;
            try
            {
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ProduitDAO p = new ProduitDAO(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetDouble(3),
                        reader.GetDouble(4), reader.GetDouble(5), reader.GetBoolean(6), reader.GetBoolean(7), reader.GetInt32(8),
                        reader.GetString(9), reader.GetString(10), reader.GetString(11));
                    lProduitDAOs.Add(p);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Il y a un problème dans la table Produit : {0}", e.StackTrace);
            }
            reader.Close();
            return lProduitDAOs;
        }

        public static ObservableCollection<ProduitDAO> getProduitByIdLot(string idLot)
        {
            ObservableCollection<ProduitDAO> lProduitDAOs = new ObservableCollection<ProduitDAO>();
            string query = "SELECT * FROM produit WHERE lot_idLot = @idLot";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.Parameters.AddWithValue("@idLot", idLot);
            MySqlDataReader reader = null;
            try
            {
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ProduitDAO p = new ProduitDAO(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetDouble(3),
                        reader.GetDouble(4), reader.GetDouble(5), reader.GetBoolean(6), reader.GetBoolean(7), reader.GetInt32(8),
                        reader.GetString(9), reader.GetString(10), reader.GetString(11));
                    lProduitDAOs.Add(p);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Il y a un problème dans la table Produit : {0}", e.StackTrace);
            }
            reader.Close();
            return lProduitDAOs;
        }

        public static void updateProduit(ProduitDAO p)
        {
            string query = "UPDATE produit SET nomProduit = @nomProduit, descriptionProduit = @descriptionProduit," +
                " prixReserve = @prixReserve, prixDepart = @prixDepart, prixVente = @prixVente, estVendu = @estVendu," +
                " enStock = @enStock, nbInvendu = @nbInvendu, lot_idLot = @idLot, utilisateur_idUtilisateur = @idUtilisateur," +
                " stockage_idStockage = @idStockage WHERE idProduit = @idProduit;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            // Pour éviter l'injection SQL à cause de la concaténation
            cmd.Parameters.AddWithValue("@nomProduit", p.nomProduitDAO);
            cmd.Parameters.AddWithValue("@descriptionProduit", p.descriptionProduitDAO);
            cmd.Parameters.AddWithValue("@prixReserve", p.prixReserveDAO);
            cmd.Parameters.AddWithValue("@prixDepart", p.prixDepartDAO);
            cmd.Parameters.AddWithValue("@prixVente", p.prixVenteDAO);
            cmd.Parameters.AddWithValue("@estVendu", p.estVenduDAO);
            cmd.Parameters.AddWithValue("@enStock", p.enStockDAO);
            cmd.Parameters.AddWithValue("@nbInvendu", p.nbInvendu);
            cmd.Parameters.AddWithValue("@idLot", p.idLotDAO);
            cmd.Parameters.AddWithValue("@idUtilisateur", p.idUtilisateurDAO);
            cmd.Parameters.AddWithValue("@idStockage", p.idStockageDAO);
            cmd.Parameters.AddWithValue("@idProduit", p.idProduitDAO);
            cmd.ExecuteNonQuery();
        }

        public static void supprimerProduit(string idProduit)
        {
            string query = "DELETE FROM produit WHERE idProduit = @idProduit;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            // Pour éviter l'injection SQL à cause de la concaténation
            cmd.Parameters.AddWithValue("@idProduit", idProduit);
            cmd.ExecuteNonQuery();
        }

        public static void insertProduit(ProduitDAO p)
        {
            string query = "INSERT INTO produit VALUES (@idProduit, @nomProduit, @descriptionProduit, @prixReserve," +
                " @prixDepart, @prixVente, @estVendu, @enStock, @nbInvendu, @idLot, @idUtilisateur, @idStockage);";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            // Pour éviter l'injection SQL à cause de la concaténation
            cmd.Parameters.AddWithValue("@idProduit", p.idProduitDAO);
            cmd.Parameters.AddWithValue("@nomProduit", p.nomProduitDAO);
            cmd.Parameters.AddWithValue("@descriptionProduit", p.descriptionProduitDAO);
            cmd.Parameters.AddWithValue("@prixReserve", p.prixReserveDAO);
            cmd.Parameters.AddWithValue("@prixDepart", p.prixDepartDAO);
            cmd.Parameters.AddWithValue("@prixVente", p.prixVenteDAO);
            cmd.Parameters.AddWithValue("@estVendu", p.estVenduDAO);
            cmd.Parameters.AddWithValue("@enStock", p.enStockDAO);
            cmd.Parameters.AddWithValue("@nbInvendu", p.nbInvendu);
            cmd.Parameters.AddWithValue("@idLot", p.idLotDAO);
            cmd.Parameters.AddWithValue("@idUtilisateur", p.idUtilisateurDAO);
            cmd.Parameters.AddWithValue("@idStockage", p.idStockageDAO);
            cmd.ExecuteNonQuery();
        }
    }
}
