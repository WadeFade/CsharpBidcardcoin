﻿using BidCardCoin.Class;
using BidCardCoin.ClassVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidCardCoin
{
    public class UtilisateurVM : PersonneVM
    {
        private string idUtilisateur;
        private int modePaiement;
        private bool verifSolvabilite;
        private bool ressortissant;
        private ObservableCollection<ProduitVM> produits;

        public string idUtilisateurProperty { get { return idUtilisateur; } set { idUtilisateur = value; OnPropertyChanged("idUtilisateurProperty"); } }
        public int modePaiementProperty { get { return modePaiement; } set { modePaiement = value; OnPropertyChanged("modePaiementProperty"); } }
        public bool verifSolvabiliteProperty { get { return verifSolvabilite; } set { verifSolvabilite = value; OnPropertyChanged("verifSolvabiliteProperty"); } }

        public bool ressortissantProperty { get { return ressortissant; } set { ressortissant = value; OnPropertyChanged("ressortissantProperty"); } }
        public ObservableCollection<ProduitVM> produitsProperty { get { return produits; } set { produits = value; OnPropertyChanged("produitsProperty"); } }

        public UtilisateurVM()
        {
            idPersonne = Guid.NewGuid().ToString();
            idUtilisateur = Guid.NewGuid().ToString();
            nomPersonne = "Nom";
            prenomPersonne = "Prenom";
            dateNaissance = new DateTime();
            email = "@";
            password = "pass";
            telephone = "0000000000";
            verifIdentite = false;
            modePaiement = 0;
            verifSolvabilite = false;
            ressortissant = false;
            adressePersonne = new ObservableCollection<AdresseVM>();
            produits = new ObservableCollection<ProduitVM>();
        }

        public UtilisateurVM(string idPersonne, string idUtilisateur,
            string nomPersonne, string prenomPersonne, DateTime dateNaissance,
            string email, string password, string telephone, bool verifIdentite, int modePaiement,
            bool verifSolvabilite, bool ressortissant,
            ObservableCollection<AdresseVM> adressePersonne, ObservableCollection<ProduitVM> produits)
        {
            this.idPersonne = idPersonne;
            this.idUtilisateur = idUtilisateur;
            this.nomPersonne = nomPersonne;
            this.prenomPersonne = prenomPersonne;
            this.dateNaissance = dateNaissance;
            this.email = email;
            this.password = password;
            this.telephone = telephone;
            this.verifIdentite = verifIdentite;
            this.modePaiement = modePaiement;
            this.verifSolvabilite = verifSolvabilite;
            this.ressortissant = ressortissant;
            this.adressePersonne = adressePersonne;
            this.produits = produits;
        }
    }
}
