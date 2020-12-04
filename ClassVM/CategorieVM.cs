using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidCardCoin.ClassVM
{
    public class CategorieVM : INotifyPropertyChanged
    {
        private string idCategorie;
        private string nomCategorie;
        private string descriptionCategorie;
        private List<ProduitVM> listProduits;
        private CategorieVM categorieParente;

        public string idCategorieProperty { get { return idCategorie; } set { idCategorie = value; OnPropertyChanged("idCategorieProperty"); } }
        public string nomCategorieProperty { get { return nomCategorie; } set { nomCategorie = value; OnPropertyChanged("nomCategorieProperty"); } }
        public string descriptionCategorieProperty { get { return descriptionCategorie; } set { descriptionCategorie = value; OnPropertyChanged("descriptionCategorieProperty"); } }
        public List<ProduitVM> listProduitsProperty { get { return listProduits; } set { listProduits = value; OnPropertyChanged("listProduitsProperty"); } }
        public CategorieVM categorieParenteProperty { get { return categorieParente; } set { categorieParente = value; OnPropertyChanged("categorieParenteProperty"); } }



        public CategorieVM()
        {
            idCategorie = Guid.NewGuid().ToString();
            nomCategorie = "NomCategorie";
            descriptionCategorie = "descCategorie";
            listProduits = new List<ProduitVM>();
            categorieParente = new CategorieVM();
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
