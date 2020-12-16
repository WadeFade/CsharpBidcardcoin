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
    public static class PersonneORM
    {
       
        // Récupérer la liste des Personnes
        public static ObservableCollection<PersonneDAO> listePersonnes()
        {
            ObservableCollection<PersonneDAO> lDAOs = PersonneDAO.listePersonnes();
            return lDAOs;
        }

        public static void insertPersonne(PersonneVM p)
        {
            PersonneDAO.insertPersonne(new PersonneDAO(p.idPersonneProperty, p.nomPersonneProperty, p.prenomPersonneProperty,
                p.dateNaissanceProperty, p.telephoneProperty, p.emailProperty, p.passwordProperty, p.verifIdentiteProperty));
        }

        
        public static void updatePersonne(PersonneVM p)
        {
            PersonneDAO.updatePersonne(new PersonneDAO(p.idPersonneProperty, p.nomPersonneProperty, p.prenomPersonneProperty,
                p.dateNaissanceProperty, p.telephoneProperty, p.emailProperty, p.passwordProperty, p.verifIdentiteProperty));
        }
        
        public static void supprimerPersonne(PersonneVM p)
        {
            PersonneDAO.supprimerPersonne(p.idPersonneProperty);
            
        }
    }
}
