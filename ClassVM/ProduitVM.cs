using System;
using System.Collections.Generic;
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
        private LotVM lot;
        private UtilisateurVM utilisateur;
        private List<EstimationVM> listEstimations;
        private List<PhotoVM> listPhotos;
        
        //idStockage TODO OBJ

        public string idProduitProperty { get { return idProduit; } set { idProduit = value; OnPropertyChanged("idProduitProperty"); } }
        public string nomProduitProperty { get { return nomProduit; } set { nomProduit = value; OnPropertyChanged("nomProduitProperty"); } }
        public string descriptionProperty { get { return description; } set { description = value; OnPropertyChanged("descriptionProperty"); } }
        public double prixReserveProperty { get { return prixReserve; } set { prixReserve = value; OnPropertyChanged("prixReserveProperty"); } }
        public double prixDepartProperty { get { return prixDepart; } set { prixDepart = value; OnPropertyChanged("prixDepartProperty"); } }
        public double prixVenteProperty { get { return prixVente; } set { prixVente = value; OnPropertyChanged("prixVenteProperty"); } }
        public bool estVenduProperty { get { return estVendu; } set { estVendu = value; OnPropertyChanged("estVenduProperty"); } }
        public bool enStockProperty { get { return enStock; } set { enStock = value; OnPropertyChanged("enStockProperty"); } }
        public int nbInvenduProperty { get { return nbInvendu; } set { nbInvendu = value; OnPropertyChanged("nbInvenduProperty"); } }
        public LotVM lotProperty { get { return lot; } set { lot = value; OnPropertyChanged("lotProperty"); } }
        public UtilisateurVM utilisateurProperty { get { return utilisateur; } set { utilisateur = value; OnPropertyChanged("utilisateurProperty"); } }
        public List<EstimationVM> listEstimationsProperty { get { return listEstimations; } set { listEstimations = value; OnPropertyChanged("listEstimationsProperty"); } }
        public List<PhotoVM> listPhotosProperty { get { return listPhotos; } set { listPhotos = value; OnPropertyChanged("listPhotosProperty"); } }


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
            lot = new LotVM();
            utilisateur = new UtilisateurVM();
            listEstimations = new List<EstimationVM>();
            listPhotos = new List<PhotoVM>();

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
            lot = new LotVM();
            utilisateur = new UtilisateurVM();
            listEstimations = new List<EstimationVM>();
            listPhotos = new List<PhotoVM>();

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
