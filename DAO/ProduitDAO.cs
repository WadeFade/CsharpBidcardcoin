using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidCardCoin.DAO
{
    public class ProduitDAO
    {
        public string idProduitDAO;
        public string nomProduitDAO;
        public string descriptionProduitDAO;
        public double prixReserveDAO;
        public double prixDepartDAO;
        public double prixVenteDAO;
        public bool estVenduDAO;
        public bool enStockDAO;
        public int nbInvendu;
        public string idLotDAO;
        public string idUtilisateurDAO;
        public string idStockageDAO;


        public ProduitDAO(string idProduitDAO, string nomProduitDAO, string descriptionProduitDAO, double prixReserveDAO,
            double prixDepartDAO, double prixVenteDAO, bool estVenduDAO, bool enStockDAO, int nbInvendu,
            string idLotDAO, string idUtilisateurDAO, string idStockageDAO)
        {
            this.idProduitDAO = idProduitDAO;
            this.nomProduitDAO = nomProduitDAO;
            this.descriptionProduitDAO = descriptionProduitDAO;
            this.prixReserveDAO = prixReserveDAO;
            this.prixDepartDAO = prixDepartDAO;
            this.prixVenteDAO = prixVenteDAO;
            this.estVenduDAO = estVenduDAO;
            this.enStockDAO = enStockDAO;
            this.nbInvendu = nbInvendu;
            this.idLotDAO = idLotDAO;
            this.idUtilisateurDAO = idUtilisateurDAO;
            this.idStockageDAO = idStockageDAO;
        }

        public static ObservableCollection<ProduitDAO> listeProduits()
        {
            ObservableCollection<ProduitDAO> lProduitsDAOs = DAL.ProduitDAL.selectProduits();
            return lProduitsDAOs;
        }

        public static ObservableCollection<ProduitDAO> getProduitByIdUtilisateur(string idUtilisateur)
        {
            ObservableCollection<ProduitDAO> lProduitsDAOs = DAL.ProduitDAL.getProduitByIdUtilisateur(idUtilisateur);
            return lProduitsDAOs;
        }

        public static ObservableCollection<ProduitDAO> getProduitByIdLot(string idLot)
        {
            ObservableCollection<ProduitDAO> lProduitsDAOs = DAL.ProduitDAL.getProduitByIdLot(idLot);
            return lProduitsDAOs;
        }

        public static void updateProduit(ProduitDAO p)
        {
            DAL.ProduitDAL.updateProduit(p);
        }

        public static void supprimerProduit(string idProduit)
        {
            DAL.ProduitDAL.supprimerProduit(idProduit);
        }

        public static void insertProduit(ProduitDAO p)
        {
            DAL.ProduitDAL.insertProduit(p);
        }
    }
}
