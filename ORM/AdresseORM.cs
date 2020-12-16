using BidCardCoin.DAO;
using BidCardCoin.Class;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidCardCoin.ORM
{
    public static class AdresseORM
    {

        public static AdresseVM getAdresse(string idAdresse)
        {
            // On récupère le Data Object de l'Adresse.
            AdresseDAO a = AdresseDAO.getAdresse(idAdresse);

            // On créer l'objet Adresse à partir de notre modèle, grâce aux données de l'objet DAO
            AdresseVM adresse = new AdresseVM(a.idAdresseDAO, a.numDAO, a.rueDAO, a.villeDAO, a.codePostalDAO, a.paysDAO);
            return adresse;
        }

        public static void insertAdresse(AdresseVM a, string idPersonne)
        {
            AdresseDAO.insertAdresse(new AdresseDAO(a.idAdresseProperty, a.numProperty, a.rueProperty,
                a.villeProperty, a.codePostalProperty, a.paysProperty));
            PersonneAdresseDAO.insertPersonneAdresse(new PersonneAdresseDAO(idPersonne, a.idAdresseProperty));
        }

        public static void supprimerPersonneAdresse(AdresseVM a, string idPersonne)
        {
            PersonneAdresseDAO.supprimerPersonneAdresse(idPersonne, a.idAdresseProperty);
        }

        public static void supprimerAdresse(AdresseVM a)
        {
            AdresseDAO.supprimerAdresse(a.idAdresseProperty);
        }
    }
}
