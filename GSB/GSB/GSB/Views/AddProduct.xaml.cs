using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamSQLite.Models;
using XamSQLite.ViewModels;

namespace XamSQLite.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddProduct : ContentPage
    {
        public AddProduct(Products product)
        {
            try
            {
                InitializeComponent();
                VMAddProduct vm = new VMAddProduct(product);
                this.BindingContext = vm;
            }
            catch (Exception ex)
            {

            }

        }
    }
}