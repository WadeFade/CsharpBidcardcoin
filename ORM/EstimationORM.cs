using BidCardCoin.DAO;
using BidCardCoin.ClassVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidCardCoin.ORM
{
    public static class EstimationORM
    {
        // Pour récupérer la liste des Estimations avec l'id du produit
        public static ObservableCollection<EstimationVM> getEstimationByIdProduit(string idProduit)
        {
            ObservableCollection<EstimationVM> lEstimations = new ObservableCollection<EstimationVM>();
            ObservableCollection<EstimationDAO> lEstimationDAOs = EstimationDAO.getEstimationByIdProduit(idProduit);
            foreach(EstimationDAO e in lEstimationDAOs)
            {
                EstimationVM estimation = new EstimationVM(e.idEstimationDAO, e.idProduitDAO, e.idCommissaireDAO, e.prixEstimeDAO, e.dateEstimationDAO);
                lEstimations.Add(estimation);
            }
            return lEstimations;
        }
    }
}
