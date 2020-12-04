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

        public string idPhotoProperty { get { return idPhoto; } set { idPhoto = value; OnPropertyChanged("idPhotoProperty"); } }
        public string nomPhotoProperty { get { return nomPhoto; } set { nomPhoto = value; OnPropertyChanged("nomPhotoProperty"); } }
        public string urlPhotoProperty { get { return urlPhoto; } set { urlPhoto = value; OnPropertyChanged("urlPhotoProperty"); } }


        public PhotoVM()
        {
            idPhoto = Guid.NewGuid().ToString();
            nomPhoto = "NomPhoto";
            urlPhoto = "https://mes-images.com/images.png";
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
