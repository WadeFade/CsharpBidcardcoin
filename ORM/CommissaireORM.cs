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
    class CommissaireORM
    {

        // Pour récupérer la liste des Commissaires
        public static ObservableCollection<CommissaireVM> listeCommissaires()
        {
            // Appel PersonneORM pour récupérer la liste des Personnes
            ObservableCollection<PersonneDAO> lDAOs = PersonneORM.listePersonnes();
            ObservableCollection<CommissaireVM> lCommissaires = new ObservableCollection<CommissaireVM>();

            foreach (PersonneDAO personne in lDAOs)
            {
                /* Il faut récupérer les Associations entre Personne et Adresse
                 * Ensuite récupérer toutes les Adresses de la Personne, ajouter ses Adresses à une liste
                 * Ensuite récupérer le Commissaire correspondant à la Personne s'il existe
                 * Et dans ce cas créer le CommissaireVM, puis l'ajouter à la collection des Commissaires
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

                // Récupérer le commissaire correspondant à la personne s'il existe.
                CommissaireDAO commissaire = CommissaireDAO.getCommissaireByIdPersonne(personne.idPersonneDAO);
                if (commissaire != null)
                {
                    if (personne.idPersonneDAO == commissaire.idPersonneDAO)
                    {
                        // Si notre personne est un commissaire on créer l'objet à partir de notre modèle.
                        CommissaireVM c = new CommissaireVM(personne.idPersonneDAO, commissaire.idCommissaireDAO,
                            personne.nomPersonneDAO, personne.prenomPersonneDAO, personne.dateNaissanceDAO, personne.emailDAO,
                            personne.passwordDAO, personne.telephoneDAO, commissaire.formationDAO, personne.verifIdentiteDAO,
                            commissaire.verifFormationDAO, lAdresses);
                        lCommissaires.Add(c);
                    }
                }
            }
            return lCommissaires;
        }

        // Pour ajouter un nouveau commissaire
        public static void insertCommissaire(CommissaireVM c)
        {
            // On appel insertPersonne de l'ORM personne, qui lui va appeler PersonneDAO.
            PersonneORM.insertPersonne(c);
            CommissaireDAO.insertCommissaire(new CommissaireDAO(c.idCommissaireProperty, c.formationProperty,
                c.verifFormationProperty, c.idPersonneProperty));
        }

        // Pour mettre à jour un commissaire
        public static void updateCommissaire(CommissaireVM c)
        {
            PersonneORM.updatePersonne(c);
            CommissaireDAO.updateCommissaire(new CommissaireDAO(c.idCommissaireProperty, c.formationProperty,
                c.verifFormationProperty, c.idPersonneProperty));
        }

        // Pour supprimer un commissaire
        public static void supprimerCommissaire(CommissaireVM c)
        {
            CommissaireDAO.supprimerCommissaire(c.idCommissaireProperty);
            PersonneORM.supprimerPersonne(c);
        }
    }
}
