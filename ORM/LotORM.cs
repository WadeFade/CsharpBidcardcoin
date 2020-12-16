using BidCardCoin.DAO;
using BidCardCoin.Class;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BidCardCoin.ClassVM;

namespace BidCardCoin.ORM
{
    public static class LotORM
    {
        public static ObservableCollection<LotVM> listeLots()
        {
            ObservableCollection<LotVM> lLots = new ObservableCollection<LotVM>();
            ObservableCollection<LotDAO> lDAOs = LotDAO.listeLots();
            /*
            foreach (LotDAO lot in lDAOs)
            {
                ObservableCollection<ProduitVM> lProduits = ProduitORM.s
            }
            */
            return lLots;
        }
    }
}
