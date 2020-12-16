using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidCardCoin.DAO
{

    // CLASS PERSONNEDAO
    public class PersonneDAO
    {
        public string idPersonneDAO;
        public string nomPersonneDAO;
        public string prenomPersonneDAO;
        public DateTime dateNaissanceDAO;
        public string telephoneDAO;
        public string emailDAO;
        public string passwordDAO;
        public bool verifIdentiteDAO;
        //public string idAdressePersonneDAO;

        public PersonneDAO(string idPersonneDAO, string nomPersonneDAO,
                string prenomPersonneDAO, DateTime dateNaissanceDAO, string telephoneDAO,
                string emailDAO, string passwordDAO, bool verifIdentiteDAO)
        {
            this.idPersonneDAO = idPersonneDAO;
            this.nomPersonneDAO = nomPersonneDAO;
            this.prenomPersonneDAO = prenomPersonneDAO;
            this.dateNaissanceDAO = dateNaissanceDAO;
            this.telephoneDAO = telephoneDAO;
            this.emailDAO = emailDAO;
            this.passwordDAO = passwordDAO;
            this.verifIdentiteDAO = verifIdentiteDAO;
        }

        
        public static ObservableCollection<PersonneDAO> listePersonnes()
        {
            ObservableCollection<PersonneDAO> lpersonneDAOs = DAL.PersonneDAL.selectPersonnes();
            return lpersonneDAOs;
        }

        public static PersonneDAO getPersonne(string idPersonne)
        {
            PersonneDAO p = DAL.PersonneDAL.getPersonne(idPersonne);
            return p;
        }

        public static void updatePersonne(PersonneDAO p)
        {
            DAL.PersonneDAL.updatePersonne(p);
        }

        public static void supprimerPersonne(string idPersonne)
        {
            DAL.PersonneDAL.supprimerPersonne(idPersonne);
        }

        public static void insertPersonne(PersonneDAO p)
        {
            DAL.PersonneDAL.insertPersonne(p);
        }

    }
}
