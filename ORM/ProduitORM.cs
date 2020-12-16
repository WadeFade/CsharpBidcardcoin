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
    public static class ProduitORM
    {

        // Pour récupérer la liste des Produits
        public static ObservableCollection<ProduitVM> listeProduits()
        {
            ObservableCollection<ProduitVM> lProduits = new ObservableCollection<ProduitVM>();
            ObservableCollection<ProduitDAO> lDAOs = ProduitDAO.listeProduits();
            foreach (ProduitDAO pr in lDAOs)
            {
                // On récupère les estimations pour se produit
                ObservableCollection<EstimationVM> lEstimations = EstimationORM.getEstimationByIdProduit(pr.idProduitDAO);
                ObservableCollection<PhotoVM> lPhotos = PhotoORM.getPhotoByIdProduit(pr.idProduitDAO);

                ProduitVM p = new ProduitVM(pr.idProduitDAO, pr.nomProduitDAO, pr.descriptionProduitDAO,
                    pr.prixReserveDAO, pr.prixDepartDAO, pr.prixVenteDAO, pr.estVenduDAO, pr.enStockDAO,
                    pr.nbInvendu, pr.idLotDAO, pr.idStockageDAO, pr.idUtilisateurDAO, lEstimations, lPhotos);
                lProduits.Add(p);
            }
            return lProduits;
        }

        public static void insertProduitAvecUser(ProduitVM p, string idUtilisateur)
        {
            ProduitDAO.insertProduit(new ProduitDAO(p.idProduitProperty, p.nomProduitProperty, p.descriptionProperty, 
                p.prixReserveProperty, p.prixDepartProperty, p.prixVenteProperty, p.estVenduProperty, p.enStockProperty,
                p.nbInvenduProperty, p.idLotProperty, idUtilisateur, p.idStockageProperty)); ;
        }

        public static void insertProduit(ProduitVM p)
        {
            ProduitDAO.insertProduit(new ProduitDAO(p.idProduitProperty, p.nomProduitProperty, p.descriptionProperty,
                p.prixReserveProperty, p.prixDepartProperty, p.prixVenteProperty, p.estVenduProperty, p.enStockProperty,
                p.nbInvenduProperty, p.idLotProperty, p.idUtilisateurProperty, p.idStockageProperty)); ;
        }

        // Pour récupérer la liste des Produits grâce à l'id d'un utilisateur
        public static ObservableCollection<ProduitVM> getProduitByIdUtilisateur(string idUtilisateur)
        {
            ObservableCollection<ProduitVM> lProduitsTrie = new ObservableCollection<ProduitVM>();
            ObservableCollection<ProduitVM> lProduits = listeProduits();

            foreach (ProduitVM pr in lProduits)
            {
                if(idUtilisateur == pr.idUtilisateurProperty)
                {
                    lProduitsTrie.Add(pr);
                }
            }

            return lProduitsTrie;
        }
    }
}
