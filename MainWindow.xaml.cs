using BidCardCoin.ClassVM;
using BidCardCoin.ORM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BidCardCoin
{

    public partial class MainWindow : Window
    {
        UtilisateurVM myUser;
        CommissaireVM myCommissaire;
        ProduitVM myProduit;
        ObservableCollection<UtilisateurVM> lUtilisateurs;
        ObservableCollection<CommissaireVM> lCommissaires;
        ObservableCollection<ProduitVM> lProduits;
        userWindow win2 = null;
        commissaireWindow win3 = null;

        public MainWindow()
        {
            InitializeComponent();
            loadEverything();
            appliquerContexte();

        }

        void loadEverything()
        {
            loadUtilisateurs();
            loadCommissaires();
            loadProduits();
        }

        // Récupérer les Utilisateurs + les Bind à la vue
        void loadUtilisateurs()
        {
            // Récupération de tous les utilisateurs
            lUtilisateurs = UtilisateurORM.listeUtilisateurs();
            // Pour lier notre liste d'Utilisateurs à la vue
            GridUser.ItemsSource = lUtilisateurs; // On Bind la liste avec la source de la vue.
        }

        // Récupérer les Commissaires + les Bind à la vue
        void loadCommissaires()
        {
            // Récupération de tous les commissaires
            lCommissaires = CommissaireORM.listeCommissaires();
            // Pour lier notre liste de Commissaires à la vue
            GridCommissaire.ItemsSource = lCommissaires; // On bind la liste avec la source de la vue.
        }

        // Récupérer les Produits + les Bind à la vue
        void loadProduits()
        {
            // Récupération de tous les Produits
            lProduits = ProduitORM.listeProduits();
            // Pour lier notre liste de Produits à la vue
            GridProduit.ItemsSource = lProduits; // On bind la liste avec la source de la vue
        }

        void appliquerContexte()
        {
            appliquerUserContexte();
            appliquerCommissaireContexte();
            appliquerProduitContexte();
        }

        void appliquerUserContexte()
        {
            // Objet utilisé pour l'ajout d'un utilisateur
            myUser = new UtilisateurVM();
            // Liens avec les TextBoxs
            nomUserTextBox.DataContext = myUser;
            prenomUserTextBox.DataContext = myUser;
            dateNaissanceUserTextBox.DataContext = myUser;
            emailUserTextBox.DataContext = myUser;
            passwordUserTextBox.DataContext = myUser;
            telephoneUserTextBox.DataContext = myUser;
            verifIdentiteUserTextBox.DataContext = myUser;
            modePaiementUserTextBox.DataContext = myUser;
            verifSolvabiliteUserTextBox.DataContext = myUser;
            ressortissantUserTextBox.DataContext = myUser;
            adresseUserTextBox.DataContext = myUser;
        }

        void appliquerCommissaireContexte()
        {
            //  Objet utilisé pour l'ajout d'un commissaire
            myCommissaire = new CommissaireVM();
            // Liens avec les TextBoxs
            nomCommissaireTextBox.DataContext = myCommissaire;
            prenomCommissaireTextBox.DataContext = myCommissaire;
            dateNaissanceCommissaireTextBox.DataContext = myCommissaire;
            emailCommissaireTextBox.DataContext = myCommissaire;
            passwordCommissaireTextBox.DataContext = myCommissaire;
            telephoneCommissaireTextBox.DataContext = myCommissaire;
            formationCommissaireTextBox.DataContext = myCommissaire;
            verifFormationCommissaireTextBox.DataContext = myCommissaire;
            verifIdentiteCommissaireTextBox.DataContext = myCommissaire;
            adresseCommissaireTextBox.DataContext = myCommissaire;
        }

        void appliquerProduitContexte()
        {
            // Objet utilisé pour l'ajout d'un produit
            myProduit = new ProduitVM();
            // Liens avec les TextBoxs de la vue
            nomProduitTextBox.DataContext = myProduit;
            descriptionProduitTextBox.DataContext = myProduit;
            prixReserveProduitTextBox.DataContext = myProduit;
            prixDepartProduitTextBox.DataContext = myProduit;
            prixVenteProduitTextBox.DataContext = myProduit;
            estVenduProduitTextBox.DataContext = myProduit;
            enStockProduitTextBox.DataContext = myProduit;
            nbInvenduProduitTextBox.DataContext = myProduit;
        }

        // Ajout d'un Utilisateur
        private void AjoutUtilisateur_Click(object sender, RoutedEventArgs e)
        {
            lUtilisateurs.Add(myUser);
            UtilisateurORM.insertUtilisateur(myUser);
            GridUser.Items.Refresh();
            appliquerUserContexte();
        }

        // Ajout d'un Commissaire
        private void AjoutCommissaire_Click(object sender, RoutedEventArgs e)
        {
            lCommissaires.Add(myCommissaire);
            CommissaireORM.insertCommissaire(myCommissaire);
            GridCommissaire.Items.Refresh();
            appliquerCommissaireContexte();
        }

        // Pour ajouter un produit
        private void AjoutProduit_Click(object sender, RoutedEventArgs e)
        {
            lProduits.Add(myProduit);
            ProduitORM.insertProduit(myProduit);
            GridProduit.Items.Refresh();
            appliquerProduitContexte();
        }

        // Pour supprimer un Utilisateur
        private void SupprUtilisateur_Click(object sender, RoutedEventArgs e)
        {
            if (GridUser.SelectedItem is UtilisateurVM)
            {
                UtilisateurVM toRemove = (UtilisateurVM)GridUser.SelectedItem;
                lUtilisateurs.Remove(toRemove);
                GridUser.Items.Refresh();
                UtilisateurORM.supprimerUtilisateur(toRemove);

            }
            else
            {
                MessageBox.Show("Vous devez sélectionner un élément avant de le supprimer !");
            }
        }

        // Pour supprimer un Commissaire
        private void SupprCommissaire_Click(object sender, RoutedEventArgs e)
        {
            if (GridCommissaire.SelectedItem is CommissaireVM)
            {

                CommissaireVM toRemove = (CommissaireVM)GridCommissaire.SelectedItem;
                lCommissaires.Remove(toRemove);
                GridCommissaire.Items.Refresh();
                CommissaireORM.supprimerCommissaire(toRemove);
            }
            else
            {
                MessageBox.Show("Vous devez sélectionner un élément avant de le supprimer !");
            }
        }

        // Fonctions de REFRESH
        private void RefreshUtilisateur_Click(object sender, RoutedEventArgs e)
        {
            loadUtilisateurs();
        }

        private void RefreshCommissaire_Click(object sender, RoutedEventArgs e)
        {
            loadCommissaires();
        }

        // Pour aller sur la page de modification d'un utilisateur
        private void ModifUtilisateur_Click(object sender, RoutedEventArgs e)
        {
            if (GridUser.SelectedItem is UtilisateurVM)
            {
                win2 = new userWindow((PersonneVM)GridUser.SelectedItem);
                win2.Show();
            }
            else
            {
                MessageBox.Show("Vous devez sélectionner un utilisateur pour pouvoir le modifier !");
            }
        }

        // Pour aller sur la page de modification d'un commissaire
        private void ModifCommissaire_Click(object sender, RoutedEventArgs e)
        {
            if (GridCommissaire.SelectedItem is CommissaireVM)
            {
                win3 = new commissaireWindow((CommissaireVM)GridCommissaire.SelectedItem);
                win3.Show();
            }
            else
            {
                MessageBox.Show("Vous devez sélectionner un commissaire pour pouvoir le modifier !");
            }
        }

        // Pour détecter le changement de sélection sur la Grille utilisateur
        private void GridUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GridUser.SelectedItem is UtilisateurVM)
            {
                UtilisateurVM u = (UtilisateurVM)GridUser.SelectedItem;
                // MessageBox.Show($"Utilisateur sélectionné : "+ u.prenomPersonneProperty + " - " +u.nomPersonneProperty);
            }

        }

    }
}