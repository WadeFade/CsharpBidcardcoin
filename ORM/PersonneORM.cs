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
    class PersonneORM
    {
        // TODO faire l'ORM PERSONNE + UTILISATEUR + COMMISSAIRE

        // POUR RECUPERER LISTE UTILISATEURS
        public static ObservableCollection<UtilisateurVM> listeUtilisateurs()
        {
            ObservableCollection<PersonneDAO> lDAOs = PersonneDAO.listePersonnes();
            ObservableCollection<UtilisateurVM> lUtilisateurs = new ObservableCollection<UtilisateurVM>();
            foreach (PersonneDAO personne in lDAOs)
            {
                /* Il faut récupérer les Associations entre Personne et Adresse
                 * Ensuite récupérer toutes les Adresses de la Personne, ajouter ses Adresses à une liste
                 * Ensuite récupérer l'Utilisateur correspondant à la Personne s'il existe
                 * Et dans ce cas créer l'UtilisateurVM, puis l'ajouter à la collection des Utilisateurs
                 */
                ObservableCollection<AdresseVM> lAdresses = new ObservableCollection<AdresseVM>();

                ObservableCollection<PersonneAdresseDAO> lPersonneAdresses = new ObservableCollection<PersonneAdresseDAO>();

                // Récupérer l'utilisateur correspondant à la personne s'il existe.

                UtilisateurDAO user = UtilisateurDAO.getUtilisateurByIdPersonne(personne.idPersonneDAO);


                UtilisateurVM u = new UtilisateurVM();
                lUtilisateurs.Add(u);
            }
            return lUtilisateurs;
        }



        public static void updatePersonne(PersonneVM p)
        {
            PersonneDAO.updatePersonne(new PersonneDAO());
        }

        public static void supprimerPersonne(string idPersonne)
        {
            PersonneDAO.supprimerPersonne(idPersonne);
        }

        public static void insertPersonne(PersonneVM p)
        {
            PersonneDAO.insertPersonne(new PersonneDAO());
        }

    }
}
