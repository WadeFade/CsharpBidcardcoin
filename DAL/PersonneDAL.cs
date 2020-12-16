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
    public static class PersonneDAL
    {
        
        // todo faire et mettre à jour les méthodes pour Personne, Utilisateur et Commissaire !
        // Faire attention quand je delete une PERSONNE d'aussi DELETE l'UTILISATEUR ou le COMMISSAIRE correspondant
        // idem pour UPDATE
        public static ObservableCollection<PersonneDAO> selectPersonnes()
        {
            ObservableCollection<PersonneDAO> lPersonneDAOs = new ObservableCollection<PersonneDAO>();
            string query = "SELECT * FROM personne;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataReader reader = null;
            try
            {
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    PersonneDAO p = new PersonneDAO(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetDateTime(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetBoolean(7));
                    lPersonneDAOs.Add(p);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Il y a un problème dans la table Personne : {0}", e.StackTrace);
            }
            reader.Close();
            return lPersonneDAOs;
        }

        
        public static PersonneDAO getPersonne(string idPersonne)
        {
            string query = "SELECT * FROM personne WHERE idPersonne = @idPersonne;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            // Pour éviter l'injection SQL à cause de la concaténation
            cmd.Parameters.AddWithValue("@idPersonne", idPersonne);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            PersonneDAO pers = new PersonneDAO(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetDateTime(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetBoolean(7));
            reader.Close();
            return pers;
        }

       
        public static void updatePersonne(PersonneDAO p)
        {
            string query = "UPDATE personne SET `nomPersonne` = @nomPersonne, `prenomPersonne` = @prenomPersonne," +
                " `dateNaissance` = @dateNaissance, `telephone` = @telephone, `email` = @email, `password` = @password," +
                " `verifIdentite` = @verifIdentite WHERE idPersonne = @idPersonne;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            // Pour éviter l'injection SQL à cause de la concaténation
            cmd.Parameters.AddWithValue("@nomPersonne", p.nomPersonneDAO);
            cmd.Parameters.AddWithValue("@prenomPersonne", p.prenomPersonneDAO);
            cmd.Parameters.AddWithValue("@dateNaissance", p.dateNaissanceDAO);
            cmd.Parameters.AddWithValue("@telephone", p.telephoneDAO);
            cmd.Parameters.AddWithValue("@email", p.emailDAO);
            cmd.Parameters.AddWithValue("@password", p.passwordDAO);
            cmd.Parameters.AddWithValue("@verifIdentite", p.verifIdentiteDAO);
            cmd.Parameters.AddWithValue("@idPersonne", p.idPersonneDAO);
            cmd.ExecuteNonQuery();
        }

        
        public static void supprimerPersonne(string idPersonne)
        {
            string query = "DELETE FROM personne WHERE idPersonne = @idPersonne;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            // Pour éviter l'injection SQL à cause de la concaténation
            cmd.Parameters.AddWithValue("@idPersonne", idPersonne);
            cmd.ExecuteNonQuery();
        }

        
        public static void insertPersonne(PersonneDAO p)
        {
           // int id = getMaxIdPersonne() + 1; // pas besoin grâce au Guid mais pourquoi pas vérifié pour éviter une collision
            //String dateNaissance = p.dateNaisPersonneDAO.ToString("yyyy-MM-dd");
            string query = "INSERT INTO personne VALUES (@idPersonne, @nomPersonne, @prenomPersonne, @dateNaissance," +
                " @telephone, @email, @password, @verifIdentite);";
            MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            // Pour éviter l'injection SQL à cause de la concaténation
            cmd2.Parameters.AddWithValue("@idPersonne", p.idPersonneDAO);
            cmd2.Parameters.AddWithValue("@nomPersonne", p.nomPersonneDAO);
            cmd2.Parameters.AddWithValue("@prenomPersonne", p.prenomPersonneDAO);
            cmd2.Parameters.AddWithValue("@dateNaissance", p.dateNaissanceDAO);
            cmd2.Parameters.AddWithValue("@telephone", p.telephoneDAO);
            cmd2.Parameters.AddWithValue("@email", p.emailDAO);
            cmd2.Parameters.AddWithValue("@password", p.passwordDAO);
            cmd2.Parameters.AddWithValue("@verifIdentite", p.verifIdentiteDAO);
            cmd2.ExecuteNonQuery();
        }

    }
}
