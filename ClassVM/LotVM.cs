using System;
using System.Collections.Generic;
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
        //idSalleEnchere TODO OBJ

        public string idLotProperty { get { return idLot; } set { idLot = value; OnPropertyChanged("idLotProperty"); } }
        public string nomLotProperty { get { return nomLot; } set { nomLot = value; OnPropertyChanged("nomLotProperty"); } }
        public string descriptionLotProperty { get { return descriptionLot; } set { descriptionLot = value; OnPropertyChanged("descriptionLotProperty"); } }




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
