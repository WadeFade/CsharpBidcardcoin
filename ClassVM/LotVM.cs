using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidCardCoin.ClassVM
{
    public class LotVM : INotifyPropertyChanged
    {
        private string idLot;
        private string nomLot;
        private string descriptionLot;
        private ObservableCollection<ProduitVM> lproduits;
        private SalleEnchereVM salleEnchere;

        public string idLotProperty { get { return idLot; } set { idLot = value; OnPropertyChanged("idLotProperty"); } }
        public string nomLotProperty { get { return nomLot; } set { nomLot = value; OnPropertyChanged("nomLotProperty"); } }
        public string descriptionLotProperty { get { return descriptionLot; } set { descriptionLot = value; OnPropertyChanged("descriptionLotProperty"); } }
        public ObservableCollection<ProduitVM> lproduitsProperty { get { return lproduits; } set { lproduits = value; OnPropertyChanged("lproduitsProperty"); } }
        public SalleEnchereVM salleEnchereProperty { get { return salleEnchere; } set { salleEnchere = value; OnPropertyChanged("salleEnchereProperty"); } }


        public LotVM()
        {
            idLot = Guid.NewGuid().ToString();
            nomLot = "Nom";
            descriptionLot = "Desc";
            lproduits = new ObservableCollection<ProduitVM>();
            salleEnchere = new SalleEnchereVM();
        }

        public LotVM(string idLot, string nomLot, string descriptionLot, ObservableCollection<ProduitVM> lproduits,
            SalleEnchereVM salleEnchere)
        {
            this.idLot = idLot;
            this.nomLot = nomLot;
            this.descriptionLot = descriptionLot;
            this.lproduits = lproduits;
            this.salleEnchere = salleEnchere;
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
