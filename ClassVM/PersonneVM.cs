using BidCardCoin.Class;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidCardCoin
{
    public abstract class PersonneVM : INotifyPropertyChanged
    {

        protected string idPersonne;
        protected string nomPersonne;
        protected string prenomPersonne;
        protected DateTime dateNaissance;
        protected string email;
        protected string telephone;
        protected bool verifIdentite;
        protected ObservableCollection<AdresseVM> adressePersonne;
        

        public string idPersonneProperty { get { return idPersonne; } set { idPersonne = value; OnPropertyChanged("idPersonneProperty"); } }
        public string nomPersonneProperty { get { return nomPersonne; } set { nomPersonne = value; OnPropertyChanged("nomPersonneProperty"); } }
        public string prenomPersonneProperty { get { return prenomPersonne; } set { prenomPersonne = value; OnPropertyChanged("prenomPersonneProperty"); } }
        public DateTime dateNaissanceProperty { get { return dateNaissance; } set { dateNaissance = value; OnPropertyChanged("dateNaissanceProperty"); } }
        public string emailProperty { get { return email; } set { email = value; OnPropertyChanged("emailProperty"); } }
        public string telephoneProperty { get { return telephone; } set { telephone = value; OnPropertyChanged("telephoneProperty"); } }
        public bool verifIdentiteProperty { get { return verifIdentite; } set { verifIdentite = value; OnPropertyChanged("verifIdentiteProperty"); } }
        public ObservableCollection<AdresseVM> adressePersonneProperty { get { return adressePersonne; } set { adressePersonne = value; OnPropertyChanged("adressePersonneProperty"); } }
        


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string info)
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

