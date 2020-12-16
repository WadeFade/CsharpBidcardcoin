using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidCardCoin.DAO
{
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

        public static CommissaireDAO getCommissaireByIdPersonne(string idPersonne)
        {
            CommissaireDAO c = DAL.CommissaireDAL.getCommissaireByIdPersonne(idPersonne);
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
