using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidCardCoin.ClassVM
{
    public class ProduitVM : INotifyPropertyChanged
    {
        private string idProduit;
        private string nomProduit;
        private string description;
        private double prixReserve;
        private double prixDepart;
        private double prixVente;
        private bool estVendu;
        private bool enStock;
        private int nbInvendu;
       // private LotVM lot;
        private string idLot;
       // private UtilisateurVM utilisateur;
        private string idUtilisateur;
       // private StockageVM stockage;
        private string idStockage;
        private ObservableCollection<EstimationVM> listEstimations;
        private ObservableCollection<PhotoVM> listPhotos;


        public string idProduitProperty { get { return idProduit; } set { idProduit = value; OnPropertyChanged("idProduitProperty"); } }
        public string nomProduitProperty { get { return nomProduit; } set { nomProduit = value; OnPropertyChanged("nomProduitProperty"); } }
        public string descriptionProperty { get { return description; } set { description = value; OnPropertyChanged("descriptionProperty"); } }
        public double prixReserveProperty { get { return prixReserve; } set { prixReserve = value; OnPropertyChanged("prixReserveProperty"); } }
        public double prixDepartProperty { get { return prixDepart; } set { prixDepart = value; OnPropertyChanged("prixDepartProperty"); } }
        public double prixVenteProperty { get { return prixVente; } set { prixVente = value; OnPropertyChanged("prixVenteProperty"); } }
        public bool estVenduProperty { get { return estVendu; } set { estVendu = value; OnPropertyChanged("estVenduProperty"); } }
        public bool enStockProperty { get { return enStock; } set { enStock = value; OnPropertyChanged("enStockProperty"); } }
        public int nbInvenduProperty { get { return nbInvendu; } set { nbInvendu = value; OnPropertyChanged("nbInvenduProperty"); } }
        //public LotVM lotProperty { get { return lot; } set { lot = value; OnPropertyChanged("lotProperty"); } }
        public string idLotProperty { get { return idLot; } set { idLot = value; OnPropertyChanged("idLotProperty"); } }
        //public StockageVM stockageProperty { get { return stockage; } set { stockage = value; OnPropertyChanged("stockageProperty"); } }
        public string idStockageProperty { get { return idStockage; } set { idStockage = value; OnPropertyChanged("stockageProperty"); } }
        //public UtilisateurVM utilisateurProperty { get { return utilisateur; } set { utilisateur = value; OnPropertyChanged("utilisateurProperty"); } }
        public string idUtilisateurProperty { get { return idUtilisateur; } set { idUtilisateur = value; OnPropertyChanged("idUtilisateurProperty"); } }
        public ObservableCollection<EstimationVM> listEstimationsProperty { get { return listEstimations; } set { listEstimations = value; OnPropertyChanged("listEstimationsProperty"); } }
        public ObservableCollection<PhotoVM> listPhotosProperty { get { return listPhotos; } set { listPhotos = value; OnPropertyChanged("listPhotosProperty"); } }


        public ProduitVM()
        {
            idProduit = Guid.NewGuid().ToString();
            nomProduit = "NomProduit";
            description = "descProduit";
            prixReserve = 0;
            prixDepart = 0;
            prixVente = 0;
            estVendu = false;
            enStock = false;
            nbInvendu = 0;
            idLot = "default";
            idStockage = "default";
            idUtilisateur = "default";
            listEstimations = new ObservableCollection<EstimationVM>();
            listPhotos = new ObservableCollection<PhotoVM>();

        }

        public ProduitVM(string nom)
        {
            idProduit = Guid.NewGuid().ToString();
            nomProduit = nom;
            description = "descProduit";
            prixReserve = 0;
            prixDepart = 0;
            prixVente = 0;
            estVendu = false;
            enStock = false;
            nbInvendu = 0;
            idLot = null;
            idStockage = null;
            idUtilisateur = null;
            listEstimations = new ObservableCollection<EstimationVM>();
            listPhotos = new ObservableCollection<PhotoVM>();

        }

        public ProduitVM(string idProduit, string nomProduit, string description, double prixReserve, double prixDepart,
            double prixVente, bool estVendu, bool enStock, int nbInvendu, string idLot, string idStockage, string idUtilisateur,
            ObservableCollection<EstimationVM> lEstimations, ObservableCollection<PhotoVM> lPhotos)
        {
            this.idProduit = idProduit;
            this.nomProduit = nomProduit;
            this.description = description;
            this.prixReserve = prixReserve;
            this.prixDepart = prixDepart;
            this.prixVente = prixVente;
            this.estVendu = estVendu;
            this.enStock = enStock;
            this.nbInvendu = nbInvendu;
            this.idLot = idLot;
            this.idStockage = idStockage;
            this.idUtilisateur = idUtilisateur;
            this.listEstimations = lEstimations;
            this.listPhotos = lPhotos;
        }



        public event PropertyChangedEventHandler PropertyChanged;


        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                this.PropertyChanged(this, new PropertyChangedEventArgs(info));
            }

        }
    }
}
