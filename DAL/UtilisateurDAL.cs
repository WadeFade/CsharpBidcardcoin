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
    public static class UtilisateurDAL
    {

        public static ObservableCollection<UtilisateurDAO> selectUtilisateurs()
        {
            ObservableCollection<UtilisateurDAO> lUtilisateurDAOs = new ObservableCollection<UtilisateurDAO>();
            string query = "SELECT * FROM utilisateur;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataReader reader = null;
            try
            {
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    UtilisateurDAO u = new UtilisateurDAO(reader.GetString(0), reader.GetBoolean(1), reader.GetBoolean(2), reader.GetInt32(3), reader.GetString(4));
                    lUtilisateurDAOs.Add(u);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Il y a un problème dans la table Utilisateur : {0}", e.StackTrace);
            }
            reader.Close();
            return lUtilisateurDAOs;
        }


        public static UtilisateurDAO getUtilisateur(string idUtilisateur)
        {
            string query = "SELECT * FROM utilisateur WHERE idUtilisateur = @idUtilisateur;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            // Pour éviter l'injection SQL à cause de la concaténation
            cmd.Parameters.AddWithValue("@idUtilisateur", idUtilisateur);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            UtilisateurDAO user = new UtilisateurDAO(reader.GetString(0), reader.GetBoolean(1), reader.GetBoolean(2), reader.GetInt32(3), reader.GetString(4));
            reader.Close();
            return user;
        }


        public static UtilisateurDAO getUtilisateurByIdPersonne(string idPersonne)
        {
            string query = "SELECT * FROM utilisateur WHERE personne_idPersonne = @idPersonne;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());

            // Pour éviter l'injection SQL à cause de la concaténation
            cmd.Parameters.AddWithValue("@idPersonne", idPersonne);

            MySqlDataReader reader = null;
            UtilisateurDAO user = null;
            try
            {
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    user = new UtilisateurDAO(reader.GetString(0), reader.GetBoolean(1), reader.GetBoolean(2), reader.GetInt32(3), reader.GetString(4));

                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Il y a un problème dans la table Utilisateur : {0}", e.StackTrace);
            }
            reader.Close();
            return user;


        }


        public static void updateUtilisateur(UtilisateurDAO u)
        {
            string query = "UPDATE utilisateur SET verifSolvabilite = @verifSolvabilite, ressortissant = @ressortissant," +
                " modePaiement = @modePaiement, personne_idPersonne = @personne_idPersonne WHERE idUtilisateur = @idUtilisateur;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            // Pour éviter l'injection SQL à cause de la concaténation
            cmd.Parameters.AddWithValue("@verifSolvabilite", u.verifSolvabiliteDAO);
            cmd.Parameters.AddWithValue("@ressortissant", u.ressortissantDAO);
            cmd.Parameters.AddWithValue("@modePaiement", u.modePaiementDAO);
            cmd.Parameters.AddWithValue("@personne_idPersonne", u.idPersonneDAO);
            cmd.Parameters.AddWithValue("@idUtilisateur", u.idUtilisateurDAO);
            cmd.ExecuteNonQuery();
        }


        public static void supprimerUtilisateur(string idUtilisateur)
        {
            string query = "DELETE FROM utilisateur WHERE idUtilisateur = @idUtilisateur;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            // Pour éviter l'injection SQL à cause de la concaténation
            cmd.Parameters.AddWithValue("@idUtilisateur", idUtilisateur);
            cmd.ExecuteNonQuery();
        }


        public static void insertUtilisateur(UtilisateurDAO u)
        {
            // int id = getMaxIdPersonne() + 1; // pas besoin grâce au Guid mais pourquoi pas vérifié pour éviter une collision
            //String dateNaissance = p.dateNaisPersonneDAO.ToString("yyyy-MM-dd");

            string query = "INSERT INTO utilisateur VALUES (@idUtilisateur, @verifSolvabilite, @ressortissant, @modePaiement," +
                " @personne_idPersonne);";
            MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            // Pour éviter l'injection SQL à cause de la concaténation
            cmd2.Parameters.AddWithValue("@idUtilisateur", u.idUtilisateurDAO);
            cmd2.Parameters.AddWithValue("@verifSolvabilite", u.verifSolvabiliteDAO);
            cmd2.Parameters.AddWithValue("@ressortissant", u.ressortissantDAO);
            cmd2.Parameters.AddWithValue("@modePaiement", u.modePaiementDAO);
            cmd2.Parameters.AddWithValue("@personne_idPersonne", u.idPersonneDAO);
            cmd2.ExecuteNonQuery();
        }
    }
}
