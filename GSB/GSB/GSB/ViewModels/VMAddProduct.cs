using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using XamSQLite.Database;
using XamSQLite.Models;

namespace XamSQLite.ViewModels
{
    public class VMAddProduct : INotifyPropertyChanged //Informe une valeur de propriété a été modifiée.
    {
        public Command btnSaveProduct { get; set; } //Declare les Boutons Ajout + Effacer
        public Command btnClearProduct { get; set; }
        private Products _products { get; set; }

        public Products product
        {
            get { return _products; }
            set
            {
                _products = value;
                OnPropertyChanged();
            }
        }

        private string _lblInfo { get; set; }
        public string lblInfo
        {
            get { return _lblInfo; }
            set
            {
                _lblInfo = value;
                OnPropertyChanged();
            }
        }

        private string _btnSaveLabel { get; set; }
        public string btnSaveLabel
        {
            get { return _btnSaveLabel; }
            set
            {
                _btnSaveLabel = value;
                OnPropertyChanged();
            }
        }


        public VMAddProduct(Products obj)
        {
            if (obj == null || obj.ID == 0)
            {
                ClearProduct(); //Efface les champs
            }


            else
            {
                product = obj;
                btnSaveLabel = "UPDATE";
            }
            btnSaveProduct = new Command(SaveProduct); //Declare une execution
            btnClearProduct = new Command(ClearProduct);
        }

        public void SaveProduct()
        {
            try
            {
                if (product.Name == "") //Si le nom du médicament + nom famille est vide
                {
                    lblInfo = "ATTENTION ! Vous devez saisir un Nom obligatoirement !";
                }
                else
                {
                    if (product.Famille == "")
                    {
                        
                        lblInfo = "ATTENTION ! Vous devez saisir une famille de médicament obligatoirement !";
                    }
                    else
                    {
                        if (product.Quantity == 0)//si la quantité est null 
                        {
                            
                            lblInfo = "ATTENTION ! Vous devez avoir au moins 1 médicament à ajouter dans la liste !";
                        }
                        else
                        { //Si conditions remplis alors ajout à la liste des produits
                            ProductDatabase productDatabase = new ProductDatabase();
                            int i = productDatabase.saveProduct(product).Result;
                            if (i == 1)
                            {

                                if (btnSaveLabel.Equals("ADD"))
                                {
                                    ClearProduct();
                                }
                                else
                                {
                                    
                                    lblInfo = "La Modification a bien été effectuée.";
                                }
                            }
                            else
                            {
                                lblInfo = "Impossible d'effectuer l'opération";
                            }
                        }


                    }


                }
            }

            catch (Exception ex)
            {
                lblInfo = " Mise à jour de la liste effectuée.";

            }

        }


        //Méthode pour attribué aux champs du vide
        public void ClearProduct()
        {
            product = new Products();
            product.ID = 0;
            product.Name = "";
            product.Famille = "";
            product.Quantity = 0;
            lblInfo = "";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
