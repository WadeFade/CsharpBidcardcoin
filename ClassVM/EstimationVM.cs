using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidCardCoin.ClassVM
{
    public class EstimationVM : INotifyPropertyChanged
    {
        private string idEstimation;
        private ProduitVM produit;
        private CommissaireVM commissaire;
        private double prixEstime;
        private DateTime dateEstimation;

        public string idEstimationProperty { get { return idEstimation; } set { idEstimation = value; OnPropertyChanged("idEstimationProperty"); } }
        public ProduitVM produitProperty { get { return produit; } set { produit = value; OnPropertyChanged("produitProperty"); } }
        public CommissaireVM commissaireProperty { get { return commissaire; } set { commissaire = value; OnPropertyChanged("commissaireProperty"); } }
        public double prixEstimeProperty { get { return prixEstime; } set { prixEstime = value; OnPropertyChanged("prixEstimeProperty"); } }
        public DateTime dateEstimationProperty { get { return dateEstimation; } set { dateEstimation = value; OnPropertyChanged("dateEstimationProperty"); } }


        public EstimationVM()
        {
            produit = new ProduitVM();
            commissaire = new CommissaireVM();
            prixEstime = 0;
            dateEstimation = new DateTime();
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
