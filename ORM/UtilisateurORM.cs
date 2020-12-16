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
    public static class UtilisateurORM
    {

        // Pour récupérer la liste des Utilisateurs
        public static ObservableCollection<UtilisateurVM> listeUtilisateurs()
        {
            // Appel PersonneORM pour récupérer la liste des Personnes
            ObservableCollection<PersonneDAO> lDAOs = PersonneORM.listePersonnes();
            ObservableCollection<UtilisateurVM> lUtilisateurs = new ObservableCollection<UtilisateurVM>();

            foreach (PersonneDAO personne in lDAOs)
            {
                /* Il faut récupérer les Associations entre Personne et Adresse
                 * Ensuite récupérer toutes les Adresses de la Personne, ajouter ses Adresses à une liste
                 * Ensuite récupérer l'Utilisateur correspondant à la Personne s'il existe
                 * Et dans ce cas créer l'UtilisateurVM, puis l'ajouter à la collection des Utilisateurs
                 */
                ObservableCollection<AdresseVM> lAdresses = new ObservableCollection<AdresseVM>();

               
                // On récupère toutes les associations entre les adresses et notre Personne
                ObservableCollection<PersonneAdresseDAO> lPersonneAdresses = PersonneAdresseDAO.getPersonneAdresseByIdPersonne(personne.idPersonneDAO);

                // On récupère toutes les adresses qui étaient dans l'association.
                foreach (PersonneAdresseDAO paDAO in lPersonneAdresses)
                {
                    AdresseVM adresse = AdresseORM.getAdresse(paDAO.idAdresseDAO);
                    lAdresses.Add(adresse);
                }


                // Récupérer l'utilisateur correspondant à la personne s'il existe.
                UtilisateurDAO user = UtilisateurDAO.getUtilisateurByIdPersonne(personne.idPersonneDAO);
                if (user != null)
                {
                    if (personne.idPersonneDAO == user.idPersonneDAO)
                    {
                        //On récupère tous les produits mis en vente par l'utilisateur
                        ObservableCollection<ProduitVM> lProduits = ProduitORM.getProduitByIdUtilisateur(user.idUtilisateurDAO);

                        // Si notre personne est un utilisateur on créer l'objet à partir de notre modèle.
                        UtilisateurVM u = new UtilisateurVM(personne.idPersonneDAO, user.idUtilisateurDAO, personne.nomPersonneDAO,
                            personne.prenomPersonneDAO, personne.dateNaissanceDAO, personne.emailDAO, personne.passwordDAO, personne.telephoneDAO,
                            personne.verifIdentiteDAO, user.modePaiementDAO, user.verifSolvabiliteDAO, user.ressortissantDAO,
                            lAdresses, lProduits);
                        lUtilisateurs.Add(u);
                    }
                }
            }
            return lUtilisateurs;
        }

        // Pour ajouter un nouveau utilisateur
        public static void insertUtilisateur(UtilisateurVM u)
        {
            // On appel insertPersonne de l'ORM personne, qui lui va appeler PersonneDAO.
            PersonneORM.insertPersonne(u);
            UtilisateurDAO.insertUtilisateur(new UtilisateurDAO(u.idUtilisateurProperty, u.verifSolvabiliteProperty, u.ressortissantProperty,
                u.modePaiementProperty, u.idPersonneProperty));
        }

        // Pour mettre à jour un utilisateur
        public static void updateUtilisateur(UtilisateurVM u)
        {
            PersonneORM.updatePersonne(u);
            UtilisateurDAO.updateUtilisateur(new UtilisateurDAO(u.idUtilisateurProperty, u.verifSolvabiliteProperty, u.ressortissantProperty,
                u.modePaiementProperty, u.idPersonneProperty));
        }

        // Pour supprimer un utilisateur
        public static void supprimerUtilisateur(UtilisateurVM u)
        {
            UtilisateurDAO.supprimerUtilisateur(u.idUtilisateurProperty);
            PersonneORM.supprimerPersonne(u);
        }
    }
}
