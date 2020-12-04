﻿using System;
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
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            ObservableCollection<UtilisateurVM> lp = new ObservableCollection<UtilisateurVM>();
            lp.Add(new UtilisateurVM());
            //  GridProduit.ItemsSource = lp;
            // GridProduit.IsReadOnly = true;



            // GridCommissaire.ItemsSource = LCommissaire;
            // GridCommissaire.IsReadOnly = true;


            // GridLieuV.ItemsSource = LSalleEnchere;
            // GridLieuV.IsReadOnly = true;


            // GridEnchere.ItemsSource = LEnchere;
            // GridEnchere.IsReadOnly = true;


            GridUser.ItemsSource = lp;
            GridUser.IsReadOnly = true;
            this.SizeToContent = SizeToContent.WidthAndHeight;

        }



        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}