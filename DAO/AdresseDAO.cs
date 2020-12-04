using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidCardCoin.DAO
{
    class AdresseDAO
    {
        public string idAdresseDAO;
        public int numDAO;
        public string rueDAO;
        public string villeDAO;
        public string codePostalDAO;
        public string paysDAO;


        public AdresseDAO(string idAdresseDAO, int numDAO, string rueDAO,
            string villeDAO, string codePostalDAO, string paysDAO)
        {
            this.idAdresseDAO = idAdresseDAO;
            this.numDAO = numDAO;
            this.rueDAO = rueDAO;
            this.villeDAO = villeDAO;
            this.codePostalDAO = codePostalDAO;
            this.paysDAO = paysDAO;
        }


        public static ObservableCollection<AdresseDAO> listeAdresses()
        {
            ObservableCollection<AdresseDAO> lAdresseDAOs = DAL.AdresseDAL.selectAdresses();
            return lAdresseDAOs;
        }

        public static AdresseDAO getAdresse(string idAdresse)
        {
            AdresseDAO p = DAL.AdresseDAL.getAdresse(idAdresse);
            return p;
        }

        public static void updateAdresse(AdresseDAO a)
        {
            DAL.AdresseDAL.updateAdresse(a);
        }

        public static void supprimerAdresse(string idAdresse)
        {
            DAL.AdresseDAL.supprimerAdresse(idAdresse);
        }

        public static void insertAdresse(AdresseDAO a)
        {
            DAL.AdresseDAL.insertAdresse(a);
        }
    }
}
