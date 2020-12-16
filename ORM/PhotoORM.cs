using BidCardCoin.DAO;
using BidCardCoin.ClassVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidCardCoin.ORM
{
    public static class PhotoORM
    {
        // Pour récupérer la liste des Photos avec l'id du produit
        public static ObservableCollection<PhotoVM> getPhotoByIdProduit(string idProduit)
        {
            ObservableCollection<PhotoVM> lPhotos = new ObservableCollection<PhotoVM>();
            ObservableCollection<PhotoDAO> lPhotosDAOs = PhotoDAO.getPhotoByIdProduit(idProduit);
            foreach (PhotoDAO ph in lPhotosDAOs)
            {
                PhotoVM photo = new PhotoVM(ph.idPhotoDAO, ph.nomPhotoDAO, ph.urlPhotoDAO, ph.idProduitDAO);
                lPhotos.Add(photo);
            }
            return lPhotos;
        }
    }
}
