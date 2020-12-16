using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidCardCoin.DAO
{
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

        public static void supprimerUtilisateur(string idUtilisateur)
        {
            DAL.UtilisateurDAL.supprimerUtilisateur(idUtilisateur);
        }

        public static void insertUtilisateur(UtilisateurDAO u)
        {
            DAL.UtilisateurDAL.insertUtilisateur(u);
        }

    }
}
