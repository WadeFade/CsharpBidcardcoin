using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidCardCoin.ClassVM
{
    public class StockageVM : INotifyPropertyChanged
    {
        private string idStockage;
        private Class.AdresseVM adresse;

        public string idStockageProperty { get { return idStockage; } set { idStockage = value; OnPropertyChanged("idStockageProperty"); } }
        public Class.AdresseVM adresseProperty { get { return adresse; } set { adresse = value; OnPropertyChanged("adresseProperty"); } }


        public StockageVM()
        {
            idStockage = Guid.NewGuid().ToString();
            adresse = new Class.AdresseVM();
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
