using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidCardCoin.ClassVM
{
    public class OrdreAchatVM : INotifyPropertyChanged
    {
        private string idOrdreAchat;
        private double prixMax;
        private DateTime dateOrdreAchat;
        private UtilisateurVM utilisateur;
        private LotVM lot;

        public string idOdreAchatProperty { get { return idOrdreAchat; } set { idOrdreAchat = value; OnPropertyChanged("idOdreAchatProperty"); } }
        public double prixMaxProperty { get { return prixMax; } set { prixMax = value; OnPropertyChanged("prixMaxProperty"); } }
        public DateTime dateOrdreAchatProperty { get { return dateOrdreAchat; } set { dateOrdreAchat = value; OnPropertyChanged("dateOrdreAchatProperty"); } }
        public UtilisateurVM utilisateurProperty { get { return utilisateur; } set { utilisateur = value; OnPropertyChanged("utilisateurProperty"); } }
        public LotVM lotProperty { get { return lot; } set { lot = value; OnPropertyChanged("lotProperty"); } }


        public OrdreAchatVM()
        {
            idOrdreAchat = Guid.NewGuid().ToString();
            prixMax = 0;
            dateOrdreAchat = new DateTime();
            utilisateur = new UtilisateurVM();
            lot = new LotVM();
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
