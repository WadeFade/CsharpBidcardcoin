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
    public static class CommissaireDAL
    {
        public static ObservableCollection<CommissaireDAO> selectCommissaires()
        {
            ObservableCollection<CommissaireDAO> lCommissaireDAOs = new ObservableCollection<CommissaireDAO>();
            string query = "SELECT * FROM commissairepriseur;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataReader reader = null;
            try
            {
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    CommissaireDAO c = new CommissaireDAO(reader.GetString(0), reader.GetString(1), reader.GetBoolean(2), reader.GetString(3));
                    lCommissaireDAOs.Add(c);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Il y a un problème dans la table Commissairepriseur : {0}", e.StackTrace);
            }
            reader.Close();
            return lCommissaireDAOs;
        }


        public static CommissaireDAO getCommissaire(string idCommissairePriseur)
        {
            string query = "SELECT * FROM commissairepriseur WHERE idCommissairePriseur = @idCommissairePriseur;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            // Pour éviter l'injection SQL à cause de la concaténation
            cmd.Parameters.AddWithValue("@idCommissairePriseur", idCommissairePriseur);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            CommissaireDAO commissaire = new CommissaireDAO(reader.GetString(0), reader.GetString(1), reader.GetBoolean(2), reader.GetString(3));
            reader.Close();
            return commissaire;
        }

        public static CommissaireDAO getCommissaireByIdPersonne(string idPersonne)
        {
            string query = "SELECT * FROM commissairepriseur WHERE personne_idPersonne = @idPersonne;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());

            // Pour éviter l'injection SQL à cause de la concaténation
            cmd.Parameters.AddWithValue("@idPersonne", idPersonne);

            MySqlDataReader reader = null;
            CommissaireDAO commissaire = null;
            try
            {
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    commissaire = new CommissaireDAO(reader.GetString(0), reader.GetString(1), reader.GetBoolean(2), reader.GetString(3));

                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Il y a un problème dans la table Commissaire : {0}", e.StackTrace);
            }
            reader.Close();
            return commissaire;


        }

        public static void updateCommissaire(CommissaireDAO c)
        {
            string query = "UPDATE commissairepriseur SET formation = @formation, verifFormation = @verifFormation," +
                " personne_idPersonne = @personne_idPersonne WHERE idCommissairePriseur = @idCommissairePriseur;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            // Pour éviter l'injection SQL à cause de la concaténation
            cmd.Parameters.AddWithValue("@formation", c.formationDAO);
            cmd.Parameters.AddWithValue("@verifFormation", c.verifFormationDAO);
            cmd.Parameters.AddWithValue("@personne_idPersonne", c.idPersonneDAO);
            cmd.Parameters.AddWithValue("@idCommissairePriseur", c.idCommissaireDAO);
            cmd.ExecuteNonQuery();
        }


        public static void supprimerCommissaire(string idCommissairePriseur)
        {
            string query = "DELETE FROM commissairepriseur WHERE idCommissairePriseur = @idCommissairePriseur;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            // Pour éviter l'injection SQL à cause de la concaténation
            cmd.Parameters.AddWithValue("@idCommissairePriseur", idCommissairePriseur);
            cmd.ExecuteNonQuery();
        }


        public static void insertCommissaire(CommissaireDAO c)
        {
            // int id = getMaxIdPersonne() + 1; // pas besoin grâce au Guid mais pourquoi pas vérifié pour éviter une collision
            //String dateNaissance = p.dateNaisPersonneDAO.ToString("yyyy-MM-dd");
            string query = "INSERT INTO commissairepriseur VALUES (@idCommissairePriseur, @formation, @verifFormation," +
                " @personne_idPersonne);";
            MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            // Pour éviter l'injection SQL à cause de la concaténation
            cmd2.Parameters.AddWithValue("@idCommissairePriseur", c.idCommissaireDAO);
            cmd2.Parameters.AddWithValue("@formation", c.formationDAO);
            cmd2.Parameters.AddWithValue("@verifFormation", c.verifFormationDAO);
            cmd2.Parameters.AddWithValue("@personne_idPersonne", c.idPersonneDAO);
            cmd2.ExecuteNonQuery();
        }
    }
}
