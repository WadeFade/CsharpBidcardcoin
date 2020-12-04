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


    // CLASS UTILISATEURDAO
    public class UtilisateurDAO
    {
        public string idUtilisateurDAO;
        public bool verifSolvabiliteDAO;
        public bool ressortissantDAO;
        public int modePaiementDAO;
        public string idPersonneDAO;


        public UtilisateurDAO(string idUtilisateurDAO, bool verifSolvabiliteDAO,
                bool ressortissantDAO, int modePaiementDAO, string idPersonneDAO)
        {
            this.idUtilisateurDAO = idUtilisateurDAO;
            this.verifSolvabiliteDAO = verifSolvabiliteDAO;
            this.ressortissantDAO = ressortissantDAO;
            this.modePaiementDAO = modePaiementDAO;
            this.idPersonneDAO = idPersonneDAO;

        }


        // todo faire la class PersonneDAL
        // todo implémenter toutes les méthodes de Personne + utilisateur + commissaire
        public static ObservableCollection<UtilisateurDAO> listeUtilisateurs()
        {
            ObservableCollection<UtilisateurDAO> lUtilisateurDAOs = DAL.UtilisateurDAL.selectUtilisateurs();
            return lUtilisateurDAOs;
        }

        public static UtilisateurDAO getUtilisateur(string idUtilisateur)
        {
            UtilisateurDAO u = DAL.UtilisateurDAL.getUtilisateur(idUtilisateur);
            return u;
        }

        public static UtilisateurDAO getUtilisateurByIdPersonne(string idPersonne)
        {
            UtilisateurDAO u = DAL.UtilisateurDAL.getUtilisateurByIdPersonne(idPersonne);
            return u;
        }

        public static void updateUtilisateur(UtilisateurDAO u)
        {
            DAL.UtilisateurDAL.updateUtilisateur(u);
        }

        public static void supprimerUtilisateur(string id)
        {
            DAL.UtilisateurDAL.supprimerUtilisateur(id);
        }

        public static void insertUtilisateur(UtilisateurDAO u)
        {
            DAL.UtilisateurDAL.insertUtilisateur(u);
        }

    }


    // CLASS COMMISSAIREDAO
    public class CommissaireDAO
    {
        public string idCommissaireDAO;
        public string formationDAO;
        public bool verifFormationDAO;
        public string idPersonneDAO;


        public CommissaireDAO(string idCommissaireDAO, string formationDAO,
                bool verifFormationDAO, string idPersonneDAO)
        {
            this.idCommissaireDAO = idCommissaireDAO;
            this.formationDAO = formationDAO;
            this.verifFormationDAO = verifFormationDAO;
            this.idPersonneDAO = idPersonneDAO;
        }

        // todo faire la class PersonneDAL
        // todo implémenter toutes les méthodes de Personne + utilisateur + commissaire
        public static ObservableCollection<CommissaireDAO> listeCommissaires()
        {
            ObservableCollection<CommissaireDAO> lCommissaireDAOs = DAL.CommissaireDAL.selectCommissaires();
            return lCommissaireDAOs;
        }

        public static CommissaireDAO getCommissaire(string idCommissaire)
        {
            CommissaireDAO c = DAL.CommissaireDAL.getCommissaire(idCommissaire);
            return c;
        }

        public static void updateCommissaire(CommissaireDAO c)
        {
            DAL.CommissaireDAL.updateCommissaire(c);
        }

        public static void supprimerCommissaire(string idCommissaire)
        {
            DAL.CommissaireDAL.supprimerCommissaire(idCommissaire);
        }

        public static void insertCommissaire(CommissaireDAO c)
        {
            DAL.CommissaireDAL.insertCommissaire(c);
        }


    }

}
