using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidCardCoin.DAO
{
    public class LotDAO
    {
        public string idLotDAO;
        public string nomLotDAO;
        public string descriptionLotDAO;
        public string idSalleEnchereDAO;

        public LotDAO(string idLotDAO, string nomLotDAO, string descriptionLotDAO,
            string idSalleEnchereDAO)
        {
            this.idLotDAO = idLotDAO;
            this.nomLotDAO = nomLotDAO;
            this.descriptionLotDAO = descriptionLotDAO;
            this.idSalleEnchereDAO = idSalleEnchereDAO;
        }

        public static ObservableCollection<LotDAO> listeLots()
        {
            ObservableCollection<LotDAO> lLotsDAOs = DAL.LotDAL.selectLots();
            return lLotsDAOs;
        }

        public static LotDAO getLot(string idLot)
        {
            LotDAO l = DAL.LotDAL.getLot(idLot);
            return l;
        }

        public static void updateLot(LotDAO l)
        {
            DAL.LotDAL.updateLot(l);
        }

        public static void supprimerLot(string idLot)
        {
            DAL.LotDAL.supprimerLot(idLot);
        }

        public static void insertLot(LotDAO l)
        {
            DAL.LotDAL.insertLot(l);
        }
    }
}
