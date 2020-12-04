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
    class AdresseDAL
    {
        public AdresseDAL() { }


        public static ObservableCollection<AdresseDAO> selectAdresses()
        {
            ObservableCollection<AdresseDAO> lAdresseDAOs = new ObservableCollection<AdresseDAO>();
            string query = "SELECT * FROM adresse;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataReader reader = null;
            try
            {
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    AdresseDAO a = new AdresseDAO(reader.GetString(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5));
                    lAdresseDAOs.Add(a);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Il y a un problème dans la table Adresse : {0}", e.StackTrace);
            }
            reader.Close();
            return lAdresseDAOs;
        }

        public static AdresseDAO getAdresse(string idAdresse)
        {
            string query = "SELECT * FROM adresse WHERE idAdresse = @idAdresse;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            // Pour éviter l'injection SQL à cause de la concaténation
            cmd.Parameters.AddWithValue("@idAdresse", idAdresse);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            AdresseDAO adr = new AdresseDAO(reader.GetString(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5));
            reader.Close();
            return adr;
        }

        public static void updateAdresse(AdresseDAO a)
        {
            string query = "UPDATE adresse SET num = @num rue = @rue ville = @ville codePostal = @codePostal" +
                " pays = @pays WHERE idAdresse = @idAdresse;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            // Pour éviter l'injection SQL à cause de la concaténation
            cmd.Parameters.AddWithValue("@num", a.numDAO);
            cmd.Parameters.AddWithValue("@rue", a.rueDAO);
            cmd.Parameters.AddWithValue("@ville", a.villeDAO);
            cmd.Parameters.AddWithValue("@codePostal", a.codePostalDAO);
            cmd.Parameters.AddWithValue("@pays", a.paysDAO);
            cmd.Parameters.AddWithValue("@idAdresse", a.idAdresseDAO);
            cmd.ExecuteNonQuery();
        }

        public static void supprimerAdresse(string idAdresse)
        {
            string query = "DELETE FROM adresse WHERE idAdresse = @idAdresse;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            // Pour éviter l'injection SQL à cause de la concaténation
            cmd.Parameters.AddWithValue("@idAdresse", idAdresse);
            cmd.ExecuteNonQuery();
        }

        public static void insertAdresse(AdresseDAO a)
        {
            // int id = getMaxIdPersonne() + 1; // pas besoin grâce au Guid mais pourquoi pas vérifié pour éviter une collision
            //String dateNaissance = p.dateNaisPersonneDAO.ToString("yyyy-MM-dd");
            string query = "INSERT INTO adresse VALUES (@idAdresse, @num, @rue, @ville, @codePostal, @pays);";
            MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            // Pour éviter l'injection SQL à cause de la concaténation
            cmd2.Parameters.AddWithValue("@idAdresse", a.idAdresseDAO);
            cmd2.Parameters.AddWithValue("@num", a.numDAO);
            cmd2.Parameters.AddWithValue("@rue", a.rueDAO);
            cmd2.Parameters.AddWithValue("@ville", a.villeDAO);
            cmd2.Parameters.AddWithValue("@codePostal", a.codePostalDAO);
            cmd2.Parameters.AddWithValue("@pays", a.paysDAO);
            cmd2.ExecuteNonQuery();
        }

    }
}
