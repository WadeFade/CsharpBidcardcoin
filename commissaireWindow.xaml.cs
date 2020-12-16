using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BidCardCoin.Class;
using BidCardCoin.ORM;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BidCardCoin
{
    /// <summary>
    /// Logique d'interaction pour commissaireWindow.xaml
    /// </summary>
    public partial class commissaireWindow : Window
    {
        PersonneVM pToShow;
        AdresseVM myAdresse;
        public commissaireWindow(PersonneVM p)
        {
            InitializeComponent();
            pToShow = p;
            appliquerContexte();
        }

        void appliquerContexte()
        {
            appliquerCommissaireContexte();
            appliquerAdresseContexte();
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

        void appliquerCommissaireContexte()
        {
            // Bind avec la vue des Infos du Commissaire
            idPersonneTextBox.DataContext = pToShow;
            idCommissaireTextBox.DataContext = pToShow;
            nomCommissaireTextBox.DataContext = pToShow;
            prenomCommissaireTextBox.DataContext = pToShow;
            dateNaissanceCommissaireTextBox.DataContext = pToShow;
            emailCommissaireTextBox.DataContext = pToShow;
            passwordCommissaireTextBox.DataContext = pToShow;
            telephoneCommissaireTextBox.DataContext = pToShow;
            verifIdentiteCommissaireTextBox.DataContext = pToShow;
            formationCommissaireTextBox.DataContext = pToShow;
            verifFormationCommissaireTextBox.DataContext = pToShow;
            // Bind de la liste des adresses
            GridCommissaireAdresses.ItemsSource = pToShow.adressePersonneProperty;
        }

        private void AjoutAdresse_Click(object sender, RoutedEventArgs e)
        {
            pToShow.adressePersonneProperty.Add(myAdresse);
            AdresseORM.insertAdresse(myAdresse, pToShow.idPersonneProperty);
            GridCommissaireAdresses.Items.Refresh();
            appliquerAdresseContexte();
        }

        private void ModifAdresse_Click(object sender, RoutedEventArgs e)
        {
            CommissaireORM.updateCommissaire((CommissaireVM)pToShow);
        }

        private void SupprAdresse_Click(object sender, RoutedEventArgs e)
        {
            if (GridCommissaireAdresses.SelectedItem is CommissaireVM)
            {
                AdresseVM toRemove = (AdresseVM)GridCommissaireAdresses.SelectedItem;
                pToShow.adressePersonneProperty.Remove(toRemove);
                GridCommissaireAdresses.Items.Refresh();
                AdresseORM.supprimerPersonneAdresse(toRemove, pToShow.idPersonneProperty);
            }
        }

        private void RefreshAdresse_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
