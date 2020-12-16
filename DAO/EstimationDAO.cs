using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BidCardCoin.DAO
{
    public class EstimationDAO
    {
        public string idEstimationDAO;
        public string idProduitDAO;
        public string idCommissaireDAO;
        public double prixEstimeDAO;
        public DateTime dateEstimationDAO;

        public EstimationDAO(string idEstimationDAO, string idProduitDAO, string idCommissaireDAO,
            double prixEstimeDAO, DateTime dateEstimationDAO)
        {
            this.idEstimationDAO = idEstimationDAO;
            this.idProduitDAO = idProduitDAO;
            this.idCommissaireDAO = idCommissaireDAO;
            this.prixEstimeDAO = prixEstimeDAO;
            this.dateEstimationDAO = dateEstimationDAO;
        }

        public static ObservableCollection<EstimationDAO> listeEstimations()
        {
            ObservableCollection<EstimationDAO> lEstimationsDAOs = DAL.EstimationDAL.selectEstimations();
            return lEstimationsDAOs;
        }

        public static ObservableCollection<EstimationDAO> getEstimationByIdProduit(string idProduit)
        {
            ObservableCollection<EstimationDAO> lEstimationsDAOs = DAL.EstimationDAL.getEstimationByIdProduit(idProduit);
            return lEstimationsDAOs;
        }

        public static EstimationDAO getEstimation(string idEstimation)
        {
            EstimationDAO e = DAL.EstimationDAL.getEstimation(idEstimation);
            return e;
        }

        public static void updateEstimation(EstimationDAO e)
        {
            DAL.EstimationDAL.updateEstimation(e);
        }

        public static void supprimerEstimation(string idEstimation)
        {
            DAL.EstimationDAL.supprimerEstimation(idEstimation);
        }

        public static void insertEstimation(EstimationDAO e)
        {
            DAL.EstimationDAL.insertEstimation(e);
        }
    }
}
