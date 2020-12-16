using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidCardCoin.DAO
{
    public class PhotoDAO
    {
        public string idPhotoDAO;
        public string nomPhotoDAO;
        public string urlPhotoDAO;
        public string idProduitDAO;

        public PhotoDAO(string idPhotoDAO, string nomPhotoDAO, string urlPhotoDAO, string idProduitDAO)
        {
            this.idPhotoDAO = idPhotoDAO;
            this.nomPhotoDAO = nomPhotoDAO;
            this.urlPhotoDAO = urlPhotoDAO;
            this.idProduitDAO = idProduitDAO;
        }

        public static ObservableCollection<PhotoDAO> listePhotos()
        {
            ObservableCollection<PhotoDAO> lPhotoDAOs = DAL.PhotoDAL.selectPhotos();
            return lPhotoDAOs;
        }

        public static ObservableCollection<PhotoDAO> getPhotoByIdProduit(string idProduit)
        {
            ObservableCollection<PhotoDAO> lPhotoDAOs = DAL.PhotoDAL.getPhotoByIdProduit(idProduit);
            return lPhotoDAOs;
        }

        public static PhotoDAO getPhoto(string idPhoto)
        {
            PhotoDAO ph = DAL.PhotoDAL.getPhoto(idPhoto);
            return ph;
        }

        public static void updatePhoto(PhotoDAO ph)
        {
            DAL.PhotoDAL.updatePhoto(ph);
        }

        public static void supprimerPhoto(string idPhoto)
        {
            DAL.PhotoDAL.supprimerPhoto(idPhoto);
        }

        public static void insertPhoto(PhotoDAO ph)
        {
            DAL.PhotoDAL.insertPhoto(ph);
        }
    }
}
