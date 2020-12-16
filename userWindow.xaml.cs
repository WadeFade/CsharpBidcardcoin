using BidCardCoin.Class;
using BidCardCoin.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BidCardCoin.ClassVM;

namespace BidCardCoin
{
    
    public partial class userWindow : Window
    {
        UtilisateurVM pToShow;
        AdresseVM myAdresse;
        ProduitVM myProduit;

        public userWindow(PersonneVM p)
        {
            InitializeComponent();
            pToShow = (UtilisateurVM)p;
            appliquerContexte();
        }


        void appliquerContexte()
        {
            appliquerUserContexte();
            appliquerAdresseContexte();
            appliquerProduitContexte();
        }

        void appliquerAdresseContexte()
        {
            myAdresse = new AdresseVM();

            numAdresseTextBox.DataContext = myAdresse;
            rueAdresseTextBox.DataContext = myAdresse;
            villeAdresseTextBox.DataContext = myAdresse;
            codePostalAdresseTextBox.DataContext = myAdresse;
            paysAdresseTextBox.DataContext = myAdresse;
        }

        void appliquerUserContexte()
        {
            // Bind avec la vue des Infos de l'utilisateur
            idPersonneTextBox.DataContext = pToShow;
            idUtilisateurTextBox.DataContext = pToShow;
            nomUserTextBox.DataContext = pToShow;
            prenomUserTextBox.DataContext = pToShow;
            dateNaissanceUserTextBox.DataContext = pToShow;
            emailUserTextBox.DataContext = pToShow;
            passwordUserTextBox.DataContext = pToShow;
            telephoneUserTextBox.DataContext = pToShow;
            verifIdentiteUserTextBox.DataContext = pToShow;
            modePaiementUserTextBox.DataContext = pToShow;
            verifSolvabiliteUserTextBox.DataContext = pToShow;
            ressortissantUserTextBox.DataContext = pToShow;
            // Bind de la liste des adresses
            GridUserAdresses.ItemsSource = pToShow.adressePersonneProperty;
            // Bind de la liste des produits
            GridUserProduit.ItemsSource = pToShow.produitsProperty;
        }

        void appliquerProduitContexte()
        {
            myProduit = new ProduitVM();

            nomProduitTextBox.DataContext = myProduit;
            descriptionProduitTextBox.DataContext = myProduit;
            prixReserveProduitTextBox.DataContext = myProduit;
            prixDepartProduitTextBox.DataContext = myProduit;
            prixVenteProduitTextBox.DataContext = myProduit;
            estVenduProduitTextBox.DataContext = myProduit;
            enStockProduitTextBox.DataContext = myProduit;
            nbInvenduProduitTextBox.DataContext = myProduit;
            idLotProduitTextBox.DataContext = myProduit;
            idStockageProduitTextBox.DataContext = myProduit;
        }

        private void AjoutAdresse_Click(object sender, RoutedEventArgs e)
        {
            pToShow.adressePersonneProperty.Add(myAdresse);
            AdresseORM.insertAdresse(myAdresse, pToShow.idPersonneProperty);
            GridUserAdresses.Items.Refresh();
            appliquerAdresseContexte();
            
        }
        private void AjoutProduit_Click(object sender, RoutedEventArgs e)
        {
            pToShow.produitsProperty.Add(myProduit);
            ProduitORM.insertProduitAvecUser(myProduit, pToShow.idUtilisateurProperty);
            GridUserProduit.Items.Refresh();
            appliquerProduitContexte();
        }

        private void ModifInfoUser_Click(object sender, RoutedEventArgs e)
        {
            UtilisateurORM.updateUtilisateur((UtilisateurVM)pToShow);
        }

        private void SupprAdresse_Click(object sender, RoutedEventArgs e)
        {
            if (GridUserAdresses.SelectedItem is AdresseVM)
            {
                AdresseVM toRemove = (AdresseVM)GridUserAdresses.SelectedItem;
                pToShow.adressePersonneProperty.Remove(toRemove);
                GridUserAdresses.Items.Refresh();
                AdresseORM.supprimerPersonneAdresse(toRemove, pToShow.idPersonneProperty);
            }
        }

        private void RefreshAdresse_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
