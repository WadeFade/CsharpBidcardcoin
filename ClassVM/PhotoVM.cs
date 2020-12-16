using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidCardCoin.ClassVM
{
    public class PhotoVM : INotifyPropertyChanged
    {
        private string idPhoto;
        private string nomPhoto;
        private string urlPhoto;
        private string idProduit;

        public string idPhotoProperty { get { return idPhoto; } set { idPhoto = value; OnPropertyChanged("idPhotoProperty"); } }
        public string nomPhotoProperty { get { return nomPhoto; } set { nomPhoto = value; OnPropertyChanged("nomPhotoProperty"); } }
        public string urlPhotoProperty { get { return urlPhoto; } set { urlPhoto = value; OnPropertyChanged("urlPhotoProperty"); } }
        public string idProduitProperty { get { return idProduit; } set { idProduit = value; OnPropertyChanged("idProduitProperty"); } }


        public PhotoVM()
        {
            idPhoto = Guid.NewGuid().ToString();
            nomPhoto = "NomPhoto";
            urlPhoto = "https://mes-images.com/images.png";
            idProduit = Guid.NewGuid().ToString();
        }

        public PhotoVM(string idPhoto, string nomPhoto, string urlPhoto, string idProduit)
        {
            this.idPhoto = idPhoto;
            this.nomPhoto = nomPhoto;
            this.urlPhoto = urlPhoto;
            this.idProduit = idProduit;
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
