using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidCardCoin.Class
{
    public class AdresseVM : INotifyPropertyChanged
    {
        private string idAdresse;
        private int num;
        private string rue;
        private string ville;
        private string codePostal;
        private string pays;

        public string idAdresseProperty { get { return idAdresse; } set { idAdresse = value; OnPropertyChanged("idAdresseProperty"); } }
        public int numProperty { get { return num; } set { num = value; OnPropertyChanged("numProperty"); } }
        public string rueProperty { get { return rue; } set { rue = value; OnPropertyChanged("rueProperty"); } }
        public string villeProperty { get { return ville; } set { ville = value; OnPropertyChanged("villeProperty"); } }
        public string codePostalProperty { get { return codePostal; } set { codePostal = value; OnPropertyChanged("codePostalProperty"); } }
        public string paysProperty { get { return pays; } set { pays = value; OnPropertyChanged("paysProperty"); } }



        public AdresseVM()
        {
            idAdresse = Guid.NewGuid().ToString();
            num = 0;
            rue = "Rue par défaut";
            ville = "Ville par défaut";
            codePostal = "44100";
            pays = "France";
        }

        public AdresseVM(string idAdresse, int num, string rue, string ville,
            string codePostal, string pays)
        {
            this.idAdresse = idAdresse;
            this.num = num;
            this.rue = rue;
            this.ville = ville;
            this.codePostal = codePostal;
            this.pays = pays;
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
