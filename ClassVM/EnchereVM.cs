using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidCardCoin.ClassVM
{
    public class EnchereVM : INotifyPropertyChanged
    {
        private string idEnchere;
        private DateTime dateEnchere;
        private double prixPopose;
        private bool adjuge;
        private LotVM lot;
        private CommissaireVM commissaire;
        private UtilisateurVM utilisateur;
        private OrdreAchatVM ordreAchat;

        public string idEnchereProperty { get { return idEnchere; } set { idEnchere = value; OnPropertyChanged("idEnchereProperty"); } }
        public DateTime dateEnchereProperty { get { return dateEnchere; } set { dateEnchere = value; OnPropertyChanged("dateEnchereProperty"); } }
        public double prixPoposeProperty { get { return prixPopose; } set { prixPopose = value; OnPropertyChanged("prixPoposeProperty"); } }
        public bool adjugeProperty { get { return adjuge; } set { adjuge = value; OnPropertyChanged("adjugeProperty"); } }
        public LotVM lotProperty { get { return lot; } set { lot = value; OnPropertyChanged("lotProperty"); } }
        public CommissaireVM commissaireProperty { get { return commissaire; } set { commissaire = value; OnPropertyChanged("commissaireProperty"); } }
        public UtilisateurVM utilisateurProperty { get { return utilisateur; } set { utilisateur = value; OnPropertyChanged("utilisateurProperty"); } }
        public OrdreAchatVM ordreAchatProperty { get { return ordreAchat; } set { ordreAchat = value; OnPropertyChanged("ordreAchatProperty"); } }


        // Par défaut pas d'ordreAchat mais utilisateur
        public EnchereVM()
        {
            idEnchere = Guid.NewGuid().ToString();
            dateEnchere = new DateTime();
            prixPoposeProperty = 0;
            adjuge = false;
            lot = new LotVM();
            commissaire = new CommissaireVM();
            utilisateur = new UtilisateurVM();
        }


        // Si 1 : Utilisateur | Si 2 : OrdreAchat
        public EnchereVM(int choix)
        {
            idEnchere = Guid.NewGuid().ToString();
            dateEnchere = new DateTime();
            prixPoposeProperty = 0;
            adjuge = false;
            lot = new LotVM();
            commissaire = new CommissaireVM();
            if(choix == 1)
            {
                utilisateur = new UtilisateurVM();
            } else if(choix == 2)
            {
                ordreAchat = new OrdreAchatVM();
            }
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
