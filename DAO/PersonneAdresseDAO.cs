using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidCardCoin.DAO
{
    public class PersonneAdresseDAO
    {
        public string idPersonneDAO;
        public string idAdresseDAO;


        public PersonneAdresseDAO(string idPersonneDAO, string idAdresseDAO)
        {
            this.idPersonneDAO = idPersonneDAO;
            this.idAdresseDAO = idAdresseDAO;
        }


        public static ObservableCollection<PersonneAdresseDAO> listePersonneAdresses()
        {
            ObservableCollection<PersonneAdresseDAO> lPersonneAdresseDAOs = DAL.PersonneAdresseDAL.selectPersonneAdresses();
            return lPersonneAdresseDAOs;
        }

        // Récupérer les associations Personne - Adresse grâce à l'ID de la personne
        public static ObservableCollection<PersonneAdresseDAO> getPersonneAdresseByIdPersonne(string idPersonne)
        {
            ObservableCollection<PersonneAdresseDAO> lPersonneAdresseDAOs = DAL.PersonneAdresseDAL.getPersonneAdresseByIdPersonne(idPersonne);
            return lPersonneAdresseDAOs;
        }

        // Fonction pas nécéssaire normalement, on ne veut pas modifier l'asso mais la suppr.
        public static void updatePersonneAdresse(PersonneAdresseDAO pa)
        {
            DAL.PersonneAdresseDAL.updatePersonneAdresse(pa);
        }

        public static void supprimerPersonneAdresse(string idPersonne, string idAdresse)
        {
            DAL.PersonneAdresseDAL.supprimerPersonneAdresse(idPersonne, idAdresse);
        }

        public static void insertPersonneAdresse(PersonneAdresseDAO pa)
        {
            DAL.PersonneAdresseDAL.insertPersonneAdresse(pa);
        }
    }
}
