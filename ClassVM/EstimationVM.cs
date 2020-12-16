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
        private string idProduit;
        private string idCommissaire;
        private double prixEstime;
        private DateTime dateEstimation;

        public string idEstimationProperty { get { return idEstimation; } set { idEstimation = value; OnPropertyChanged("idEstimationProperty"); } }
        public string idProduitProperty { get { return idProduit; } set { idProduit = value; OnPropertyChanged("idProduitProperty"); } }
        public string idCommissaireProperty { get { return idCommissaire; } set { idCommissaire = value; OnPropertyChanged("idCommissaireProperty"); } }
        public double prixEstimeProperty { get { return prixEstime; } set { prixEstime = value; OnPropertyChanged("prixEstimeProperty"); } }
        public DateTime dateEstimationProperty { get { return dateEstimation; } set { dateEstimation = value; OnPropertyChanged("dateEstimationProperty"); } }


        public EstimationVM()
        {
            idEstimation = Guid.NewGuid().ToString();
            idProduit = Guid.NewGuid().ToString();
            idCommissaire = Guid.NewGuid().ToString();
            prixEstime = 0;
            dateEstimation = new DateTime();
        }
        
        public EstimationVM(string idEstimation, string idProduit, string idCommissaire, double prixEstime,
            DateTime dateEstimation)
        {
            this.idEstimation = idEstimation;
            this.idProduit = idProduit;
            this.idCommissaire = idCommissaire;
            this.prixEstime = prixEstime;
            this.dateEstimation = dateEstimation;
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
