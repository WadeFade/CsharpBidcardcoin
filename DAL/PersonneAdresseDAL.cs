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
    class PersonneAdresseDAL
    {
        public PersonneAdresseDAL() { }


        public static ObservableCollection<PersonneAdresseDAO> selectPersonneAdresses()
        {
            ObservableCollection<PersonneAdresseDAO> lPersonneAdresseDAOs = new ObservableCollection<PersonneAdresseDAO>();
            string query = "SELECT * FROM personneadresse;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataReader reader = null;
            try
            {
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    PersonneAdresseDAO a = new PersonneAdresseDAO(reader.GetString(0), reader.GetString(1));
                    lPersonneAdresseDAOs.Add(a);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Il y a un problème dans la table d'association PersonneAdresse : {0}", e.StackTrace);
            }
            reader.Close();
            return lPersonneAdresseDAOs;
        }

        public static ObservableCollection<PersonneAdresseDAO> getPersonneAdresseByIdPersonne(string idPersonne)
        {
            ObservableCollection<PersonneAdresseDAO> lPersonneAdresseDAOs = new ObservableCollection<PersonneAdresseDAO>();
            string query = "SELECT * FROM personneadresse WHERE personne_idPersonne = @idPersonne;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            // Pour éviter l'injection SQL à cause de la concaténation
            cmd.Parameters.AddWithValue("@idPersonne", idPersonne);
            MySqlDataReader reader = null;
            try
            {
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    PersonneAdresseDAO pa = new PersonneAdresseDAO(reader.GetString(0), reader.GetString(1));
                    lPersonneAdresseDAOs.Add(pa);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Il y a un problème dans la table d'association PersonneAdresse : {0}", e.StackTrace);
            }
            reader.Close();
            return lPersonneAdresseDAOs;
        }

        // Fonction pas nécéssaire normalement, on ne veut pas modifier l'asso mais la suppr.
        public static void updatePersonneAdresse(PersonneAdresseDAO pa)
        {
            string query = "UPDATE personneadresse SET personne_idPersonne = @idPersonne" +
                " adresse_idAdresse = @idAdresse WHERE adresse_idAdresse = @idAdresse" +
                " AND personne_idPersonne = @idPersonne;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            // Pour éviter l'injection SQL à cause de la concaténation
            cmd.Parameters.AddWithValue("@idPersonne", pa.idPersonneDAO);
            cmd.Parameters.AddWithValue("@idAdresse", pa.idAdresseDAO);
            cmd.ExecuteNonQuery();
        }

        // Pour supprimer la bonne association on à besoin de l'idPersonne & de l'idAdresse
        public static void supprimerPersonneAdresse(string idPersonne, string idAdresse)
        {
            string query = "DELETE FROM personneadresse WHERE personne_idPersonne = @idPersonne AND adresse_idAdresse = @idAdresse;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            // Pour éviter l'injection SQL à cause de la concaténation
            cmd.Parameters.AddWithValue("@idPersonne", idPersonne);
            cmd.Parameters.AddWithValue("@idAdresse", idAdresse);
            cmd.ExecuteNonQuery();
        }

        public static void insertPersonneAdresse(PersonneAdresseDAO pa)
        {
            string query = "INSERT INTO personneadresse VALUES (@idPersonne, @idAdresse);";
            MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            // Pour éviter l'injection SQL à cause de la concaténation
            cmd2.Parameters.AddWithValue("@idPersonne", pa.idPersonneDAO);
            cmd2.Parameters.AddWithValue("@idAdresse", pa.idAdresseDAO);
            cmd2.ExecuteNonQuery();
        }
    }
}
