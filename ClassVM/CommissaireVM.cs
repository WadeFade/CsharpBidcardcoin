using BidCardCoin.Class;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidCardCoin
{
    public class CommissaireVM : PersonneVM
    {

        private string idCommissaire;
        private string formation;
        private bool verifFormation;

        public string idCommissaireProperty { get { return idCommissaire; } set { idCommissaire = value; OnPropertyChanged("idCommissaireProperty"); } }
        public string formationProperty { get { return formation; } set { formation = value; OnPropertyChanged("formationProperty"); } }
        public bool verifFormationProperty { get { return verifFormation; } set { verifFormation = value; OnPropertyChanged("verifFormationProperty"); } }


        public CommissaireVM()
        {
            idPersonne = Guid.NewGuid().ToString();
            idCommissaire = Guid.NewGuid().ToString();
            nomPersonne = "NomCommissaire";
            prenomPersonne = "PrenomCommissaire";
            dateNaissance = new DateTime();
            email = "email@test.com";
            telephone = "00 00 00 00 00";
            formation = "Formation par defaut";
            verifIdentite = false;
            verifFormation = false;
            adressePersonne = new ObservableCollection<AdresseVM>();
        }

        public CommissaireVM(string idPersonne, string idCommissaire,
            string nomPersonne, string prenomPersonne, DateTime dateNaissance,
            string email, string telephone, string formation, bool verifIdentite,
            bool verifFormation, ObservableCollection<AdresseVM> adressePersonne)
        {
            this.idPersonne = idPersonne;
            this.idCommissaire = idCommissaire;
            this.nomPersonne = nomPersonne;
            this.prenomPersonne = prenomPersonne;
            this.dateNaissance = dateNaissance;
            this.email = email;
            this.telephone = telephone;
            this.formation = formation;
            this.verifIdentite = verifIdentite;
            this.verifFormation = verifFormation;
            this.adressePersonne = adressePersonne;
        }
    }
}
