using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using XamSQLite.Database;
using XamSQLite.Models;


namespace XamSQLite.ViewModels
{
    public class VMProducts : INotifyPropertyChanged
    {
        private ObservableCollection<Products> _lstProducts { get; set; } //Declare la liste des produits

        public ObservableCollection<Products> lstProducts
        {
            get { return _lstProducts; }
            set
            {
                _lstProducts = value;
                OnPropertyChanged();
            }
        }

        public Command btnAddProduct { get; set; }

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

        public VMProducts()
        {
            lstProducts = new ObservableCollection<Products>();

        }

        public void GetProducts()
        {
            try
            { //Affiche la liste dans le menu 
                ProductDatabase productDatabase = new ProductDatabase();
                var products = productDatabase.getProducts().Result; //Declare la variable 

                if (products != null && products.Count > 0) //Si > 0 alors il affiche les valeurs de la liste
                {
                    lstProducts = new ObservableCollection<Products>();

                    foreach (var prod in products)
                    {
                        lstProducts.Add(new Products
                        {
                            ID = prod.ID,
                            Name = prod.Name,
                            Famille = prod.Famille,
                            Quantity = prod.Quantity
                        });
                    }

                    lblInfo = "Nombre total de produit dans la liste : " + products.Count.ToString();
                }
                else
                {
                    lstProducts.Clear();
                    lblInfo = "Aucun Médicament présent dans la liste";

                }

            }

            catch (Exception ex)
            {
                lblInfo = ex.Message.ToString();
            }
        }

        public void DeleteProduct(Products product) //Effacer produit de la liste 
        {
            try
            {
                ProductDatabase productDatabase = new ProductDatabase();
                var result = productDatabase.deleteProduct(product).Result;

                if (result == 1)
                {
                    lblInfo = "Supression effectuée";
                    GetProducts();

                }

            }

            catch (Exception ex)
            {
                lblInfo = ex.Message.ToString();
            }
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
