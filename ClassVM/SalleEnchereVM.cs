using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidCardCoin.ClassVM
{
    public class SalleEnchereVM : INotifyPropertyChanged
    {
        private string idSalleEnchere;
        private string nomVente;
        private Class.AdresseVM adresseSalleEnchere;

        public string idSalleEnchereProperty { get { return idSalleEnchere; } set { idSalleEnchere = value; OnPropertyChanged("idSalleEnchereProperty"); } }
        public string nomVenteProperty { get { return nomVente; } set { nomVente = value; OnPropertyChanged("nomVenteProperty"); } }
        public Class.AdresseVM adresseSalleEnchereProperty { get { return adresseSalleEnchere; } set { adresseSalleEnchere = value; OnPropertyChanged("adresseSalleEnchereProperty"); } }



        public SalleEnchereVM()
        {
            idSalleEnchere = Guid.NewGuid().ToString();
            nomVente = "NomVente";
            adresseSalleEnchere = new Class.AdresseVM();
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
